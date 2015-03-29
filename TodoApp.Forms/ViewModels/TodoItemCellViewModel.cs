using System;
using TodoApp.Forms;
using XForms.Framework.ViewModels;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace TodoApp.Forms
{
	public class TodoItemCellViewModel : AbstractTodoItemViewModel
	{

		#region Commands

		public ICommand DoneCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand ShowItemCommand { get; set; }

		#endregion

		#region Constructor

		public TodoItemCellViewModel (TodoItem todoItem, ITodoItemService service)
			:base(service)
		{
			DoneCommand = new Command (Done);
			DeleteCommand = new Command (Delete);
			ShowItemCommand = new Command (ShowItem);
			base.SetItem (todoItem);
		}

		#endregion

		#region Private Methods

		private void ShowItem()
		{
			base.Navigator.PushAsync<TodoItemEditViewModel> (viewModel => {
				viewModel.SetItem(base.Item);
			});
		}

		private async void Done()
		{
			using (var dlg = base.DialogService.Loading ("Saving item...")) 
			{
				await TodoItemService.MarkAsDoneAsync (Item);
				SendMessageForUpdateList ();
			}
		}

		private async void Delete()
		{
			using (var dlg = base.DialogService.Loading ("Deleting item...")) 
			{
				await TodoItemService.DeleteAsync (Item);
				SendMessageForUpdateList ();
			}
		}

		private void SendMessageForUpdateList()
		{
			MessagingCenter.Send<TodoItemCellViewModel> (this, "ReloadList");
		}

		#endregion

	}
}

