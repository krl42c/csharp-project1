using System;
using System.Text.Json.Serialization;

namespace Project1
{
    public class Programmer : Employee
    {

        public Programmer(string firstName, string lastName) : base(firstName: firstName, lastName: lastName)
        {
        }

        [JsonConstructor]
        public Programmer(string firstName, string lastName, Activity activity) : base(firstName: firstName, lastName: lastName)
        {
            this.activity = activity;
        }

        /* This field is okay right now as programmers only have one activity assigned, altough 
	       if the number of activities increased at some point, i would approach this problem by using 
	       some kind of custom Map. */
        [JsonInclude]
        public int daysInCharge;

        [JsonInclude]
        public Activity? activity { get; set; } // Nullable in case a programmer isn't currently assigned an activity

        public void loadIncrement()
        {
            if (activity != null)
                if (daysInCharge < activity.duration)
                    daysInCharge++;
        }
    }
}

