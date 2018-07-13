using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_NonDeterAndFiniteStateMachine.StateContollers
{
    public class HowdyController
    {
        public bool StateHowdyCheck(char currChar, string input, int counter)
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
