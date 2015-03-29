using System;
using Autofac;

namespace TodoApp.ApiConnector
{
	public class TodoAppApiConnectorModule : Module
	{
		protected override void Load (ContainerBuilder builder)
		{
			builder.RegisterType<TodoListApiService>()
				.As<ITodoListApiService>();
		}
	}
}

