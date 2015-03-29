using System;
using UIKit;
using Xamarin.Forms;
using XForms.Framework.iOS;
using XForms.Framework;
using TodoApp.Forms;

[assembly: ExportRendererAttribute(typeof(XEditor), typeof(XEditorRenderer))]
namespace XForms.Framework.iOS
{
	public class XEditorRenderer : Xamarin.Forms.Platform.iOS.EditorRenderer
	{
		protected override void OnElementChanged (Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.Editor> e)
		{
			base.OnElementChanged (e);
			Control.Layer.CornerRadius = 10;
			Control.Layer.BorderWidth = 1;
			Control.Layer.BorderColor = UIColor.FromRGB(34, 163, 201).CGColor;

			var xEditor = (XEditor)e.NewElement;
			if (xEditor != null) {
				Control.Font = UIFont.SystemFontOfSize ((nfloat)xEditor.FontSize);
				Control.Layer.CornerRadius = 10;
			}
		}
	}
}

