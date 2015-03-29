using System;
using Xamarin.Forms;

namespace TodoApp.Forms
{
	public class TodoApp : Application
	{
		public TodoApp (Page page)
		{
			// The root page of your application
			MainPage = page;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

