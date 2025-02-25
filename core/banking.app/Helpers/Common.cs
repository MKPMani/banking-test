using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking.app.Helpers
{
    public class Common
    {
        public static DateOnly FormatDateOnly(string date)
        {
            DateOnly _date = DateOnly.MinValue;

            if (!string.IsNullOrWhiteSpace(date))
            {
                DateOnly.TryParseExact(date, "yyyyMMdd", out _date);
            }
            return _date;
        }


        public static DateOnly FirstDayOfTheMonth(DateOnly value)
        {
            return new DateOnly(value.Year, value.Month, 1);
        }

        public static DateOnly LastDayofTheMonth(DateOnly value)
        {
            return new DateOnly(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month));
        }

        public static int DaysInMonth(DateOnly value)
        {
            return DateTime.DaysInMonth(value.Year, value.Month);
        }

        public static int DaysBetween(DateOnly value1, DateOnly value2)
        {
            return value1.DayNumber - value2.DayNumber;
        }
    }
}
