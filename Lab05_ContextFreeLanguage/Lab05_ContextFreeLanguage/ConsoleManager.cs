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
        private List<string> acceptablePronounPhrases = new List<string> { "Pronoun", "Preposition Pronoun" };
        private List<string> acceptableSentences = new List<string> { "NounPhrase VerbPhrase", "PronounPhrase VerbPhrase" };

        private string[] inputStream;
        private string stackMatch;
        private int counter;
        private TreeSystem system = new TreeSystem();
        
        public void Run()
        {
            while((inputStream = Console.ReadLine().Split(' ')) != new string[] { "quit" })
            {
                foreach (string word in inputStream)
                {
                    if (CanAddToStack(word))
                    {
                        bool done = false;
                        while (!done)
                        {
                            if (CanReplaceTopStack())
                            {
                                if ((stack.Contains("NounPhrase") && stack.Contains("VerbPhrase")) 
                                    || (stack.Contains("PronounPhrase") && stack.Contains("VerbPhrase")))
                                {
                                    PopStackWithAmount(2);
                                    stack.Push("Sentence");
                                }
                                else if (stack.Contains("Article") && stack.Contains("Noun") && inputStream[counter] != "with")
                                {
                                    PopStackWithAmount(2);
                                    stack.Push("NounPhrase");
                                }
                                else if ((stack.Contains("Article") && stack.Contains("Adjective") && stack.Contains("Noun") && inputStream[counter] != "with") 
                                        || (stack.Contains("Article") && stack.Contains("Noun") && stack.Contains("Preposition")))
                                {
                                    PopStackWithAmount(3);
                                    stack.Push("NounPhrase");
                                }
                                else if (stack.Contains("Article") && stack.Contains("Adjective") && stack.Contains("Noun") && stack.Contains("Preposition"))
                                {
                                    PopStackWithAmount(4);
                                    stack.Push("NounPhrase");
                                }
                                else if (stack.Contains("Verb") && (inputStream[counter] != "a" || inputStream[counter] != "the" || inputStream[counter] != "an" || inputStream[counter] != "dog" || inputStream[counter] != "cat" || inputStream[counter] != "squirrel" || inputStream[counter] != "boy" || inputStream[counter] != "girl"))
                                {
                                    PopStackWithAmount(1);
                                    stack.Push("VerbPhrase");
                                }
                                else if ((stack.Contains("Verb") && stack.Contains("NounPhrase")) || (stack.Contains("Verb") && stack.Contains("Adjective")) || (stack.Contains("Verb") && stack.Contains("PronounPhrase")))
                                {
                                    PopStackWithAmount(2);
                                    stack.Push("VerbPhrase");
                                }
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
        private bool CanReplaceTopStack()
        {
            List<List<string>> collection = new List<List<string>>
            {
                acceptableAdjectives, acceptableArticles, acceptableNounPhrases,
                acceptableNouns, acceptablePrepostions, acceptablePronounPhrases,
                acceptablePronouns, acceptableSentences, acceptableVerbPhrases, acceptableVerbs
            };

            foreach (List<string> list in collection)
            {
                foreach (string option in list)
                {
                    if (option == (string)stack.Peek())
                    {
                        stackMatch = option;
                        return true;
                    }
                }
            }

            return false;
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
