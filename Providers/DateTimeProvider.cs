using System;
using System.Collections.Generic;

namespace Providers
{
	public class DateTimeProvider
	{
		public DateTimeProvider ()
		{
			
		}

		public Dictionary<int,List<DateTime>> GetWeeks() {
            try {
                var startDate = new DateTime(DateTime.Now.Year, 1, 1);
                var endDate = new DateTime(DateTime.Now.Year, 12, 31);
                var weeks = 52;
                Dictionary<int, List<DateTime>> result = new Dictionary<int, List<DateTime>>();
                for (int weekNum = 1; weekNum <= weeks; weekNum++) {
                    List<DateTime> week = new List<DateTime>();
                    for (int d = 1; d <= 7; d++) {
                        var rdate = startDate.AddDays(d);
                        if (d == 7) {
                            startDate = rdate;
                        }
                        week.Add(rdate);
                    }
                    result.Add(weekNum, week);
                }
                return result;
            } catch
            {
                return null;
            }
		}
	}
}

