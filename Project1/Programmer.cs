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
        }

        /* This field is okay right now as programmers only have one activity assigned, altough 
	    if the number of activities increased at some point, i would approach this problem by using 
	    some kind of custom Map. eg: \Dictionary<Activity, int> mapActivityDays */
        [JsonInclude]
        public int daysInCharge; //TODO: How do we calculte this by month?

        [JsonInclude]
        public Dictionary<string, int> daysByMonth = new Dictionary<string, int>();

        [JsonInclude]
        public Activity activity { get; set; } 
       
        public void loadIncrement()
        {
            // Here i'm assuming that a programmer's days in charge cannot exceed the duration of the current activity.
            if (activity != null)
                if (daysInCharge < activity.duration)
                    daysInCharge++;
        }
        public void initializeMonth() {

            string[] months = {"0","1","2","3","4","5","6","7","8","9","10","11"};
            foreach(var month in months) {
                daysByMonth.Add(month, 0);
            }
        }

        /* Increases days in charge for a specific month given by a DateTime */
        public void increaseDaysInCharge(DateTime date) {
            daysByMonth[date.Month.ToString()] += 1;
        }

        public int getDaysByMonth(DateTime date) {
            return daysByMonth[date.Month.ToString()];
        }
    }
}

