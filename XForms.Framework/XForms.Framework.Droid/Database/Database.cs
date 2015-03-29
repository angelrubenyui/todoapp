using System;
using System.IO;
using Xamarin.Forms;
using XForms.Framework.Droid;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite.Net;

namespace XForms.Framework.Droid
{
	public class Database : BaseDatabase
	{
		protected override SQLiteConnection GetConnection () 
		{
			var path = this.GetDatabasePath ();
			var conn = new SQLiteConnection(new SQLitePlatformAndroid(), path);
			return conn;
		}

		protected override SQLiteAsyncConnection GetAsyncConnection()
		{
			var path = this.GetDatabasePath ();
			var connectionFactory = new Func<SQLiteConnectionWithLock> (() =>
				new SQLiteConnectionWithLock (
					new SQLitePlatformAndroid (), 
				    new SQLiteConnectionString (path, storeDateTimeAsTicks: false)
				)
			);
			var conn = new SQLiteAsyncConnection (connectionFactory);
			return conn;
		}

		private string GetDatabasePath()
		{
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, this.DataBaseFileName);
			return path;
		}
	}
}

