using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_NonDeterAndFiniteStateMachine.StateContollers
{
    public class HowAreYouContoller
    {
        public bool StateHowDoCheck(char currChar, string input, int counter)
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
                            done = true;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
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
                        return false;
                }
            }
            return true;
        }

        public bool StateHowCheck(char currChar, string input, int counter)
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
                            done = true;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                done = true;
                            }
                            else
                            {
                                goto default;
                            }
                        }
                        break;
                    default:
                        return false;
                }
            }
            return true;
        }

        public bool StateHowAreCheck(char currChar, string input, int counter)
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
                            done = true;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ')
                            {
                                done = true;
                            }
                            else
                            {
                                goto default;
                            }
                        }
                        break;
                    default:
                        return false;
                }
            }

            return true;
        }

    }
}
