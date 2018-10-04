using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_NonDeterAndFiniteStateMachine.StateContollers
{
    public class AlohaController
    {
        public bool StateAlohaCheck(char currChar, string input, int counter)
        {
            int tempCounter = counter;
            bool done = false;
            currChar = input[++tempCounter];

            while (!done)
            {
                switch (currChar)
                {
                    case 'l':
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

                            if (currChar == 'h')
                            {
                                goto case 'h';
                            }
                            else
                            {
                                goto default;
                            }
                        }
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
