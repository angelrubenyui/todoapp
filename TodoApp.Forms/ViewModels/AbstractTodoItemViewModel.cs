using System;
using XForms.Framework.ViewModels;

namespace TodoApp.Forms
{
	public abstract class AbstractTodoItemViewModel : ViewModelBase
	{

		#region Dependencies

		protected ITodoItemService TodoItemService;

		#endregion

		#region Private members

		TodoItem _item;
		string _id;
		string _text;
		bool _complete;

		#endregion

		#region Protected Properties

		protected string OriginalText { get; set; }

		#endregion

		#region Public Properties

		public TodoItem Item 
		{
			get
			{
				return _item;
			}
			private set
			{
				_item = value;
			}
		}

		public string Id 
		{ 
			get
			{
				return Item.Id;
			}
			set
			{
				Item.Id = value;
				base.SetProperty (ref _id, value, "Id");
			}
		}

		public string Text 
		{ 
			get
			{
				return Item.Text;
			}
			set
			{
				Item.Text = value;
				base.SetProperty (ref _text, value, "Text");
			}
		}

		public bool Complete 
		{ 
			get
			{
				return Item.Complete;
			}
			set
			{
				Item.Complete = value;
				base.SetProperty (ref _complete, value, "Complete");
			}
		}

		public bool WaitingForSynchronization 
		{ 
			get
			{
				return Item.WaitingForSynchronization;
			}
		}

		#endregion

		#region Commands

		#endregion

		#region Constructor

		public AbstractTodoItemViewModel (ITodoItemService service)
		{
			TodoItemService = service;
			_item = new TodoItem ();
		}

		#endregion

		#region Metodos Publicos

		public void SetItem(TodoItem item)
		{
			Item = item ?? new TodoItem();
			OriginalText = Item.Text;
		}

		#endregion

	}
}

