using Lab04_NonDeterAndFiniteStateMachine.StateContollers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_NonDeterAndFiniteStateMachine
{
    public class ConsoleManager
    {
        public enum InputMessage
        {
            Hi,
            Hello,
            Howdy,
            Ahoy,
            Aloha,
            HowAreYou,
            HowDoYou,
            HowAreYouDoing,
            Thanks,
            NoneFound
        }

        private HiController hiController = new HiController();
        private HelloController helloController = new HelloController();
        private HowdyController howdyController = new HowdyController();
        private HowAreYouContoller howController = new HowAreYouContoller();
        private ThanksController thanksController = new ThanksController();
        private AlohaController alohaController = new AlohaController();
        private AhoyController ahoyController = new AhoyController();

        public enum MachineState
        {
            BeginningState,
            TransitionState
        }
        
        private string[] hiOptions = { "Hi", "Sup?" };
        private string[] helloOptions = { "Hello", "How are you?" };
        private string howdyOption = "Howdy partner";
        private string[] alohaOptions = { "Aloha", "Surf's up!" };
        private string[] thanksOptions = { "You're welcome", "No, thank you!" };
        private string[] notFoundOptions = { "What great weather!", "Tell me about yourself", "What would you like to do?", "What makes you sad?" };
        private string[] ahoyOptions = { "Ahoy!", "Arrrrrrrr!" };
        private string[] howAreYouOptions = { "I'm good!", "I'm okay." };
        private string[] howAreYouDoingOptions = { "I'm doing good!", "I'm doing okay." };
        private string[] howDoOptions = { "I do good!", "I do okay." };
        private string[] inputPossibilities = { "Hi", "Hello", "Howdy", "How are you?", "How are you doing?", "How do you do?", "Aloha", "Ahoy mate", "Thanks", "Thank you" };

        private List<string> possibilitiesChecked = new List<string>();
        private MachineState currState = MachineState.BeginningState;
        private InputMessage inputMessage = InputMessage.NoneFound;
        private int counter = -1;

        public void Run()
        {
            string input = "";
            while((input = Console.ReadLine()) != "quit" && input != "Quit")
            {
                if (StatePassed(input))
                {
                    Random random = new Random();

                    if (inputMessage == InputMessage.Aloha)
                    {
                        Console.WriteLine(alohaOptions[random.Next(0, 2)]);
                    }
                    else if (inputMessage == InputMessage.Ahoy)
                    {
                        Console.WriteLine(ahoyOptions[random.Next(0, 2)]);
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
                    else if (inputMessage == InputMessage.HowAreYou)
                    {
                        Console.WriteLine(howAreYouOptions[random.Next(0, 2)]);
                    }
                    else if (inputMessage == InputMessage.HowAreYouDoing)
                    {
                        Console.WriteLine(howAreYouDoingOptions[random.Next(0, 2)]);
                    }
                    else if (inputMessage == InputMessage.HowDoYou)
                    {
                        Console.WriteLine(howDoOptions[random.Next(0, 2)]);
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
            bool done = false;
            char currChar = '\0';

            currState = MachineState.BeginningState;
            inputMessage = InputMessage.NoneFound;
            counter = -1;
            if (input != "") {
                while (!done)
                {
                    switch (currChar)
                    {
                        case '\0':
                        case ' ':
                            if (counter + 1 >= input.Length)
                            {
                                done = true;
                                break;
                            }
                            currChar = input[++counter];
                            if (currChar == 'H' || currChar == 'h' || currChar == 'A' || currChar == 'a' || currChar == 'T' || currChar == 't')
                            {
                                AddPossibilities(currChar);
                                currState = MachineState.TransitionState;
                            }
                            break;
                        default:
                            if (currState == MachineState.TransitionState)
                            {
                                if (currChar == 'H' || currChar == 'h')
                                {
                                    if (hiController.StateHiCheck(currChar, input, counter))
                                    {
                                        inputMessage = InputMessage.Hi;
                                    }
                                    else if (helloController.StateHelloCheck(currChar, input, counter))
                                    {
                                        inputMessage = InputMessage.Hello;
                                    }
                                    else if (howdyController.StateHowdyCheck(currChar, input, counter))
                                    {
                                        inputMessage = InputMessage.Howdy;
                                    }
                                    else if (howController.StateHowDoCheck(currChar, input, counter))
                                    {
                                        inputMessage = InputMessage.HowDoYou;
                                    }
                                    else if (howController.StateHowCheck(currChar, input, counter))
                                    {
                                        inputMessage = InputMessage.HowAreYou;
                                    }
                                    else if(howController.StateHowAreCheck(currChar, input, counter))
                                    {
                                        inputMessage = InputMessage.HowAreYouDoing;
                                    }
                                }
                                else if (currChar == 'T' || currChar == 't')
                                {
                                    if (thanksController.StateThanksCheck(currChar, input, counter))
                                    {
                                        inputMessage = InputMessage.Thanks;
                                    }
                                }
                                else if (currChar == 'A' || currChar == 'a')
                                {
                                    if (alohaController.StateAlohaCheck(currChar, input, counter))
                                    {
                                        inputMessage = InputMessage.Aloha;
                                    }
                                    else if (ahoyController.StateAhoyCheck(currChar, input, counter))
                                    {
                                        inputMessage = InputMessage.Ahoy;
                                    }
                                }
                                currState = MachineState.BeginningState;
                            }
                            if (++counter >= input.Length)
                            {
                                inputMessage = InputMessage.NoneFound;
                                done = true;
                            }
                            else
                            {
                                currChar = input[counter];
                            }
                            break;
                    }

                    if (inputMessage != InputMessage.NoneFound)
                    {
                        done = true;
                    }
                }
            }
            return true;
        }
       
        private void AddPossibilities(char currChar)
        {
            if (currChar == 'h' || currChar == 'H')
            {
                foreach(string s in inputPossibilities)
                {
                    if (s[0] == 'H')
                    {
                        possibilitiesChecked.Add(s);
                    }
                }
            }
            else if (currChar == 'a' || currChar == 'a')
            {

                foreach (string s in inputPossibilities)
                {
                    if (s[0] == 'A')
                    {
                        possibilitiesChecked.Add(s);
                    }
                }
            }
            else if (currChar == 't' || currChar == 'T')
            {

                foreach (string s in inputPossibilities)
                {
                    if (s[0] == 'T')
                    {
                        possibilitiesChecked.Add(s);
                    }
                }
            }
        }
    }
}
