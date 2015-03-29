using System;
using Xamarin.Forms;

namespace TodoApp.Forms
{
	public class Styles
	{
		public static class Colors
		{
			//General
			public static Color MainColor { get { return Color.FromRgb(34, 163, 201); } }
			public static Color MainTextColor { get { return Color.White; } }

			//User
			public static Color ScreenUsernameColor { get { return Color.Gray; } }

			//Tweet
			public static Color TweetCharactersCounterOKTextColor { get { return Color.Gray; }}
			public static Color TweetCharactersCounterKOTextColor { get { return Color.Red; }}
			public static Color TweetSelectImageButtonTextColor { get { return Color.Gray; }}
			public static Color TweetSelectImageButtonColor { get { return Color.FromRgb(34, 163, 201); }}
			public static Color TweetTextColor { get { return Color.FromRgb (130, 131, 132); }}
		}
	}
}

