using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project1
{
    public abstract class Employee
    {
        [JsonInclude]
        public string firstName { get; }

        [JsonInclude]
        public string lastName { get; }

        protected Employee(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}

