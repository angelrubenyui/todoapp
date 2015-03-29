using System;
using TodoApp.Forms;
using XForms.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Forms
{
	public class TodoItemRepository 
		: XForms.Framework.BaseRepository<TodoItem, string>,  
	      ITodoItemRepository
	{

		#region Constructor

		public TodoItemRepository(ISQLiteDatabase database)
			: base(database, TodoAppConstants.TODO_ITEM_DATABASE)
		{
			
		}

		#endregion

		#region Members of ITodoItemRepository

		public Task<List<TodoItem>> GetSynchronizedItemsAsync ()
		{
			return base.SelectAsync (item => item.WaitingForSynchronization == false);
		}

		public Task<List<TodoItem>> GetActiveItemsAsync ()
		{
			return base.SelectAsync (item => item.Complete == false && 
											 item.State != TodoItem.DELETED);
		}

		public Task<List<TodoItem>> GetPendingToSynchronizeItemsAsync ()
		{
			return base.SelectAsync (item => item.WaitingForSynchronization == true);
		}

		#endregion
	}
}

