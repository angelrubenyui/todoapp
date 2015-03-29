using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using XForm.Framework;

namespace TodoApp.ApiConnector
{
	public interface ITodoListApiService : IApiService
	{
		Task<List<TodoItem>> GetPendingItemsAsync();
		Task<List<TodoItem>> GetCompletedItemsAsync();
		Task<List<TodoItem>> GetAllItemsAsync();
		Task<bool> ItemExistAsync(string id);
	}
}

