using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: Xamarin.Forms.ExportRenderer(typeof(AccountingNavid.Utility.NumberEntry), typeof(AccountingNavid.Droid.Utility.NumberEntry))]
namespace AccountingNavid.Droid.Utility
{
    public class NumberEntry : EntryRenderer
    {
        public NumberEntry(Context ctx) : base(ctx)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.NumberVariationNormal;
            }
        }
    }
}