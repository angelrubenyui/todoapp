using System;
using Xamarin.Forms;

namespace TodoApp.Forms
{
	public class TodoListViewCell : ViewCell
	{
		public TodoListViewCell ()
		{
			var textLayout = CreateTextLayout ();
			var imageLayout = CreateButtonsLayout();

			var viewLayout = new StackLayout()
			{
				Padding = 10,
				Orientation = StackOrientation.Horizontal,
				Children = { textLayout, imageLayout },
				Spacing = 20
			};

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.SetBinding (TapGestureRecognizer.CommandProperty, "ShowItemCommand");

			viewLayout.GestureRecognizers.Add (tapGestureRecognizer);

			View = viewLayout;

			AddContextActions ();
		}

		StackLayout CreateTextLayout()
		{
			var lblText = new Label { 
				HeightRequest = 20,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				YAlign = TextAlignment.Center, 
				LineBreakMode = LineBreakMode.TailTruncation
			};
			lblText.SetBinding (Label.TextProperty, "Text");
			return new StackLayout {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { lblText }
			};
		}

		StackLayout CreateButtonsLayout()
		{
			var image = new Image
			{
				HorizontalOptions = LayoutOptions.End,
				Source = "cloud_icon_dark.png"
			};
			image.SetBinding(Image.IsVisibleProperty, "WaitingForSynchronization");
			image.WidthRequest = image.HeightRequest = 60;
			image.VerticalOptions = LayoutOptions.Start;
			return new StackLayout {
				Children = { image }
			};
		}

		void AddContextActions()
		{
			var doneAction = new MenuItem { Text = "Done" };
			doneAction.SetBinding (MenuItem.CommandProperty, "DoneCommand");
			ContextActions.Add (doneAction);

			var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true };
			deleteAction.SetBinding (MenuItem.CommandProperty, "DeleteCommand");
			ContextActions.Add (deleteAction);
		}

	}
}

