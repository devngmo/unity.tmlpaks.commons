using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmlpaks.commons
{
    [Serializable]
    public class DayTime
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        
        public int Minutes { get; set; }

        public int TotalMonths
        {
            get => Year * 12 + Month;
        }

        public int TotalDays
        {
            get => Month * 30 + Day;
        }

        public int TotalHours
        {
            get => TotalDays * 24 + Hour;
        }

        public int TotalMinutes
        {
            get => TotalHours * 60 + Minutes;
        }
        public string YMD { get => $"{Year:0000} {Month:00} {Day:00}"; }
        public string YMDHM { get => $"{Year:0000} {Month:00} {Day:00} {Hour:00}:{Minutes:00}"; }

        public DayTime(int year, int month, int day = 1, int hour = 0, int minutes = 0)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minutes = minutes;
        }

        public DayTime AddMinutes(int minutes)
        {
            Minutes += minutes;
            while (Minutes > 60)
            {
                Minutes -= 60;
                AddHour(1);
            }
            return this;
        }
        public DayTime AddHour(int hours)
        {
            Hour += hours;
            while (Hour > 24)
            {
                Hour -= 24;
                AddDay(1);
            }
            return this;
        }

        private DayTime AddDay(int days)
        {
            Day += days;
            while (Day > 30)
            {
                Day -= 30;
                AddMonth(1);
            }
            return this;
        }

        private DayTime AddMonth(int months)
        {
            Month += months;
            while (Month > 12)
            {
                Month -= 12;
                AddYear(1);
            }
            return this;
        }

        private DayTime AddYear(int years)
        {
            Year += years;
            return this;
        }
    }
}
