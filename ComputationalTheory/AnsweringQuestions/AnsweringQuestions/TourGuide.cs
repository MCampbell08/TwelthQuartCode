using AnsweringQuestions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnsweringQuestions
{
    public class TourGuide
    {
        List<Route> stack = new List<Route>();
        List<Location> locations = new List<Location>();
        bool continueTour = true;
        public void StartTour()
        {
            ParseEntries();
            if (continueTour)
            {
                BuildMap();
                while (continueTour) {
                    BuildTour();
                    Console.WriteLine("If you are finished, type \'finished\'. If not, type another tour.");
                }
            }
        }
        private void ParseEntries()
        {
            string[] input = new string[] {""};
            bool invalidInput = false;
            Route route = null;

            Console.WriteLine("Hello I'm your tour-guide Alice! Type \"Finished\" when you're done with telling me your map.");
            while (stack.Count <= 1 && input[0] != "finished")
            {
                while ((input = Console.ReadLine().Split(' '))[0] == "There" || input[0].ToLower() != "finished")
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
            if (input[0] == "finished")
            {
                continueTour = true;
            }
        }

        private void BuildMap()
        {
            Location existingLoc = null;
            foreach (Route r in stack)
            {
                existingLoc = locations.Find(x => x.Name == r.StartingPos);
                if (existingLoc == null)
                {
                    locations.Add(new Location() { Name = r.StartingPos });
                }
                if ((locations.Find(x => x.Name == r.StartingPos).Routes) == null)
                {
                    locations.Find(x => x.Name == r.StartingPos).Routes = new List<Route>();
                }
                locations.Find(x => x.Name == r.StartingPos).Routes.Add(r);

                existingLoc = locations.Find(x => x.Name == r.EndingPos);
                if (existingLoc == null)
                {
                    locations.Add(new Location() { Name = r.EndingPos });
                }
                if ((locations.Find(x => x.Name == r.EndingPos).Routes) == null)
                {
                    locations.Find(x => x.Name == r.EndingPos).Routes = new List<Route>();
                }
                locations.Find(x => x.Name == r.EndingPos).Routes.Add(r);
            }
        }

        private void BuildTour()
        {
            List<string> input = new List<string>(ParseTourRequest());
            Location existingLoc = null, checkingLoc = null;
            int distance = 0;
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    existingLoc = locations.Find(x => x.Name == input[i]);
                    checkingLoc = locations.Find(x => x.Name == input[j]);
                    if (existingLoc == null || checkingLoc == null)
                    {
                        input.Clear();
                        break;
                    }
                    else
                    {
                        Route r = existingLoc.Routes.Find(x => x.StartingPos == checkingLoc.Name || x.EndingPos == checkingLoc.Name);
                        if (r != null)
                        {
                            distance += Int32.Parse(r.Distance.Split("KM")[0]);
                            Console.WriteLine($"{r.StartingPos} to {r.EndingPos} ({r.Distance})");
                            break;
                        }
                        else
                        {
                            Location tempLocOne = null, tempLocTwo = null;
                            for (int k = 0; k < existingLoc.Routes.Count; k++)
                            {
                                tempLocOne = locations.Find(x => x.Name != existingLoc.Name && (x.Name == existingLoc.Routes[k].StartingPos || x.Name == existingLoc.Routes[k].EndingPos));
                                for (int l = 0; l < checkingLoc.Routes.Count; l++)
                                {
                                    tempLocTwo = locations.Find(x => x.Name != checkingLoc.Name && (x.Name == checkingLoc.Routes[l].StartingPos || x.Name == checkingLoc.Routes[l].EndingPos));
                                    if (tempLocOne.Name.Equals(tempLocTwo.Name))
                                    {
                                        List<Route> routes = tempLocOne.Routes.FindAll(x => (x.StartingPos == checkingLoc.Name || x.EndingPos == checkingLoc.Name) || (x.StartingPos == existingLoc.Name || x.EndingPos == existingLoc.Name));
                                        if (routes != null)
                                        {
                                            foreach (Route route in routes)
                                            {
                                                distance += Int32.Parse(route.Distance.Split("KM")[0]);
                                                Console.WriteLine($"{route.StartingPos} to {route.EndingPos} ({route.Distance})");
                                            }
                                            break;
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
            Console.WriteLine($"Total distance: {distance}");
        }

        private bool? Direction(Route r, string name)
        {
            if (r.StartingPos == name)
            {
                return true;
            }
            else if (r.EndingPos == name)
            {
                return false;
            }
            return null;
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
