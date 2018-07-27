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
            while (!done)
            {
                string[] input = ParseTourRequest();
                //Create other Routes based off of information given to you
                
                

                //Go through every route in the stack and see if you can make the tour. Failing would mean halting.
            }
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
