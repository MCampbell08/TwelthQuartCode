using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05_ContextFreeLanguage
{
    public class ConsoleManager
    {
        private static Stack<Object> stack = new Stack<object>();
        private List<string> acceptableArticles = new List<string> { "a", "the", "an" };
        private List<string> acceptableNouns = new List<string> { "dog", "cat", "squirrel", "girl", "boy" };
        private List<string> acceptableVerbs = new List<string> { "ran", "bites", "scurries", "sat" };
        private List<string> acceptablePronouns = new List<string> { "he", "she", "him", "her" };
        private List<string> acceptableAdjectives = new List<string> { "happily", "quickly", "good", "bad" };
        private List<string> acceptablePrepostions = new List<string> { "with", "from", "to" };
        private List<string> acceptableVerbPhrases = new List<string> { "Verb", "Verb Adjective", "Verb NounPhrase", "Verb ProunounPhrase" };
        private List<string> acceptableNounPhrases = new List<string> { "Article Noun", "Article Adjective Noun", "Article Noun Preposition NounPhrase"};
        private List<string> acceptablePronounPhrases = new List<string> { "Preposition Pronoun" };
        private List<string> acceptableSentences = new List<string> { "NounPhrase VerbPhrase", "PronounPhrase VerbPhrase" };

        private string[] inputStream;
        private int counter;
        private TreeSystem system = new TreeSystem();
        
        public void Run()
        {
            while((inputStream = Console.ReadLine().Split(' ')) != new string[] { "quit" })
            {
                stack.Clear();
                counter = 0;
                foreach (string word in inputStream)
                {
                    if (CanAddToStack(word))
                    {
                        bool done = false;
                        while (!done)
                        {
                            if ((stack.Contains("NounPhrase") && stack.Contains("VerbPhrase") && counter >= inputStream.Length && stack.Count == 2)
                                || (stack.Contains("PronounPhrase") && stack.Contains("VerbPhrase") && counter >= inputStream.Length && stack.Count == 2))
                            {
                                PopStackWithAmount(2);
                                stack.Push("Sentence");
                            }
                            else if (stack.Contains("a") || stack.Contains("the") || stack.Contains("an"))
                            {
                                PopStackWithAmount(1);
                                stack.Push("Article");
                            }
                            else if (stack.Contains("dog") || stack.Contains("cat") || stack.Contains("squirrel") || stack.Contains("girl") || stack.Contains("boy"))
                            {
                                PopStackWithAmount(1);
                                stack.Push("Noun");
                            }
                            else if (stack.Contains("ran") || stack.Contains("bites") || stack.Contains("scurries") || stack.Contains("sat"))
                            {
                                PopStackWithAmount(1);
                                stack.Push("Verb");
                            }
                            else if (stack.Contains("with") || stack.Contains("from") || stack.Contains("to"))
                            {
                                PopStackWithAmount(1);
                                stack.Push("Preposition");
                            }
                            else if (stack.Contains("he") || stack.Contains("she") || stack.Contains("him") || stack.Contains("her"))
                            {
                                PopStackWithAmount(1);
                                stack.Push("Pronoun");
                            }
                            else if (stack.Contains("happily") || stack.Contains("quickly") || stack.Contains("good") || stack.Contains("bad"))
                            {
                                PopStackWithAmount(1);
                                stack.Push("Adjective");
                            }
                            else if (stack.Contains("Article") && stack.Contains("Noun") && stack.Contains("Preposition"))
                            {
                                PopStackWithAmount(3);
                                stack.Push("NounPhrase");
                            }
                            else if (stack.Contains("Article") && stack.Contains("Adjective") && stack.Contains("Noun"))
                            {
                                if (counter <= inputStream.Length)
                                {
                                    if (inputStream[counter] != "with")
                                    {
                                        PopStackWithAmount(3);
                                        stack.Push("NounPhrase");
                                    }
                                }
                            }
                            else if (stack.Contains("Article") && stack.Contains("Noun"))
                            {
                                if (counter >= inputStream.Length)
                                {
                                    PopStackWithAmount(2);
                                    stack.Push("NounPhrase");
                                }
                                else
                                {
                                    if (inputStream[counter] != "with")
                                    {
                                        PopStackWithAmount(2);
                                        stack.Push("NounPhrase");
                                    }
                                    else
                                    {
                                        done = true;
                                    }
                                }
                            }
                            else if (stack.Contains("Article") && stack.Contains("Adjective") && stack.Contains("Noun") && stack.Contains("Preposition"))
                            {
                                PopStackWithAmount(4);
                                stack.Push("NounPhrase");
                            }
                            else if (stack.Contains("Verb") && stack.Contains("Adjective"))
                            {
                                PopStackWithAmount(2);
                                stack.Push("VerbPhrase");
                            }
                            else if (stack.Contains("Verb") && stack.Contains("PronounPhrase"))
                            {
                                PopStackWithAmount(2);
                                stack.Push("VerbPhrase");
                            }
                            else if (stack.Contains("VerbPhrase") && (string)stack.Peek() == "NounPhrase")
                            {
                                PopStackWithAmount(2);
                                stack.Push("VerbPhrase");
                            }
                            else if (stack.Contains("Verb"))
                            {
                                if (counter <= inputStream.Length)
                                {
                                    if (counter == inputStream.Length)
                                    {
                                        PopStackWithAmount(1);
                                        stack.Push("VerbPhrase");
                                    }
                                    else if (inputStream[counter] != "a" && inputStream[counter] != "the" && inputStream[counter] != "an"
                                        && inputStream[counter] != "dog" && inputStream[counter] != "cat" && inputStream[counter] != "squirrel" && inputStream[counter] != "boy" && inputStream[counter] != "girl"
                                        && inputStream[counter] == "quickly" && inputStream[counter] == "happily")
                                    {
                                        PopStackWithAmount(1);
                                        stack.Push("VerbPhrase");
                                    }
                                    else if (inputStream[counter] == "quickly" || inputStream[counter] == "happily")
                                    {
                                        done = true;
                                    }
                                    else if (inputStream[counter] == "with")
                                    {
                                        done = true;
                                    }
                                }
                            }
                            else if (stack.Contains("Verb") && stack.Contains("NounPhrase"))
                            {
                                if (inputStream[counter] != "with")
                                {
                                    PopStackWithAmount(2);
                                    stack.Push("VerbPhrase");
                                }
                                else
                                {
                                    done = true;
                                }
                            }
                            else if (stack.Contains("Preposition") && stack.Contains("Pronoun"))
                            {
                                PopStackWithAmount(2);
                                stack.Push("PronounPhrase");
                            }
                            else
                            {
                                done = true;
                            }
                        }
                    }
                    else
                    {
                        PrintMessage();
                    }
                }
                if ((string)stack.Peek() != "Sentence")
                {
                    PrintMessage();
                }
                else
                {
                    Console.WriteLine("Pass");
                }
            }
        }

        private bool CanAddToStack(string input)
        {
            if (acceptableArticles.Contains(input))
            {
                stack.Push(input);
            }
            else if (acceptableNouns.Contains(input))
            {
                stack.Push(input);
            }
            else if (acceptableVerbs.Contains(input))
            {
                stack.Push(input);
            }
            else if (acceptablePronouns.Contains(input))
            {
                stack.Push(input);
            }
            else if (acceptableAdjectives.Contains(input))
            {
                stack.Push(input);
            }
            else if (acceptablePrepostions.Contains(input))
            {
                stack.Push(input);
            }
            else if (acceptableVerbPhrases.Contains(input))
            {
                stack.Push(input);
            }
            else if (acceptableNounPhrases.Contains(input))
            {
                stack.Push(input);
            }
            else if (acceptablePronounPhrases.Contains(input))
            {
                stack.Push(input);
            }
            else if (acceptableSentences.Contains(input))
            {
                stack.Push(input);
            }
            else
            {
                return false;
            }
            counter++;
            return true;
        }
        private void PrintMessage()
        {
            Console.WriteLine("I'm not sure I follow you");
        }
        private void PopStackWithAmount(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                stack.Pop();
            }
        }
    }
}
