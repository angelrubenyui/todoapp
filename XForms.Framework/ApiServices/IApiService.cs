using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XForm.Framework
{
	public interface IApiService		
	{
		Task<List<TEntity>> GetItemsAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
			where TEntity : class;
		
		Task InsertItemAsync<TEntity> (TEntity item)
			where TEntity : class;

		Task UpdateItemAsync<TEntity> (TEntity item)
			where TEntity : class;

		Task DeleteItemAsync<TEntity> (TEntity item)
			where TEntity : class;
	}
}

