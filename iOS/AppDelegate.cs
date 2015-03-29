using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Autofac;
using TodoApp.Forms;
using XForms.Framework.Bootstrapping;
using XForms.Framework;
using XForms.Framework.iOS;
using Microsoft.WindowsAzure.MobileServices;

namespace TodoApp.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
			CurrentPlatform.Init();
			Bootstrapper.ContainerBuilder.RegisterModule<TodoAppFormsModule>();
			Bootstrapper.ContainerBuilder.RegisterModule<XFormsFrameworkModule>();
			Bootstrapper.ContainerBuilder.RegisterModule<XFormsFrameworkiOSModule>();
			LoadApplication (TodoInitializer.Instance.Application);
			return base.FinishedLaunching (app, options);
		}
	}
}

