using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03_RegExpressAndFiniteStateMachine
{
    public class ConsoleManager
    {
        public enum InputMessage
        {
            Hi,
            Hello,
            Howdy,
            Aloha,
            Thanks,
            NoneFound
        }

        public enum State
        {
            BeginningState,
            TransitionState,
            SuccessFinishedState,
            FailedFinishedState
        }

        private string[] hiOptions = { "Hi", "Sup?" };
        private string[] helloOptions = { "Hello", "How are you?" };
        private string   howdyOption  = "Howdy partner";
        private string[] alohaOptions = { "Aloha", "Surf's up!" };
        private string[] thanksOptions = { "You're welcome", "No, thank you!" };
        private string[] notFoundOptions = { "What great weather!", "Tell me about yourself", "What would you like to do?", "What makes you sad?" };

        private InputMessage inputMessage = InputMessage.NoneFound;
        private State currState = State.BeginningState;

        public void Run()
        {
            string input = "";
            while ((input = Console.ReadLine()) != "quit" && input != "Quit")
            {
                if (StatePassed(input))
                {
                    Random random = new Random();

                    if (inputMessage == InputMessage.Aloha)
                    {
                        Console.WriteLine(alohaOptions[random.Next(0,2)]);
                    }
                    else if (inputMessage == InputMessage.Howdy)
                    {
                        Console.WriteLine(howdyOption);
                    }
                    else if (inputMessage == InputMessage.Hello)
                    {
                        Console.WriteLine(helloOptions[random.Next(0, 2)]);
                    }
                    else if (inputMessage == InputMessage.Hi)
                    {
                        Console.WriteLine(hiOptions[random.Next(0, 2)]);
                    }
                    else if (inputMessage == InputMessage.Thanks)
                    {
                        Console.WriteLine(thanksOptions[random.Next(0, 2)]);
                    }
                    else if (inputMessage == InputMessage.NoneFound)
                    {
                        Console.WriteLine(notFoundOptions[random.Next(0, 4)]);
                    }
                }
            }
        }

        private bool StatePassed(string input)
        {
            int counter = 0;
            int duplicateCounter = 1;
            char currChar = input[0];
            bool done = false;

            currState = State.BeginningState;
            inputMessage = InputMessage.NoneFound;

            while (!done)
            {
                switch (currState)
                {
                    case State.BeginningState:

                        switch (currChar) {
                            case 'A':
                            case 'a':
                                if (++counter >= input.Length)
                                {
                                    currState = State.FailedFinishedState;
                                    break;
                                }
                                currState = State.TransitionState;
                                currChar = input[counter];

                                if (currChar != 'l')
                                {
                                    currState = State.BeginningState;
                                }
                                break;
                            case 'H':
                            case 'h':
                                if (++counter >= input.Length)
                                {
                                    currState = State.FailedFinishedState;
                                    break;
                                }
                                currState = State.TransitionState;
                                currChar = input[counter];

                                if (currChar != 'i' && currChar != 'o' && currChar != 'e')
                                {
                                    currState = State.BeginningState;
                                }
                                if (currChar == 'i')
                                {
                                    currState = State.SuccessFinishedState;
                                    inputMessage = InputMessage.Hi;
                                }
                                break;
                            case 'T':
                            case 't':
                                if (++counter >= input.Length)
                                {
                                    currState = State.FailedFinishedState;
                                    break;
                                }
                                currState = State.TransitionState;
                                currChar = input[counter];

                                if (currChar != 'h')
                                {
                                    currState = State.BeginningState;
                                }
                                break;
                            default:
                                if (++counter >= input.Length)
                                {
                                    currState = State.FailedFinishedState;
                                    break;
                                }
                                currChar = input[counter];
                                break;
                        }
                        break;

                    case State.TransitionState:
                        switch (currChar)
                        {
                            case 'a':
                                if (++counter >= input.Length || currState == State.SuccessFinishedState)
                                {
                                    break;
                                }
                                else
                                {
                                    currChar = input[counter];
                                    if (currChar == 'n')
                                    {
                                        goto case 'n';
                                    }
                                }
                                break;
                            case 'd':
                                if (++counter >= input.Length || currState == State.SuccessFinishedState)
                                {
                                    break;
                                }
                                else
                                {
                                    currChar = input[counter];
                                    if (currChar == 'y')
                                    {
                                        currState = State.SuccessFinishedState;
                                        inputMessage = InputMessage.Howdy;
                                        goto case 'y';
                                    }
                                    else
                                    {
                                        currState = State.BeginningState;
                                    }
                                }
                                break;
                            case 'e':
                                if (++counter >= input.Length || currState == State.SuccessFinishedState)
                                {
                                    break;
                                }
                                else
                                {
                                    currChar = input[counter];
                                    if (currChar == 'l')
                                    {
                                        goto case 'l';
                                    }
                                    else
                                    {
                                        currState = State.BeginningState;
                                    }
                                }
                                break;
                            case 'h':
                                if (++counter >= input.Length || currState == State.SuccessFinishedState)
                                {
                                    break;
                                }
                                currChar = input[counter];
                                if (currChar == 'a')
                                {
                                    if ((currChar = input[counter -= 2]) == 't' || currChar == 'T')
                                    {
                                        currChar = input[counter += 2];
                                    }
                                    else
                                    {
                                        currState = State.SuccessFinishedState;
                                        inputMessage = InputMessage.Aloha;
                                    }
                                    goto case 'a';
                                }
                                else if (currChar == 'i')
                                {
                                    currState = State.BeginningState;
                                    currChar = input[--counter];
                                }
                                else if (currChar == 'e')
                                {
                                    goto case 'e';
                                }
                                else if (currChar == 'o')
                                {
                                    goto case 'o';
                                }
                                else
                                {
                                    currState = State.BeginningState;
                                }
                                break;
                            case 'i':
                                if (++counter >= input.Length || currState == State.SuccessFinishedState)
                                {
                                    break;
                                }
                                else
                                {
                                    currChar = input[counter];
                                }
                                break;
                            case 'k':

                                if (++counter >= input.Length || currState == State.SuccessFinishedState)
                                {
                                    break;
                                }
                                else
                                {
                                    currChar = input[counter];
                                    if (currChar == 's')
                                    {
                                        currState = State.SuccessFinishedState;
                                        inputMessage = InputMessage.Thanks;
                                        goto case 's';
                                    }
                                    else if (currChar == ' ')
                                    {
                                        goto case ' ';
                                    }
                                    else
                                    {
                                        currState = State.BeginningState;
                                    }
                                }
                                break;
                            case 'l':

                                if (++counter >= input.Length || currState == State.SuccessFinishedState)
                                {
                                    break;
                                }
                                else
                                {
                                    currChar = input[counter];
                                    if (currChar == 'o')
                                    {
                                        if (duplicateCounter > 1)
                                        {
                                            currState = State.SuccessFinishedState;
                                            inputMessage = InputMessage.Hello;
                                            break;
                                        }
                                        goto case 'o';
                                    }
                                    else if (currChar == 'l')
                                    {
                                        duplicateCounter++;
                                        goto case 'l';
                                    }
                                    else
                                    {
                                        currState = State.BeginningState;
                                    }
                                }
                                break;
                            case 'o':
                                if (++counter >= input.Length || currState == State.SuccessFinishedState)
                                {
                                    break;
                                }
                                currChar = input[counter];
                                if (currChar == 'h')
                                {
                                    goto case 'h';
                                }
                                else if (currChar == 'w')
                                {
                                    goto case 'w';
                                }
                                else if (currChar == 'u')
                                {
                                    currState = State.SuccessFinishedState;
                                    inputMessage = InputMessage.Thanks;
                                    goto case 'u';
                                }
                                else
                                {
                                    currState = State.BeginningState;
                                }
                                break;
                            case 'n':
                                if (++counter >= input.Length || currState == State.SuccessFinishedState)
                                {
                                    break;
                                }
                                currChar = input[counter];
                                if (currChar == 'k')
                                {
                                    goto case 'k';
                                }
                                else
                                {
                                    currState = State.BeginningState;
                                }
                                break;
                            case 's':
                                if (++counter >= input.Length || currState == State.SuccessFinishedState)
                                {
                                    break;
                                }
                                currChar = input[counter];
                                if (currChar == 'k')
                                {
                                    goto case 'k';
                                }
                                else
                                {
                                    currState = State.BeginningState;
                                }
                                break;
                            case 'u':
                                if (++counter >= input.Length || currState == State.SuccessFinishedState)
                                {
                                    break;
                                }
                                currChar = input[counter];
                                currState = State.BeginningState;
                                break;
                            case 'w':
                                currChar = input[++counter];
                                if (currChar == 'd')
                                {
                                    goto case 'd';
                                }
                                else
                                {
                                    currState = State.BeginningState;
                                }
                                break;
                            case 'y':
                                if (++counter >= input.Length)
                                {
                                    if (currState != State.SuccessFinishedState)
                                    {
                                        currState = State.FailedFinishedState;
                                    }
                                    break;
                                }
                                else
                                {
                                    currChar = input[counter];
                                    if (currChar == 'o')
                                    {
                                        goto case 'o';
                                    }
                                    else
                                    {
                                        currState = State.BeginningState;
                                    }
                                }
                                break;
                            case ' ':
                                if (++counter >= input.Length)
                                {
                                    break;
                                }
                                else
                                {
                                    currChar = input[counter];
                                    if (currChar == ' ')
                                    {
                                        goto case ' ';
                                    }
                                    else if (currChar == 'y')
                                    {
                                        goto case 'y';
                                    }
                                    else
                                    {
                                        currState = State.BeginningState;
                                    }
                                }
                                break;
                            default:
                                if (++counter >= input.Length)
                                {
                                    currState = State.FailedFinishedState;
                                    inputMessage = InputMessage.NoneFound;
                                }
                                else
                                {
                                    currState = State.BeginningState;
                                    currChar = input[counter];
                                }
                                break;
                        }
                        break;
                    case State.SuccessFinishedState:
                        done = true;
                        break;
                    case State.FailedFinishedState:
                        done = true;
                        break;
                }
            }
            return true;
        }
    }
}
