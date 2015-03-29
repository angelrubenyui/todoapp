using System;
using Autofac;
using XForm.Framework;

namespace XForms.Framework.iOS
{
	public class XFormsFrameworkiOSModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Database>()
				.As<ISQLiteDatabase>()
				.SingleInstance();
		}
	}
}

