using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.HelpClass
{
    public static class TimeSpanExtension
    {
        public static string GetTimeString(this TimeSpan timeSpan)
        {
            int days =timeSpan.Days;
            int hours=timeSpan.Hours;
            int min = timeSpan.Minutes;
            int sec = timeSpan.Seconds;
            //can use string builder
            string timeString = "";
            if (days > 0)
                timeString += days + ":";
            if (hours > 0)
                timeString += hours + ":";
            if (min > 0)
                timeString += min + ":";
            timeString += sec;
            return timeString;
        }
    }
}
