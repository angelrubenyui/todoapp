using System;

using Xamarin.Forms;
using XForms.Framework;
using XForms.Framework.Bootstrapping;
using XForms.Framework.Factories;
using Autofac;

namespace TodoApp.Forms
{

	public class TodoInitializer : BaseAppInitializer
	{

		private TodoInitializer() 
			: base() 
		{
			base.Init ();
		}

		public new static BaseAppInitializer Instance
		{
			get { return BaseAppInitializer.Instance ?? new TodoInitializer(); }
		}

		protected override void InitializeDatabase ()
		{
			var database = Bootstrapper.Container.Resolve<ISQLiteDatabase> ();
			database.GetConnection (TodoAppConstants.TODO_ITEM_DATABASE).CreateTable<TodoItem> ();
		}

		protected override void RegisterViews(IViewFactory viewFactory)
		{
			viewFactory.Register<TodoListViewModel, TodoListView> ();
			viewFactory.Register<TodoItemEditViewModel, TodoItemEditView> ();
		}

		protected override void ConfigureApplication()
		{
			var viewFactory = Bootstrapper.Container.Resolve<IViewFactory> ();
			var mainPage = viewFactory.Resolve<TodoListViewModel> ();

			var navigationPage = new NavigationPage (mainPage){
				BarBackgroundColor = Styles.Colors.MainColor,
				BarTextColor = Styles.Colors.MainTextColor
			};

			Application = new TodoApp (navigationPage);
			Mappings.Init ();
		}

	}

}

