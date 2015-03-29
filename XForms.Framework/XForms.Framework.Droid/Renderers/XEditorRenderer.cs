using System;
using Xamarin.Forms;
using XForms.Framework;
using XForms.Framework.Droid;

[assembly: ExportRendererAttribute(typeof(XEditor), typeof(XEditorRenderer))]
namespace XForms.Framework.Droid
{
	public class XEditorRenderer : Xamarin.Forms.Platform.Android.EditorRenderer
	{
		protected override void OnElementChanged (Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Editor> e)
		{
			base.OnElementChanged (e);

			var xEditor = (XEditor)e.NewElement;
			if (xEditor != null) {
				Control.TextSize = (float)xEditor.FontSize;
			}
		}
	}
}

