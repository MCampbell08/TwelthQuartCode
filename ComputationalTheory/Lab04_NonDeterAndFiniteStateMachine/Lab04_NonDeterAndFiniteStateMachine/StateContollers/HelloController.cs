using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_NonDeterAndFiniteStateMachine
{
    public class HelloController
    {
        public  bool StateHelloCheck(char currChar, string input, int counter)
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
                            else
                            {
                                goto default;
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
                        }
                        else
                        {
                            currChar = input[tempCounter];
                            if (currChar == ' ' && input[tempCounter - 2] == 'l')
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
