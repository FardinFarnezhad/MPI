using AccountingNavid.Droid.Renderers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly:ExportRenderer (typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer))]
namespace AccountingNavid.Droid.Renderers
{
    public class CustomButtonRenderer: ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var button = (Xamarin.Forms.Button)e.NewElement;
                button.BackgroundColor = Xamarin.Forms.Color.FromHex("#00B7BB");
                button.TextColor = Xamarin.Forms.Color.White;
                button.FontFamily = "FarsiFont";
                button.BorderRadius = 22;
            }
        }
    }
}