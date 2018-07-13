using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_NonDeterAndFiniteStateMachine
{
    public class HiController
    {
        public bool StateHiCheck(char currChar, string input, int counter)
        {
            int tempCounter = counter;
            currChar = input[++tempCounter];

            switch (currChar)
            {
                case 'i':
                    if (++tempCounter >= input.Length)
                    {
                        break;
                    }
                    currChar = input[tempCounter];
                    if (currChar != ' ')
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
