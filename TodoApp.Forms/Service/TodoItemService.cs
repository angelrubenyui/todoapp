using System;
using System.Threading.Tasks;
using Acr.XamForms.UserDialogs;
using Api = TodoApp.ApiConnector;

namespace TodoApp.Forms
{
	public class TodoItemService : ITodoItemService
	{

		#region Dependencies

		ITodoItemRepository _repository;
		Api.ITodoListApiService _apiService;

		#endregion

		#region Constructor

		public TodoItemService (ITodoItemRepository repository, Api.ITodoListApiService apiService)
		{
			_repository = repository;
			_apiService = apiService;
		}

		#endregion

		#region Members of ITodoItemService

		public Task MarkAsDoneAsync(TodoItem item)
		{
			item.MarkAsCompleted ();
			return _repository.UpdateAsync (item);
		}

		public Task InsertAsync(TodoItem item)
		{
			item.MarkAsCreated ();
			return _repository.InsertAsync (item);
		}

		public Task UpdateAsync(TodoItem item)
		{
			item.MarkAsUpdated ();
			return _repository.UpdateAsync (item);
		}

		public Task DeleteAsync(TodoItem item)
		{
			item.MarkAsDeleted ();
			return _repository.UpdateAsync (item);
		}

		public Task SyncAsync(TodoItem item)
		{
			Task task = null;
			//TODO: implements with strategy pattern.
			switch (item.State) 
			{
			case TodoItem.CREATED:
				task = InsertApiAsync (item);
				break;
			case TodoItem.UPDATED:
				task = UpdateApiAsync (item);
				break;
			case TodoItem.DELETED:
				task = DeleteApiAsync (item);
				break;
			}
			return task ?? Task.FromResult(0);
		}

		public async Task SyncAllAsync()
		{
			await CheckInternalSynchornizedDataWithApiServer();
			await SynchronizeInternalPendingDataWithApiServer();
			await SynchronizeDataApiServerWithInternalData ();
		}

		#endregion

		#region Private methods

		private async Task InsertApiAsync(TodoItem item)
		{
			var apiItem = AutoMapper.Mapper.Map<Api.TodoItem> (item);
			await _apiService.InsertItemAsync (apiItem);
			await MarkAsSynchronizated (item);
		}

		private async Task UpdateApiAsync(TodoItem item)
		{
			var itemExist = await _apiService.ItemExistAsync (item.Id);
			if(itemExist)
			{
				var apiItem = AutoMapper.Mapper.Map<Api.TodoItem> (item);
				await _apiService.UpdateItemAsync (apiItem);
				await MarkAsSynchronizated (item);
			}
			else
			{
				//Delete the item because it does not exists in server.
				await _repository.DeleteAsync (item.Id);
			}
		}

		private async Task DeleteApiAsync(TodoItem item)
		{
			var itemExist = await _apiService.ItemExistAsync (item.Id);
			if(itemExist)
			{
				var apiItem = AutoMapper.Mapper.Map<Api.TodoItem> (item);
				await _apiService.DeleteItemAsync (apiItem);
				await _repository.DeleteAsync (item.Id);
				await MarkAsSynchronizated (item);
			}
			else
			{
				//Delete the item because it does not exists in server.
				await _repository.DeleteAsync (item.Id);
			}
		}

		private async Task CheckInternalSynchornizedDataWithApiServer()
		{
			var items = await _repository.GetSynchronizedItemsAsync ();
			foreach (var item in items) 
			{
				var itemExist = await _apiService.ItemExistAsync (item.Id);
				if (itemExist == false)
					await _repository.DeleteAsync (item.Id);
			}
		}

		private async Task SynchronizeInternalPendingDataWithApiServer()
		{
			var items = await _repository.GetPendingToSynchronizeItemsAsync ();
			foreach (var item in items) 
			{
				await SyncAsync (item);
			}
		}

		private async Task SynchronizeDataApiServerWithInternalData()
		{
			var items = await _apiService.GetAllItemsAsync ();
			foreach (var item in items) 
			{
				await SyncRemoteData (item);
			}
		}

		private async Task SyncRemoteData(Api.TodoItem remoteItem)
		{
			var item = AutoMapper.Mapper.Map<TodoItem> (remoteItem);
			item.MarkAsSyncrhonizated ();
			var bdItem = _repository.FirstOrDefault (e => e.Id.Equals (item.Id));
			if (bdItem == null)
				await _repository.InsertAsync (item);
			else
				await _repository.UpdateAsync (item);
		}

		private async Task MarkAsSynchronizated(TodoItem item)
		{
			item.MarkAsSyncrhonizated ();
			await _repository.UpdateAsync (item);
		}

		#endregion

	}
}

