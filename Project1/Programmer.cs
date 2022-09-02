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
        public Programmer(string firstName, string lastName, Activity activity) : base(firstName: firstName, lastName: lastName, activity: activity)
        {
        }

        [JsonInclude]
        public int daysInCharge;

        public void loadIncrement() {
            if(activity != null)
                if(daysInCharge < activity.duration)
                    daysInCharge++;	
	    }
    }
}

