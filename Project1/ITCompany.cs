// Report system:
// n Programmer in charge of ACTIVITY from START to FINISH (duration): total days spent (cost)
using System.Collections.Generic;
using System.Text.Json;
using System.Xml;

namespace Project1
{
    public class ITCompany
    {
        private static string filePath = "dataset.json";

        /* Retrieves saved data from a given file*/
        private static List<Team>? companyData(string path)
        {

            if (!File.Exists(path))
            {
                bool fileCreated = createDataFile();
                if (!fileCreated)
                    return null;
            }

            try
            {
                string jsonRawData;
                using (StreamReader streamReader = new StreamReader(filePath, encoding: System.Text.Encoding.UTF8))
                {
                    jsonRawData = streamReader.ReadToEnd();
                }

                List<Team>? listDes = JsonSerializer.Deserialize<List<Team>>(jsonRawData);
                return listDes;

            }
            catch (IOException ioException)
            {
                Console.WriteLine(ioException.StackTrace);
            }
            catch (JsonException jsonException)
            {
                Console.WriteLine(jsonException.StackTrace);
                Console.WriteLine(jsonException.Message);
            }
            return null;
        }

        private static bool createDataFile()
        {
            /* 
	        Boilerplate for creating a new data file.

	        This could've been done with json data hardcoded into a string,
	        however i've chosen this approach to make changes in the codebase easier to deal with. 

	        */

            Activity activiyTeam1 = new Activity("Debug", new DateTime(2022, 6, 10), new DateTime(2022, 10, 10));
            Activity activiyTeam2 = new Activity("Refactor", new DateTime(2022, 10, 10), new DateTime(2022, 10, 18));

            Team t1 = new Team(new List<Programmer>()
            {
                new Programmer("John", "Anthony", activiyTeam1),
                new Programmer("Zack", "Judy", activiyTeam1)
            }, Team.type.FULL_PAID, 1);

            Team t2 = new Team(new List<Programmer>()
            {
                new Programmer("Robert", "Martine", activiyTeam2),
                new Programmer("Julia", "Celina", activiyTeam2)
            }, Team.type.HALF_PAID, 2);

            List<Team> teamList = new List<Team> { t1, t2 };

            try
            {
                string jsonString = JsonSerializer.Serialize(teamList);
                File.WriteAllText(filePath, jsonString);
                return true;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            catch (JsonException j)
            {
                Console.WriteLine(j.StackTrace);
            }
            return false;
        }

        private static void updateSystem(List<Team> teamList)
        {
            foreach (var team in teamList)
            {
                foreach (var programmer in team.memberList)
                {
                    programmer.loadIncrement();
                }
            }
        }

        private static void saveSystem(List<Team> teamList)
        {
            string jsonString = JsonSerializer.Serialize(teamList);
            try
            {
                File.WriteAllText(filePath, jsonString);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public static void Main(string[] args)
        {
            // Initialization and load occurs here
            // companyData checks if we already have a dataset existing, if not it creates a new one using createDataFile()

            List<Team>? teamList = companyData(filePath);

            if (teamList != null)
            {
                // Update
                updateSystem(teamList);

                // Save
                saveSystem(teamList);

                // There's probably some cleaner way to do this, seems ok tho
                int programmerCount = 0;
                foreach (var team in teamList)
                {
                    foreach (var programmer in team.memberList)
                    {
                        programmerCount++;
                    }
                }

                Console.WriteLine("ITCompany\nITCompany is composed of " + teamList.Count + " teams and " + programmerCount + " programmers.");

                foreach (var team in teamList)
                {
                    Console.WriteLine("Project team: " + team.id); 
                    foreach (var programmer in team.memberList)
                    {

                       // Calculate total pay per programmer depending on team type
                        double totalPay = 0;
                        if (team.teamType == Team.type.FULL_PAID)
                            totalPay = programmer.daysInCharge * programmer.activity.payRate;
                        else
                            totalPay = programmer.daysInCharge * (programmer.activity.payRate / 2);

                        // Print everything
                        Console.WriteLine(programmer.lastName + ","
                        + programmer.firstName + ","
                        + "in charge of "
                        + programmer.activity.description
                        + " from " + programmer.activity.startDate.ToShortDateString()
                        + " to " + programmer.activity.endDate.Date.ToShortDateString()
                        + " (duration " + programmer.activity.duration + ")"
                        + ", this month: " + programmer.daysInCharge
                        + " (total cost " + totalPay + "$)"
                        );
                    }
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Couldn't load data. Exitting.");
            }
        }
    }
}