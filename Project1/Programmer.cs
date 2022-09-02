using System;
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
        public int daysInCharge;

        [JsonInclude]
        public Activity activity { get; set; } 

        public void loadIncrement()
        {
            // Here i'm assuming that a programmer's days in charge cannot exceed the duration of the current activity.
            if (activity != null)
                if (daysInCharge < activity.duration)
                    daysInCharge++;
        }
    }
}

