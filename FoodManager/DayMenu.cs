using CsvHelper.Configuration.Attributes;
using System;

namespace FoodManager
{
    public class DayMenu
    {
        [Index(0)]
        public DateTime Date { get; set; }

        [Ignore]
        public string DayOfWeek
        {
            get { return Date.DayOfWeek.ToString(); }
        }

        [Index(1)]
        public string Breakfast { get; set; }

        [Index(2)]
        public string Dinner { get; set; }

        [Index(3)]
        public string Supper { get; set; }
    }
}
