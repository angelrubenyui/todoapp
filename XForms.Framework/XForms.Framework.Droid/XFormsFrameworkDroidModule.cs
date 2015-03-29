using System;
using Autofac;
using XForm.Framework;

namespace XForms.Framework.Droid
{
	public class XFormsFrameworkDroidModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Database>()
				.As<ISQLiteDatabase>()
				.SingleInstance();
		}
	}
}

