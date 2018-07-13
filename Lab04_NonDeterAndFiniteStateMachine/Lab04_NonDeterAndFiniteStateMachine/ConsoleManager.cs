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
                        Console.WriteLine(howYouOptions[random.Next(0, 2)]);
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
                                    if (StateHiCheck(currChar, input) || StateHelloCheck(currChar, input) || StateHowdyCheck(currChar, input)
                                         || StateHowDoCheck(currChar, input)|| StateHowCheck(currChar, input)  || StateHowAreCheck(currChar, input))
                                    {
                                        break;
                                    }
                                }
                                else if (currChar == 'T' || currChar == 't')
                                {

                                }
                                else if (currChar == 'A' || currChar == 'a')
                                {

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

        private bool StateHiCheck(char currChar, string input)
        {
            int tempCounter = counter;
            currChar = input[++tempCounter];

            switch (currChar)
            {
                case 'i':
                    inputMessage = InputMessage.Hi;
                    if (++tempCounter >= input.Length)
                    {
                        break;
                    }
                    currChar = input[tempCounter];
                    if (currChar != ' ')
                    {
                        inputMessage = InputMessage.NoneFound;
                        currState = MachineState.BeginningState;
                        return false;
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        private bool StateHelloCheck(char currChar, string input)
        {
            int tempCounter = counter;
            int duplicateAmount = 1;
            bool done = false;
            currChar = input[++tempCounter];

            while (!done)
            {
                switch (currChar)
                {
                    case 'e':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'l')
                            {
                                goto case 'l';
                            }
                        }
                        break;
                    case 'l':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'l' && duplicateAmount == 1)
                            {
                                ++duplicateAmount;
                                goto case 'l';
                            }
                            else if (currChar == 'o' && duplicateAmount == 2)
                            {
                                goto case 'o';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'o':
                        if (++tempCounter >= input.Length)
                        {
                            done = true;
                            inputMessage = InputMessage.Hello;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ' && input[tempCounter - 2] == 'l')
                            {
                                done = true;
                                inputMessage = InputMessage.Hello;
                            }
                            else
                            {
                                goto default;
                            }
                        }
                        break;
                    default:
                        inputMessage = InputMessage.NoneFound;
                        currState = MachineState.BeginningState;
                        return false;
                }
            }
            return true;
        }

        private bool StateHowdyCheck(char currChar, string input)
        {
            int tempCounter = counter;
            bool done = false;
            currChar = input[++tempCounter];

            while (!done)
            {
                switch (currChar)
                {
                    case 'o':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'w')
                            {
                                goto case 'w';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'd':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'y')
                            {
                                goto case 'y';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'w':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'd')
                            {
                                goto case 'd';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'y':
                        if (++tempCounter >= input.Length)
                        {
                            done = true;
                            inputMessage = InputMessage.Howdy;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                done = true;
                                inputMessage = InputMessage.Howdy;
                            }
                            else
                            {
                                goto default;
                            }
                        }
                        break;
                    default:
                        inputMessage = InputMessage.NoneFound;
                        currState = MachineState.BeginningState;
                        return false;
                }
            }
            return true;
        }

        private bool StateHowDoCheck(char currChar, string input)
        {
            int tempCounter = counter;
            bool done = false;
            currChar = input[++tempCounter];

            while (!done)
            {
                switch (currChar)
                {
                    case 'o':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'w')
                            {
                                goto case 'w';
                            }
                            else if (currChar == ' ')
                            {
                                goto case ' ';
                            }
                            else if (currChar == 'u')
                            {
                                goto case 'u';
                            }
                            else if (currChar == '?')
                            {
                                goto case '?';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'w':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                goto case ' ';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case ' ':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'd')
                            {
                                goto case 'd';
                            }
                            else if (currChar == 'y')
                            {
                                goto case 'y';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'd':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'o')
                            {
                                goto case 'o';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'y':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'o')
                            {
                                goto case 'o';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'u':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                goto case ' ';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case '?':
                        if (++tempCounter >= input.Length)
                        {
                            inputMessage = InputMessage.HowAreYou;
                            done = true;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                inputMessage = InputMessage.HowAreYou;
                                done = true;
                                break;
                            }
                            else
                            {
                                goto default;
                            }
                        }
                        break;
                    default:
                        inputMessage = InputMessage.NoneFound;
                        currState = MachineState.BeginningState;
                        return false;
                }
            }
            return true;
        }

        private bool StateHowCheck(char currChar, string input)
        {
            int tempCounter = counter;
            bool done = false;
            currChar = input[++tempCounter];

            while (!done)
            {
                switch (currChar)
                {
                    case 'o':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'w')
                            {
                                goto case 'w';
                            }
                            else if (currChar == 'u')
                            {
                                goto case 'u';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'w':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                goto case ' ';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case ' ':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'a')
                            {
                                goto case 'a';
                            }
                            else if (currChar == 'y')
                            {
                                goto case 'y';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'a':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'r')
                            {
                                goto case 'r';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'r':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'e')
                            {
                                goto case 'e';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'e':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                goto case ' ';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'u':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == '?')
                            {
                                goto case '?';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'y':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'o')
                            {
                                goto case 'o';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case '?':
                        if (++tempCounter >= input.Length)
                        {
                            inputMessage = InputMessage.HowAreYou;
                            done = true;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                inputMessage = InputMessage.HowAreYou;
                                done = true;
                            }
                            else
                            {
                                goto default;
                            }
                        }
                        break;
                    default:
                        inputMessage = InputMessage.NoneFound;
                        return false;
                }
            }
            return true;
        }

        private bool StateHowAreCheck(char currChar, string input)
        {

            int tempCounter = counter;
            bool done = false;
            currChar = input[++tempCounter];

            while (!done)
            {
                switch (currChar)
                {
                    case 'o':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'w')
                            {
                                goto case 'w';
                            }
                            else if (currChar == 'u')
                            {
                                goto case 'u';
                            }
                            else if (currChar == 'i')
                            {
                                goto case 'i';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'w':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                goto case ' ';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'u':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                goto case ' ';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'i':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'n')
                            {
                                goto case 'n';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'n':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'g')
                            {
                                goto case 'g';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case ' ':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'a')
                            {
                                goto case 'a';
                            }
                            else if (currChar == 'y')
                            {
                                goto case 'y';
                            }
                            else if (currChar == 'd')
                            {
                                goto case 'd';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'a':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'r')
                            {
                                goto case 'r';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'r':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'e')
                            {
                                goto case 'e';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'e':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                goto case ' ';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'y':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'o')
                            {
                                goto case 'o';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'd':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'o')
                            {
                                goto case 'o';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'g':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == '?')
                            {
                                goto case '?';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case '?':
                        if (++tempCounter >= input.Length)
                        {
                            inputMessage = InputMessage.HowAreYou;
                            done = true;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                inputMessage = InputMessage.HowAreYou;
                                done = true;
                            }
                            else
                            {
                                goto default;
                            }
                        }
                        break;
                    default:
                        inputMessage = InputMessage.HowAreYou;
                        return false;
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
