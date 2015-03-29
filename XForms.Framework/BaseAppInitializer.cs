using System;
using Xamarin.Forms;
using System.Collections.Generic;
using XForms.Framework.Factories;
using Autofac;
using XForms.Framework.Bootstrapping;

namespace XForms.Framework
{
	public abstract class BaseAppInitializer : BindableObject
    {
        public BaseAppInitializer()
        {
			Instance = this;
        }

		public static BaseAppInitializer Instance { get; protected set; }

		public Application Application { get; protected set; }

		protected void Init()
		{
			Bootstrapper.Init ();
			var viewFactory = Bootstrapper.Container.Resolve<IViewFactory> ();
			InitializeDatabase ();
			RegisterViews(viewFactory);
			ConfigureApplication();
		}

		protected abstract void RegisterViews(IViewFactory viewFactory);

		protected abstract void ConfigureApplication();

		protected virtual void InitializeDatabase() { }

    }
}

