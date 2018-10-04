using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_NonDeterAndFiniteStateMachine.StateContollers
{
    public class ThanksController
    {
        public bool StateThanksCheck(char currChar, string input, int counter)
        {
            int tempCounter = counter;
            bool done = false;
            currChar = input[++tempCounter];

            while (!done)
            {
                switch (currChar)
                {
                    case 'h':
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
                            if (currChar == 'k')
                            {
                                goto case 'k';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'k':
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
                            else if (currChar == 's')
                            {
                                goto case 's';
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
                            if (currChar == 'y')
                            {
                                goto case 'y';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 's':
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
                    case 'o':
                        if (++tempCounter >= input.Length)
                        {
                            goto default;
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == 'u')
                            {
                                goto case 'u';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'u':
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
