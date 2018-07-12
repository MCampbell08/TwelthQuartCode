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
            Thanks,
            NoneFound
        }

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
        private string[] howYouOptions = { "I'm good, Thanks for asking!", "I'm okay." };
        private string[] inputPossibilities = { "Hi", "Hello", "Howdy", "How are you?", "How are you doing?", "How do you do?", "Aloha", "Ahoy mate", "Thanks", "Thank you" };

        private List<string> possibilitiesChecked = new List<string>();
        private MachineState currState = MachineState.BeginningState;

        public void Run()
        {
            string input = "";
            while((input = Console.ReadLine()) != "quit" && input != "Quit")
            {
                if (StatePassed(input))
                {

                }
            }
        }

        private bool StatePassed(string input)
        {
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
