using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    internal static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();
        private static List<string> LogActivities = new List<string>();

        public static void LogActivity(string activity, string username)
        {
            string activityLine = DateTime.Now + ";"
                                  + username + ";"
                                  + LoginValidation.currentUserRole + ";"
                                  + activity;
            currentSessionActivities.Add(activityLine);
            if (File.Exists("log.txt"))
            {
                File.AppendAllText("log.txt", activityLine + Environment.NewLine);
            }

        }

        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();
            return filteredActivities;
        }

        public static IEnumerable<string> GetLogActivities()
        {
            ReadLogActivities();
            return LogActivities;
        }

        private static void ReadLogActivities()
        {
            if (File.Exists("log.txt"))
            {
                LogActivities=File.ReadAllLines("log.txt").ToList();
            }
        }


    }
}
