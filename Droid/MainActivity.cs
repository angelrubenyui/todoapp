using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Autofac;
using TodoApp.Forms;
using XForms.Framework.Bootstrapping;
using XForms.Framework;
using XForms.Framework.Droid;
using Microsoft.WindowsAzure.MobileServices;

namespace TodoApp.Droid
{
	[Activity (Label = "TodoApp.Droid", 
		Icon = "@drawable/icon", 
		MainLauncher = true, 
		Theme="@android:style/Theme.Holo.Light",
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			global::Xamarin.Forms.Forms.Init (this, bundle);
			CurrentPlatform.Init();
			Bootstrapper.ContainerBuilder.RegisterModule<TodoAppFormsModule>();
			Bootstrapper.ContainerBuilder.RegisterModule<XFormsFrameworkModule>();
			Bootstrapper.ContainerBuilder.RegisterModule<XFormsFrameworkDroidModule>();
			LoadApplication (TodoInitializer.Instance.Application);
		}
	}
}

