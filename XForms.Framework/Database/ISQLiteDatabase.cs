using System;
using SQLite.Net;
using SQLite.Net.Async;

namespace XForms.Framework
{
	public interface ISQLiteDatabase
	{
		SQLiteConnection GetConnection(string databasename);
		SQLiteAsyncConnection GetAsyncConnection(string databasename);
	}
}

