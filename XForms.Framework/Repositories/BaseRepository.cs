using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;
using System.Linq;
using System.Linq.Expressions;

namespace XForms.Framework
{
	public abstract class BaseRepository<TEntity, TPrimaryKey> 
		: IRepository<TEntity, TPrimaryKey>
		where TEntity : IEntity<TPrimaryKey>, new()
	{

		static object locker = new object ();

		ISQLiteDatabase _database;
		string _databaseName;

		public BaseRepository(ISQLiteDatabase database, string databaseName)
		{
			if(database == null)
				throw new ArgumentNullException("database");

			if(databaseName == null)
				throw new ArgumentNullException("databaseName");
			
			_database = database;
			_databaseName = databaseName;
		}

		//Sync API

		public void Insert (TEntity item)
		{
			lock (locker) {
				var dbConnection = _database.GetConnection (_databaseName);
				dbConnection.Insert (item);
			}
		}

		public void Update (TEntity item)
		{
			lock (locker) {
				var dbConnection = _database.GetConnection (_databaseName);
				dbConnection.Update(item);
			}
		}

		public void Delete (TPrimaryKey id)
		{
			lock (locker) {
				var dbConnection = _database.GetConnection (_databaseName);
				dbConnection.Delete<TEntity> (id);
			}
		}

		public List<TEntity> GetAll ()
		{
			lock (locker) {
				var dbConnection = _database.GetConnection (_databaseName);
				return (from t in dbConnection.Table<TEntity>()
					select t).ToList();
			}
		}

		public TEntity Find (TPrimaryKey id)
		{
			lock (locker) {
				var dbConnection = _database.GetConnection (_databaseName);
				return dbConnection.Find<TEntity> (id);
			}
		}
			
		public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			lock (locker) {
				var dbConnection = _database.GetConnection (_databaseName);
				return dbConnection.Table<TEntity> ().Where (predicate).FirstOrDefault();
			}
		}

		public List<TEntity> Select (Expression<Func<TEntity, bool>> predicate)
		{
			lock (locker) {
				var dbConnection = _database.GetConnection (_databaseName);
				return dbConnection.Table<TEntity> ().Where (predicate).ToList();
			}
		}

		//Async API

		public Task InsertAsync (TEntity item)
		{
			var dbConnection = _database.GetAsyncConnection (_databaseName);
			return dbConnection.InsertAsync(item);
		}

		public Task UpdateAsync (TEntity item)
		{
			var dbConnection = _database.GetAsyncConnection (_databaseName);
			return dbConnection.UpdateAsync(item);
		}

		public Task DeleteAsync (TPrimaryKey id)
		{
			var dbConnection = _database.GetAsyncConnection (_databaseName);
			return dbConnection.DeleteAsync<TEntity> (id);
		}

		public Task<List<TEntity>> GetAllAsync ()
		{
			var dbConnection = _database.GetAsyncConnection (_databaseName);
			return dbConnection.Table<TEntity> ().ToListAsync ();
		}

		public Task<TEntity> FindAsync (TPrimaryKey id)
		{
			var dbConnection = _database.GetAsyncConnection (_databaseName);
			return dbConnection.FindAsync<TEntity> (id);
		}

		public Task<TEntity> FirstOrDefaultAsync (Expression<Func<TEntity, bool>> predicate)
		{
			var dbConnection = _database.GetAsyncConnection (_databaseName);
			return dbConnection.Table<TEntity> ().Where (predicate).FirstOrDefaultAsync();
		}

		public Task<List<TEntity>> SelectAsync (Expression<Func<TEntity, bool>> predicate)
		{
			var dbConnection = _database.GetAsyncConnection (_databaseName);
			return dbConnection.Table<TEntity> ().Where (predicate).ToListAsync ();
		}

	}
}

