using System;
using SQLite.Net;
using SQLite.Net.Async;

namespace XForms.Framework
{
	public abstract class BaseDatabase : ISQLiteDatabase
	{

		protected string DataBaseFileName { get; private set; }

		public SQLiteConnection GetConnection(string dataBaseName)
		{
			if (string.IsNullOrEmpty (dataBaseName))
				throw new ArgumentException ("databasename");
			
			this.DataBaseFileName = this.FormatDataBaseName (dataBaseName);

			return GetConnection ();
		}

		public SQLiteAsyncConnection GetAsyncConnection(string dataBaseName)
		{
			if (string.IsNullOrEmpty (dataBaseName))
				throw new ArgumentException ("databasename");

			this.DataBaseFileName = this.FormatDataBaseName (dataBaseName);

			return GetAsyncConnection ();
		}

		protected abstract SQLiteConnection GetConnection();

		protected abstract SQLiteAsyncConnection GetAsyncConnection();

		private string FormatDataBaseName(string dataBaseFileName)
		{
			var fileName = dataBaseFileName.EndsWith (".db3") ? 
								dataBaseFileName : 
								string.Concat (dataBaseFileName, ".db3");
			return fileName;
		}

	}
}

