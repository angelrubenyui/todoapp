using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XForm.Framework;
using System.Linq.Expressions;
using System.Linq;

namespace TodoApp.ApiConnector
{
	public class TodoListApiService : BaseAzureService, ITodoListApiService
	{
		
		public Task<List<TodoItem>> GetPendingItemsAsync()
		{
			return base.GetItemsAsync<TodoItem> (item => item.Complete == false);
		}

		public Task<List<TodoItem>> GetCompletedItemsAsync()
		{
			return base.GetItemsAsync<TodoItem> (item => item.Complete);
		}

		public Task<List<TodoItem>> GetAllItemsAsync()
		{
			return base.GetItemsAsync<TodoItem> (item => true);
		}

		public async Task<bool> ItemExistAsync(string id)
		{
			var response = await base.GetItemsAsync<TodoItem> (item => item.Id == id);
			return response.Count > 0;
		}

	}
}

