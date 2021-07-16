using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: Xamarin.Forms.ExportRenderer(typeof(AccountingNavid.Utility.NumberEntry), typeof(AccountingNavid.iOS.Utility.NumberEntry))]
namespace AccountingNavid.iOS.Utility
{
    public class NumberEntry : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.KeyboardType = UIKit.UIKeyboardType.NumberPad;
            }
        }
    }
}