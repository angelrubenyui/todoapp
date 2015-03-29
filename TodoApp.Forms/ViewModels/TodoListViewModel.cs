using System;
using XForms.Framework.ViewModels;
using TodoApp.ApiConnector;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace TodoApp.Forms
{
	public class TodoListViewModel : AbstractTodoItemViewModel
	{

		#region Dependencies

		readonly ITodoItemRepository _todoItemRepository;
		readonly Func<TodoItem, TodoItemCellViewModel> _todoItemCellViewModelFactory;

		#endregion

		#region Private Members

		bool _reloadList = true;
		bool _isRefreshing = false;
		SeparatorVisibility _separatorVisibility = SeparatorVisibility.None;
		IEnumerable<TodoItemCellViewModel> _todoItems;

		#endregion

		#region Public Properties

		public IEnumerable<TodoItemCellViewModel> TodoItems
		{ 
			get
			{
				return _todoItems;
			}
			set
			{
				SeparatorVisibility = value != null && value.Any () ? 
					SeparatorVisibility.Default : 
					SeparatorVisibility.None;
				base.SetProperty(ref _todoItems, value, "TodoItems");
			}
		}

		public SeparatorVisibility SeparatorVisibility
		{ 
			get
			{
				return _separatorVisibility;
			}
			set
			{
				base.SetProperty(ref _separatorVisibility, value, "SeparatorVisibility");
			}
		}

		public bool IsRefreshing
		{ 
			get
			{
				return _isRefreshing;
			}
			set
			{
				base.SetProperty(ref _isRefreshing, value, "IsRefreshing");
			}
		}



		#endregion

		#region Commands

		public ICommand AddTodoItemCommand { get; set; }
		public ICommand ReloadListCommand { get; set; }
		public ICommand PullToRefreshCommand { get; set; }

		#endregion

		#region Constructor

		public TodoListViewModel (ITodoItemRepository todoItemRepository,
								  ITodoItemService todoItemService,
								  Func<TodoItem, TodoItemCellViewModel> todoItemCellViewModelFactory)
			:base(todoItemService)
		{
			Title = "Todo List";

			_todoItemRepository = todoItemRepository;
			_todoItemCellViewModelFactory = todoItemCellViewModelFactory;

			AddTodoItemCommand = new Command (ShowItemView);
			ReloadListCommand = new Command (ReloadList);
			PullToRefreshCommand = new Command (PullToRefresh);

			SeparatorVisibility = SeparatorVisibility.None;

			MessagingCenter.Subscribe<TodoItemEditViewModel> (this, "ReloadList", (sender) => {
				_reloadList = true;
			});
				
			MessagingCenter.Subscribe<TodoItemCellViewModel> (this, "ReloadList", async (sender) => {
				using (var dlg = base.DialogService.Loading ("Loading items...")) 
				{
					_reloadList = true;
					await LoadTweets();
				}
			});
		}

		#endregion

		#region Public Methods

		public async override void OnAppearing ()
		{
			if (_reloadList) 
			{
				_reloadList = false;
				await LoadTweets ();
			}
		}

		#endregion

		#region Private Methods

		async Task LoadTweets ()
		{
			var items = await _todoItemRepository.GetActiveItemsAsync();
			TodoItems = items.Select (item => _todoItemCellViewModelFactory (item))
							 .OrderBy(t => t.Text)
							 .ToList ();
		}

		private void ShowItemView()
		{
			base.Navigator.PushAsync<TodoItemEditViewModel> ();
		}

		private async void PullToRefresh()
		{
			IsRefreshing = true;
			await TodoItemService.SyncAllAsync ();
			await LoadTweets();
			IsRefreshing = false;
		}

		private async void ReloadList()
		{
			using (var dlg = base.DialogService.Loading ("Loading items...")) 
			{
				_reloadList = true;
				await TodoItemService.SyncAllAsync ();
				await LoadTweets();
				_reloadList = false;	
			}
		}

		#endregion

	}
}

