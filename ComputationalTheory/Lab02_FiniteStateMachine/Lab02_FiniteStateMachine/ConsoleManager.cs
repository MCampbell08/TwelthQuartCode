using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_FiniteStateMachine
{
    public class ConsoleManager
    {
        public enum State
        {
            BeginningState,
            FailedFinishedState,
            SuccessFinishedState
        }

        private string[] greetingOptions = { "Hello!", "Howdy!", "Greetings!" };
        private string[] nonGreetingOptions = { "I'm not sure what you mean...", "Umm, can you repeat that?" };
        private State currState = State.BeginningState;

        public void Run()
        {
            string input = "";
            int counter = 0;
            while ((input = Console.ReadLine().ToLower()) != "quit")
            {
                counter = 0;
                currState = State.BeginningState;
                char currChar = input[counter];
                bool accurateStates = true;

                switch (input[counter])
                {
                    case 'h':
                        if (input[1] == 'i')
                        {
                            goto case 'i';
                        }
                        accurateStates = false;
                        goto default;
                    case 'i':
                        if (input.Length <= 2)
                        {
                            currState = State.SuccessFinishedState;
                            break;
                        }
                        else
                        {
                            if (input[2] == ' ' || input[2] == '\0')
                            {
                                currState = State.SuccessFinishedState;
                                break;
                            }
                        }
                        accurateStates = false;
                        goto default;                        
                    default:
                        break;
                }

                while (currState != State.SuccessFinishedState && currState != State.FailedFinishedState)
                {
                    switch (currChar)
                    {
                        case ' ':
                            if (++counter >= input.Length)
                            {
                                if (!accurateStates)
                                {
                                    currState = State.FailedFinishedState;
                                }
                                break;
                            }
                            else
                            {
                                --counter;
                            }
                            if ((currChar = input[++counter]) == 'h')
                            {
                                accurateStates = true;
                                break;
                            }
                            accurateStates = false;
                            currChar = input[counter];
                            break;
                        case 'h':
                            if (++counter >= input.Length)
                            {
                                break;
                            }
                            else
                            {
                                --counter;
                            }
                            if ((currChar = input[++counter]) == 'i')
                            {
                                accurateStates = true;
                                break;
                            }
                            accurateStates = false;
                            currChar = input[counter];
                            break;
                        case 'i':
                            if (++counter >= input.Length)
                            {
                                if ((currChar = input[counter -= 3]) == ' ')
                                {
                                    currState = State.SuccessFinishedState;
                                    break;
                                }
                                else
                                {
                                    currState = State.FailedFinishedState;
                                    break;
                                }
                            }
                            else
                            {
                                --counter;
                            }
                            if ((currChar = input[++counter]) == ' ' && accurateStates)
                            {
                                if ((currChar = input[counter -= 3]) == ' ') {
                                    currState = State.SuccessFinishedState;
                                    break;
                                }
                            }
                            else
                            {
                                accurateStates = false;
                                if (++counter >= input.Length)
                                {
                                    currState = State.FailedFinishedState;
                                    break;
                                }
                            }
                            accurateStates = false;
                            currChar = input[++counter];
                            break;
                        default:
                            if (++counter >= input.Length)
                            {
                                currState = State.FailedFinishedState;
                                break;
                            }
                            else
                            {
                                --counter;
                                currChar = input[++counter];
                                if (currChar == 'h')
                                {
                                    accurateStates = false;
                                }
                            }
                            break;
                    }
                }
                if (currState == State.SuccessFinishedState && accurateStates)
                {
                    Random random = new Random();

                    Console.WriteLine(greetingOptions[random.Next(0, 3)]);
                }
                else if (currState == State.FailedFinishedState)
                {
                    Random random = new Random();

                    Console.WriteLine(nonGreetingOptions[random.Next(0, 2)]);
                }
            }
        }
    }
}
