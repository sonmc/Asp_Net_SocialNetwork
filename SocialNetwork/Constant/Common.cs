using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SocialNetwork.Constant
{
    public class Common
    {
        public static int ADMIN_ROLE = 0;
        public static int USER_ROLE = 1;
        public static int IMAGE_TYPE = 0;
        public static int TEXT_TYPE = 1;
        public static int SECOND = 1;
        public static int MINUTE = 60 * SECOND;
        public static int HOUR = 60 * MINUTE;
        public static int DAY = 24 * HOUR;
        public static int MONTH = 30 * DAY;
        public static string GetTime (DateTime myDate)
        { 
            var ts = new TimeSpan(DateTime.Now.Ticks - myDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}