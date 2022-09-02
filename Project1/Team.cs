using System;
using System.Collections;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Project1
{
    public class Team
    {
        [JsonInclude]
        public int id { get; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum type
        {
            FULL_PAID,
            HALF_PAID
        }

        [JsonInclude]
        public type teamType;

        public List<Programmer> memberList { get; set; }

        public Team(List<Programmer> memberList, type teamType, int id)
        {
            this.memberList = memberList;
            this.teamType = teamType;
            this.id = id;
        }
    }

}

