using System;
using Xamarin.Forms;

namespace TodoApp.Forms
{
	public class TodoListView : ContentPage
	{
		public TodoListView ()
		{
			this.SetBinding (ContentPage.TitleProperty, "Title");

			var listView = new ListView ();
			listView.RowHeight = 75;
			listView.SetBinding (ListView.ItemsSourceProperty, "TodoItems");
			listView.ItemTemplate = new DataTemplate(typeof(TodoListViewCell));
			listView.VerticalOptions = LayoutOptions.Fill;
			listView.SetBinding (ListView.SeparatorVisibilityProperty, "SeparatorVisibility");

			//New 1.4 -> Pull to Refresh
			listView.IsPullToRefreshEnabled = true;
			listView.SetBinding (ListView.RefreshCommandProperty, "PullToRefreshCommand");
			listView.SetBinding (ListView.IsRefreshingProperty, "IsRefreshing");

			this.Content = listView;

			var toolbarItemReload = new ToolbarItem ();
			toolbarItemReload.Icon = "refresh_icon.png";
			toolbarItemReload.SetBinding (ToolbarItem.CommandProperty, "ReloadListCommand");
			ToolbarItems.Add (toolbarItemReload);

			var toolbarItemAdd = new ToolbarItem ();
			toolbarItemAdd.Icon = "add_icon.png";
			toolbarItemAdd.SetBinding (ToolbarItem.CommandProperty, "AddTodoItemCommand");
			ToolbarItems.Add (toolbarItemAdd);
		}
	}
}