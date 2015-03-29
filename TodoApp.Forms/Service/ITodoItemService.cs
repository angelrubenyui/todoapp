using System;
using System.Threading.Tasks;

namespace TodoApp.Forms
{
	public interface ITodoItemService
	{
		Task MarkAsDoneAsync(TodoItem item);
		Task InsertAsync(TodoItem item);
		Task UpdateAsync(TodoItem item);
		Task DeleteAsync(TodoItem item);
		Task SyncAsync(TodoItem item);
		Task SyncAllAsync();
	}
}

