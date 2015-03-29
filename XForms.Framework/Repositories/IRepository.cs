using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XForms.Framework
{
	public interface IRepository<TEntity, TPrimaryKey> 
		where TEntity : IEntity<TPrimaryKey>
	{
		void Insert (TEntity item);
		void Update (TEntity item);
		void Delete (TPrimaryKey id);
		List<TEntity> GetAll ();
		TEntity Find (TPrimaryKey id);
		TEntity FirstOrDefault (Expression<Func<TEntity, bool>> predicate);
		List<TEntity> Select (Expression<Func<TEntity, bool>> predicate);

		Task InsertAsync (TEntity item);
		Task UpdateAsync (TEntity item);
		Task DeleteAsync (TPrimaryKey id);
		Task<List<TEntity>> GetAllAsync ();
		Task<TEntity> FindAsync (TPrimaryKey id);
		Task<TEntity> FirstOrDefaultAsync (Expression<Func<TEntity, bool>> predicate);
		Task<List<TEntity>> SelectAsync (Expression<Func<TEntity, bool>> predicate);
	}
}

