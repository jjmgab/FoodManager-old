using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManager
{
    static class MenuDateHelper
    {
        /// <summary>
        /// When given a date, iterates backwards until getting to the first monday.
        /// </summary>
        /// <param name="date">given date</param>
        /// <returns>date of the first monday backwards</returns>
        public static DateTime GetDateOfFirstDayOfTheWeek(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }
            return date;
        }

        /// <summary>
        /// Creates a DayMenu list, consisting of seven days from monday to sunday.
        /// </summary>
        /// <param name="date">given date</param>
        /// <returns>DayMenu list of seven entries (one week)</returns>
        public static List<DayMenu> CreateWeekMenuList(DateTime date)
        {
            date = MenuDateHelper.GetDateOfFirstDayOfTheWeek(date);

            // set hours to 00:00:00
            date = date.AddHours(-date.Hour);
            date = date.AddMinutes(-date.Minute);
            date = date.AddSeconds(-date.Second);

            List<DayMenu> result = new List<DayMenu>();

            for (int i = 0; i < 7; i++)
            {
                result.Add(new DayMenu { Date = date.AddDays(i) });
            }
            return result;
        }
    }
}
