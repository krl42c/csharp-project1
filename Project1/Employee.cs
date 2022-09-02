using System;
using System.Text.Json;
using System.Text.Json.Serialization;
    
namespace Project1
{
    public abstract class Employee
    {
        [JsonInclude]
	    public string firstName {get;set;}

        [JsonInclude]
        public string lastName {get;set;}

        [JsonInclude]
        public Activity? activity { get; set; } // Nullable in case an employee doesn't have an activity

        protected Employee(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        [JsonConstructor]
        protected Employee(string firstName, string lastName, Activity activity) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.activity = activity;
	    }
    }
}

                