using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_NonDeterAndFiniteStateMachine.StateContollers
{
    public class AhoyController
    {
        public bool StateAhoyCheck(char currChar, string input, int counter)
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

                            if (currChar == 'y')
                            {
                                goto case 'y';
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

                            if (currChar == 'm')
                            {
                                goto case 'm';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 'm':
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

                            if (currChar == 't')
                            {
                                goto case 't';
                            }
                            else
                            {
                                goto default;
                            }
                        }
                    case 't':
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
