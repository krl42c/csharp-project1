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

        [JsonInclude]
        public int daysInCharge;

        [JsonInclude]
        public Activity? activity { get; set; } // Nullable in case an employee doesn't have an activity

        public void loadIncrement() {
            if(activity != null)
                if(daysInCharge < activity.duration)
                    daysInCharge++;	
	    }
    }
}

