using AnsweringQuestions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnsweringQuestions
{
    public class TourGuide
    {
        List<Route> stack = new List<Route>();
        bool continueTour = true;
        public void StartTour()
        {
            ParseMap();
            if (!continueTour)
            {
                BuildTour();
            }
        }
        private void ParseMap()
        {
            string[] input = new string[] {""};
            bool invalidInput = false;
            Route route = null;

            Console.WriteLine("Hello I'm your tour-guide Alice! Type \"Finished\" when you're done with telling me your map.");
            while (stack.Count <= 1 && input[0] != "finished")
            {
                while ((input = Console.ReadLine().Split(' '))[0] == "There" || input[0].ToLower() != "quit")
                {
                    invalidInput = false;
                    if (input.Length == 9) {
                        route = new Route();
                        if (Int32.TryParse(input[3].Split("KM")[0], out int result))
                        {
                            route.Distance = $"{result}KM";
                        }
                        else
                        {
                            invalidInput = true;
                        }
                        route.StartingPos = input[6];
                        route.EndingPos = input[8];
                    }
                    else
                    {
                        invalidInput = true;
                    }
                    if (invalidInput)
                    {
                        Console.WriteLine("Invalid Entry.");
                        Console.WriteLine("Example of what you can put: \"There is a 300KM road from \'ThisPlace\' to \'ThatPlace\'\".");
                    }
                    else
                    {
                        if (RouteExists(route))
                        {
                            Console.WriteLine("This route exists, try again.");
                        }
                        else
                        {
                            stack.Add(route);
                            Console.WriteLine("Ok");
                        }
                    }
                }
                if (stack.Count == 0)
                {
                    Console.WriteLine("You have not told me any routes. Please enter some.");
                }
                else if (stack.Count == 1)
                {
                    Console.WriteLine("You need to enter more than one route. Please enter atleast one more.");
                }
            }
            if (input[0] == "quit")
            {
                continueTour = false;
            }
        }

        private void BuildTour()
        {
            bool done = false;
            bool validEntry = true;
            int distance = 0;
            string currPos = "";
            while (!done)
            {
                distance = 0;
                string[] input = ParseTourRequest();
                currPos = input[0];

                if (ValidLoc(currPos)) {

                    for(int i = 1; i < input.Length; i++)
                    {
                        if (!ValidLoc(input[1]))
                        {
                            validEntry = false;
                        }
                        else
                        {
                            distance += GetDistanceBetweenLocs(currPos, input[i]);
                        }
                    }
                }
            }
        }

        private int GetDistanceBetweenLocs(string start, string end)
        {
            int num = 0;
            List<Route> routesChecked = new List<Route>();

            foreach (Route r in stack)
            {
                if (start == r.StartingPos)
                {
                    if (r.EndingPos != end)
                    {
                        routesChecked.Add(r);
                        num = DistanceAccumulation(routesChecked, end);
                    }
                    else
                    {
                        return Int32.Parse(r.Distance.Split("KM")[0]);
                    }
                }
                else if (end == r.StartingPos)
                {

                }
            }

            return num;
        }

        private int DistanceAccumulation(List<Route> routesChecked, string end)
        {
            int num = 0;

            foreach (Route r in stack)
            {
                if (!routesChecked.Contains(r))
                {
                    if (r.EndingPos == end)
                    {
                        if (r.StartingPos == routesChecked[routesChecked.Count - 1].EndingPos)
                        {
                            num = Int32.Parse(r.Distance.Split("KM")[0]);
                        }
                        else
                        {
                            routesChecked.Add(r);
                            num += DistanceAccumulation(routesChecked, end);
                        }
                    }
                }
            }

            return num;
        }

        private bool ValidLoc(string loc)
        {
            foreach (Route r in stack)
            {
                if (r.StartingPos.Equals(loc) || r.EndingPos.Equals(loc))
                {
                    return true;
                }
            }

            return false;
        }

        private string[] ParseTourRequest()
        {
            string[] input = Console.ReadLine().Split(',');

            input[0] = input[0].Split("Build a tour connecting")[1];
            if (input[input.Length - 1].Contains("and"))
            {
                input[input.Length - 1] = input[input.Length - 1].Split(" and")[1];
            }
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Trim();
            }
            return input;
        }

        private bool RouteExists(Route route)
        {
            foreach (Route r in stack)
            {
                if (r.StartingPos.Equals(route.StartingPos) && r.EndingPos.Equals(route.EndingPos) && r.Distance == route.Distance)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
