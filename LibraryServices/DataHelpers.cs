using LibraryData.Models;
using System;
using System.Collections.Generic;

namespace LibraryServices
{
    public class DataHelpers
    {

        public static List<string> HumanizeBusinessHours(IEnumerable<BranchHours> branchHours)
        {
            var hours = new List<string>();

            foreach (var time in branchHours)
            {
                var day = HumanizeDay(time.DayOfWeek);
                var openTime = HumanizeTime(time.DayOfWeek);
                var closeTime = HumanizeTime(time.DayOfWeek);
                var timeEntry = $"{day} {openTime} to {closeTime}";

                hours.Add(timeEntry);
            }

            return hours;
        }

        public static string HumanizeTime(int time)
        {
            return TimeSpan.FromHours(time).ToString("hh':'mm");
        }

        public static string HumanizeDay(int number)
        {
            //1-7 vs 0-6 days of the week
            return Enum.GetName(typeof(DayOfWeek),number-1);
        }
    }
}
