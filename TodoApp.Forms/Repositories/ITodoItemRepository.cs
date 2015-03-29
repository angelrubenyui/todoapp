using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoApp.Forms
{
	public interface ITodoItemRepository : XForms.Framework.IRepository<TodoItem, string>
	{
		Task<List<TodoItem>> GetSynchronizedItemsAsync ();
		Task<List<TodoItem>> GetActiveItemsAsync ();
		Task<List<TodoItem>> GetPendingToSynchronizeItemsAsync ();
	}
}

