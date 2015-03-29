using System;
using Xamarin.Forms;
using XForms.Framework;

namespace TodoApp.Forms
{
	public class TodoItemEditView : ContentPage
	{
		
		XEditor _editor;

		public TodoItemEditView ()
		{
			this.SetBinding (ContentPage.TitleProperty, "Title");

			var textLayout = CreateEditorLayout ();

			var layout = new StackLayout { 
				Padding = 10,
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { textLayout }
			};

			this.Content = layout;

			var toolbarItemDelete = new ToolbarItem ();
			toolbarItemDelete.Icon = "delete_icon.png";
			toolbarItemDelete.SetBinding (ToolbarItem.CommandProperty, "DeleteCommand");
			ToolbarItems.Add (toolbarItemDelete);

			var toolbarItemSync = new ToolbarItem ();
			toolbarItemSync.Icon = "cloud_icon_white.png";
			toolbarItemSync.SetBinding (ToolbarItem.CommandProperty, "SyncCommand");
			ToolbarItems.Add (toolbarItemSync);

			var toolbarItemDone = new ToolbarItem ();
			toolbarItemDone.Icon = "done_icon.png";
			toolbarItemDone.SetBinding (ToolbarItem.CommandProperty, "DoneCommand");
			ToolbarItems.Add (toolbarItemDone);

			var toolbarItemSave = new ToolbarItem ();
			toolbarItemSave.Icon = "save_icon.png";
			toolbarItemSave.SetBinding (ToolbarItem.CommandProperty, "SaveCommand");
			ToolbarItems.Add (toolbarItemSave);
		}

		StackLayout CreateEditorLayout ()
		{
			_editor = new XEditor {
				VerticalOptions = LayoutOptions.FillAndExpand,
				FontSize = 16
			};
			_editor.SetBinding (XEditor.TextProperty, "Text", BindingMode.TwoWay);

			return new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { _editor }
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			_editor.Focus ();
		}

	}
}

