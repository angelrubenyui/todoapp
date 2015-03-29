using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XForm.Framework
{
	public abstract class BaseAzureService : IApiService
	{

		#region Properties

		protected MobileServiceClient ApiClient { get; private set; } 

		#endregion

		#region Constructor

		public BaseAzureService()
		{
			ApiClient = new MobileServiceClient(
				"AZURE MOBILE SERVICE URL",
				"AZURE MOBILE SERVICE API ACCESS KEY"
			);
		}

		#endregion

		#region Public Methods

		public virtual Task<List<TEntity>> GetItemsAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
			where TEntity : class
		{
			var table = ApiClient.GetTable<TEntity>();
			return table.Where(predicate).ToListAsync();
		}

		public virtual Task InsertItemAsync<TEntity> (TEntity item)
			where TEntity : class
		{
			var table = ApiClient.GetTable<TEntity>();
			return table.InsertAsync (item);
		}

		public virtual Task UpdateItemAsync<TEntity> (TEntity item)
			where TEntity : class
		{
			var table = ApiClient.GetTable<TEntity>();
			return table.UpdateAsync (item);
		}

		public virtual Task DeleteItemAsync<TEntity> (TEntity item)
			where TEntity : class
		{
			var table = ApiClient.GetTable<TEntity>();
			return table.DeleteAsync (item);
		}

		#endregion

	}
}

