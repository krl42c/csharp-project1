using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Project1
{
    public class Programmer : Employee
    {
        [JsonConstructor]
        public Programmer(string firstName, string lastName, Activity activity) : base(firstName: firstName, lastName: lastName)
        {
            this.activity = activity;
            string[] months = {"0","1","2","3","4","5","6","7","8","9","10","11"};
            foreach(var month in months) {
                daysByMonth.Add(month, 0);
            }
        }

        [JsonInclude]
        public Dictionary<string, int> daysByMonth = new Dictionary<string, int>();

        [JsonInclude]
        public Activity activity { get; set; } 

        /* Increases days in charge for a specific month given by a DateTime */
        public void increaseDaysInCharge(DateTime date) {
            // Here i'm assuming that a programmer's days in charge cannot exceed the duration of the current activity.
            if(daysByMonth[date.Month.ToString()] < activity.duration)
                daysByMonth[date.Month.ToString()] += 1;
        }

        public int getDaysByMonth(DateTime date) {
            return daysByMonth[date.Month.ToString()];
        }
    }
}

