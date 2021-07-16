using Paperboy.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AccountingNavid.ViewModel
{
    public class BitDateTimePickerViewModel : ObservableBase
    {
        private DateTime? _toDate;
        public DateTime? ToDate
        {
            get { return this._toDate; }
            set { this.SetProperty(ref this._toDate, value); }
        }
        private DateTime? _fromDate;
        public DateTime? FromDate
        {
            get { return this._fromDate; }
            set { this.SetProperty(ref this._fromDate, value); }
        }
    }
}
