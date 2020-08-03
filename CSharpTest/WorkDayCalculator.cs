using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            var finishDate = startDate.AddDays(dayCount - 1);

            foreach (var weekEnd in weekEnds ?? new WeekEnd[0])
            {
                if (weekEnd.StartDate <= finishDate && weekEnd.EndDate >= startDate)
                {
                    bool isStartDateOnWeekend = startDate >= weekEnd.StartDate && startDate <= weekEnd.EndDate;

                    var weekendStartDate = isStartDateOnWeekend ? startDate : weekEnd.StartDate;
                    int weekendDayCount = (weekEnd.EndDate - weekendStartDate).Days + 1;

                    finishDate = finishDate.AddDays(weekendDayCount);
                }
            }

            return finishDate;
        }
    }
}
