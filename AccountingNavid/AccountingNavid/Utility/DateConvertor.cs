using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Utility.Convertor
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime time)
        {
            PersianCalendar cal = new PersianCalendar();
            return cal.GetYear(time).ToString() + "/" + cal.GetMonth(time).ToString("00") + "/" + cal.GetDayOfMonth(time).ToString("00") + "  " +
                + cal.GetHour(time) + ":" + cal.GetMinute(time).ToString("00") + ":" + cal.GetSecond(time).ToString("00");
        }
        public static DateTime ToShamsiDate(this DateTime time)
        {
            PersianCalendar cal = new PersianCalendar();
            return new DateTime(cal.GetYear(time), cal.GetMonth(time), cal.GetDayOfMonth(time));
        }
        public static DateTime PersianDateStringToDateTime(this string persianDate)
        {
            PersianCalendar pc = new PersianCalendar();

            var persianDateSplitedParts = persianDate.Split('/');
            DateTime dateTime = new DateTime(int.Parse(persianDateSplitedParts[0]), int.Parse(persianDateSplitedParts[1]), int.Parse(persianDateSplitedParts[2]), pc);
            return DateTime.Parse(dateTime.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }
        public static DateTime ToMiladi(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,dateTime.Hour,dateTime.Minute,dateTime.Second, new PersianCalendar());
        }
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
