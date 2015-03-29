using System;
using Autofac;
using XForms.Framework.Factories;
using XForms.Framework.Services;
using Xamarin.Forms;
using XForm.Framework;
using Acr.XamForms.UserDialogs;

namespace XForms.Framework
{
    public class XFormsFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // service registration
            builder.RegisterType<ViewFactory>()
                .As<IViewFactory>()
                .SingleInstance();

            builder.RegisterType<Navigator>()
                .As<INavigator>()
                .SingleInstance();

			//External services.
			builder.RegisterInstance<IUserDialogService> (DependencyService.Get<IUserDialogService> ());

            // navigation registration
            builder.Register<INavigation>(context => 
				BaseAppInitializer.Instance.Application.MainPage.Navigation
            ).SingleInstance();
        }
    }
}

