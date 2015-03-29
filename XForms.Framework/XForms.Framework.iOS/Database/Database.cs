using System;
using System.IO;
using SQLite.Net.Async;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

namespace XForms.Framework.iOS
{
	public class Database : BaseDatabase
	{
		protected override SQLite.Net.SQLiteConnection GetConnection ()
		{
			var path = this.GetDatabasePath ();
			var conn = new SQLite.Net.SQLiteConnection(new SQLitePlatformIOS(), path);
			return conn;
		}

		protected override SQLiteAsyncConnection GetAsyncConnection()
		{
			var path = this.GetDatabasePath ();
			var connectionFactory = new Func<SQLiteConnectionWithLock> (() =>
				new SQLiteConnectionWithLock (
					new SQLitePlatformIOS (), 
					new SQLiteConnectionString (path, storeDateTimeAsTicks: false)
				)
			);
			var conn = new SQLiteAsyncConnection (connectionFactory);
			return conn;
		}

		private string GetDatabasePath()
		{
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, this.DataBaseFileName);
			return path;
		}

	}
}

