using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeighRMonitoring.Helpers
{
    public static class DateHelper
    {
        public static DateTime StartOfDay(DateTime date)
        {

            TimeSpan time = new TimeSpan(0, 0, 0, 0);
            DateTime dateTime = date.Date.Add(time);

            return dateTime;
        }

        public static DateTime EndOfDay(DateTime date)
        {
            TimeSpan time = new TimeSpan(0, 23, 59, 0);
            DateTime dateTime = date.Date.Add(time);

            return dateTime;
        }

        public static DateTime StartDate(int option)
        {
            DateTime date = DateTime.Now;
            switch (option)
            {
                case 1:
                    date = date.AddDays(-1); //Previous Day
                    break;
                case 2:
                    date = date.AddDays(-7);  //Last 7 Days
                    break;
                case 3:
                    date = date.AddDays(-30); //Last 30 Days
                    break;
                case 4:
                    date = date.AddMonths(-6); //Last 6 Months
                    break;
                default:
                    break;
            }
        
            return date;
        }

        public static DateTime EndDate(int option)
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);

            return date;
        }
    }
}