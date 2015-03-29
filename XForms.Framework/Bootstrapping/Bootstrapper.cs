using System;
using Autofac;
using XForms.Framework.Factories;

namespace XForms.Framework.Bootstrapping
{
    public class Bootstrapper
    {

		#region Private Members

		static bool _containerInitialized = false;
		static ContainerBuilder _containerBuilder;
	    static IContainer _container;

		#endregion

		#region Container Builder

		/// <summary>
		/// Container Builder.
		/// </summary>
		public static ContainerBuilder ContainerBuilder
		{
			get
			{
				if (_containerBuilder == null) {
					_containerBuilder = new ContainerBuilder ();
					_containerBuilder.RegisterModule<XFormsFrameworkModule>();
				}
				return _containerBuilder;
			}
		}

		#endregion

		#region Container

		/// <summary>
		/// Gets a instance of the IoC container.
		/// </summary>
		public static IContainer Container
		{
			get
			{
				if (_containerInitialized == false)
					throw new Exception ("XForms - The IoC Container must be initialized.");
				return _container;
			}
		}

		#endregion

		#region Initializer

		/// <summary>
		/// Initializes the IoC IContainer.
		/// </summary>
        public static void Init()
        {
			_containerInitialized = true;
			_container = ContainerBuilder.Build();
        }

		#endregion 

    }
}

