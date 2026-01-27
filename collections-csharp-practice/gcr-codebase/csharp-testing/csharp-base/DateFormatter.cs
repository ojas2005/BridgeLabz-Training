using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public  class DateFormatter
    {
        public string FormatDate(string inputDate)
        {
            if (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                throw new FormatException("Invalid date format");
            }

            return date.ToString("dd-MM-yyyy");
        }
    }
}
