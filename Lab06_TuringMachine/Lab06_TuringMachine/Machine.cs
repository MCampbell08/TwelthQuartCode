using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_TuringMachine
{
    public class Machine
    {
        char[] tape;
        public void Run()
        {
            ReadAndParseInput();
        }
        private void Transition()
        {
            bool done = false;
            bool fail = false;
            bool goingRight = true;
            int counter = StartingLocation();
            char head = tape[counter];
            bool isTransitioning = false;

            foreach (char c in tape)
            {
                Console.Write(c);
            }
            Console.WriteLine();
            while (!done)
            {
                switch (head)
                {
                    case '1':
                        if (goingRight) {
                            if (tape[counter + 1] == '1' && !isTransitioning)
                            {
                                tape[counter] = '0';
                                head = tape[counter++];
                                isTransitioning = true;
                                goto case '1';
                            }
                            else if (tape[counter + 1] == '1' && isTransitioning)
                            {
                                head = tape[counter++];
                                goto case '1';
                            }
                            else if (tape[counter + 1] == '$' && !isTransitioning)
                            {
                                tape[counter] = '0';
                                head = tape[counter++];
                                isTransitioning = true;
                                goto case '$';
                            }
                            else if (tape[counter + 1] == '$' && isTransitioning)
                            {
                                head = tape[counter++];
                                goto case '$';
                            }
                            else if (tape[counter + 1] == '\0')
                            {
                                tape[counter + 1] = '1';
                                head = tape[counter--];
                                goingRight = false;
                            }
                        }
                        else
                        {
                            if (tape[counter - 1] == '1')
                            {
                                head = tape[counter--];
                                goto case '1';
                            }
                            else if (tape[counter - 1] == '$')
                            {
                                head = tape[counter--];
                                goto case '$';
                            }
                            else if (tape[counter - 1] == '0')
                            {
                                foreach (char c in tape)
                                {
                                    Console.Write(c);
                                }
                                Console.WriteLine();
                                isTransitioning = false;
                                goingRight = true;
                            }
                        }
                        break;
                    case '$':
                        if (goingRight)
                        {
                            if (tape[counter + 1] == '1')
                            {
                                head = tape[counter++];
                                goto case '1';
                            }
                            else if (tape[counter + 1] == '$')
                            {
                                if (tape[counter] == '1' && tape[counter - 1] == '0')
                                {
                                    goto case '1';
                                }
                                head = tape[counter++];
                                goto case '1';
                            }
                            else
                            {
                                done = true;
                                fail = true; 
                            }
                        }
                        else
                        {
                            if (tape[counter - 1] == '1')
                            {
                                head = tape[counter--];
                                goto case '1';
                            }
                            else if (tape[counter - 1] == '0')
                            {
                                done = true;
                                fail = false;
                            }
                            else
                            {
                                done = true;
                                fail = true;
                            }
                        }
                        break;
                    default:

                        break;
                }
            }
            if (fail)
            {
                Console.WriteLine("Break");
            }
            else
            {
                int amount = 0;
                foreach (char c in tape)
                {
                    Console.Write(c);
                    if (c == '1') {
                        amount++;
                    }
                }
                Console.WriteLine("\n" + amount);
                Console.WriteLine("Pass");
                
            }
        }
        private int StartingLocation()
        {
            int num = 0;
            foreach (char c in tape)
            {
                if (c == '1')
                {
                    return num;
                }
                num++;
            }
            return num;
        }
        private void ReadAndParseInput()
        {
            string input = "";
            while ((input = Console.ReadLine()) != "quit")
            {
                string[] numNParsed = input.Split('+');
                int[] numParsed = new int[2];
                if (Int32.TryParse(numNParsed[0], out numParsed[0]) && Int32.TryParse(numNParsed[1], out numParsed[1]))
                {
                    tape = new char[(numParsed[0] + numParsed[1]) * 2];
                    int counter = 1;
                    int temp = counter;
                    int endAmount = counter + numParsed[0] + numParsed[1] + 1;
                    while (counter < endAmount)
                    {
                        if (counter == (temp + numParsed[0]))
                        {
                            tape[counter] = '$';
                        }
                        else
                        {
                            tape[counter] = '1';
                        }
                        counter++;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid input");
                }
                Transition();
            }
        }
    }
}
