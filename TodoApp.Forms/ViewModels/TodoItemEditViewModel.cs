using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoApp.Forms
{
	public class TodoItemEditViewModel : AbstractTodoItemViewModel
	{

		#region Commands

		public ICommand SaveCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand SyncCommand { get; set; }
		public ICommand DoneCommand { get; set; }

		#endregion

		#region Constructor

		public TodoItemEditViewModel (ITodoItemService service)
			:base(service)
		{
			SaveCommand = new Command (Save);
			DeleteCommand = new Command (Delete);
			SyncCommand = new Command (Sync);
			DoneCommand = new Command (Done);
		}

		#endregion

		#region Private Methods

		private async void Save()
		{
			if (string.IsNullOrEmpty (Text)) 
			{
				base.DialogService.Alert ("The text must be indicated.", "Data required");
			} 
			else 
			{
				if (Item.Id == TodoItem.NEW_ID) 
				{
					await CreateItem ();
				} 
				else 
				{
					await UpdateItem ();
				}
				await base.Navigator.PopAsync ();
			}
		}

		private async void Delete()
		{
			if (Item.Id != TodoItem.NEW_ID) 
			{
				var response = await DialogService.ConfirmAsync("Are you sure?", "Confirmation.", "Yes", "No");
				if (response == true) 
				{
					using (var dlg = base.DialogService.Loading ("Deleting item...")) 
					{
						await TodoItemService.DeleteAsync (Item);
						SendMessageForUpdateList ();
						await base.Navigator.PopAsync ();
					}
				}
			}
			else 
			{
				DialogService.Alert ("TodoItem must be created to execute the Delete action.", "Information");
			}
		}

		private async void Sync()
		{
			if (Item.Id != TodoItem.NEW_ID) 
			{
				if (Item.WaitingForSynchronization == true) 
				{
					using (var dlg = base.DialogService.Loading ("Synchronizing item...")) 
					{
						await TodoItemService.SyncAsync (Item);
						SendMessageForUpdateList ();
					}
				} 
				else 
				{
					DialogService.Alert ("The Sync action has not executed. TodoItem is already synchronized.", "Information");
				}

			} 
			else 
			{
				DialogService.Alert ("TodoItem must be created to execute the Sync action.", "Information");
			}
		}

		private async void Done()
		{
			if (Item.Id != TodoItem.NEW_ID) 
			{
				using (var dlg = base.DialogService.Loading ("Saving item...")) 
				{
					await TodoItemService.MarkAsDoneAsync (Item);
					SendMessageForUpdateList ();
					await base.Navigator.PopAsync ();
				}
			}
			else 
			{
				DialogService.Alert ("TodoItem must be created to execute the Done action.", "Information");
			}
		}

		private async Task CreateItem()
		{
			var item = new TodoItem 
			{
				Id = Guid.NewGuid().ToString(),
				Text = this.Text
			};
			base.SetItem (item);
			using (var dlg = base.DialogService.Loading ("Saving item...")) 
			{
				await TodoItemService.InsertAsync (Item);
				SendMessageForUpdateList ();
			}
		}

		private async Task UpdateItem()
		{
			if (Item.Text.Equals (OriginalText) == false) 
			{
				using (var dlg = base.DialogService.Loading ("Saving item...")) 
				{
					await TodoItemService.UpdateAsync (Item);
					SendMessageForUpdateList ();
					OriginalText = Item.Text;
				}
			}
			await Task.FromResult(0);
		}

		private void SendMessageForUpdateList()
		{
			MessagingCenter.Send<TodoItemEditViewModel> (this, "ReloadList");
		}

		#endregion

	}
}

