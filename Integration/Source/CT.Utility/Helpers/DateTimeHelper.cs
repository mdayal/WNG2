using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CT.Utility.ExtensionMethods;

namespace CT.Utility.Helpers
{
    public class DateTimeHelper
    {
        public static IList<DateTime> GetDaysDuringPeriod(DateTime startDateTime, DateTime endDateTime)
        {
            var result = new List<DateTime>();

            var periodStartTime = startDateTime.AbsoluteStart();
            var periodEndTime = endDateTime.AbsoluteEnd();

            for (DateTime currentDate = periodStartTime; currentDate < periodEndTime; currentDate = currentDate.AddDays(1))
            {
                result.Add(currentDate);
            }

            return result;
        }
    }
}
