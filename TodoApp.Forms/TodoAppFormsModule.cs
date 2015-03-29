using System;
using Autofac;
using TodoApp.ApiConnector;

namespace TodoApp.Forms
{
	public class TodoAppFormsModule : Module
	{
		protected override void Load (ContainerBuilder builder)
		{
			//Mappings
			//Mappings.Map();

			//Modules
			builder.RegisterModule<TodoAppApiConnectorModule>();

			//External services.
			//builder.RegisterInstance<IUserDialogService> (DependencyService.Get<IUserDialogService> ());

			//Repositories.
			builder.RegisterType<TodoItemRepository>()
				.As<ITodoItemRepository>();

			//Services.
			builder.RegisterType<TodoItemService>()
				.As<ITodoItemService>();

			//View Models
			builder.RegisterType<TodoListViewModel> ();
			builder.RegisterType<TodoItemEditViewModel> ();
			builder.RegisterType<TodoItemCellViewModel> ();

			//Views
			builder.RegisterType<TodoListView> ();
			builder.RegisterType<TodoItemEditView> ();
			builder.RegisterType<TodoListViewCell> ();

		}
	}
}

