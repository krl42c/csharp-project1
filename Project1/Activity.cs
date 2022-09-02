using System;
using System.Text.Json.Serialization;

namespace Project1
{
    public class Activity
    {
        public Activity(string description, int duration)
        {
            this.description = description;
            this.duration = duration;
        }

        [JsonConstructor]
        public Activity(string description, DateTime startDate, DateTime endDate) {
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;

            duration = (int)(endDate - startDate).TotalDays;
	    }

        [JsonInclude]
        public string description { get; set; }

        [JsonInclude]
        public int duration { get; set; }

        [JsonInclude] 
        public DateTime startDate;

        [JsonInclude]
        public DateTime endDate;
	 
    }
}

