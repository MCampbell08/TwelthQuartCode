using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05_ContextFreeLanguage
{
    public class ConsoleManager
    {
        private static Stack<Object> stack = new Stack<object>();
        private List<string> acceptableArticles = new List<string> { "a", "the", "an" };
        private List<string> acceptableNouns = new List<string> { "dog", "cat", "squirrel" };
        private List<string> acceptableVerbs = new List<string> { "ran", "bites", "scurries", "sat" };
        private List<string> acceptablePronouns = new List<string> { "he", "she", "him", "her" };
        private List<string> acceptableAdjectives = new List<string> { "happily", "quickly", "good", "bad" };
        private List<string> acceptablePrepostions = new List<string> { "with", "from", "to" };
        private List<string> acceptableVerbPhrases = new List<string> { "Verb", "Verb Adjective", "Verb NounPhrase", "Verb Adjective NounPhrase", "Verb Adjective ProunounPhrase" };
        private List<string> acceptableNounPhrases = new List<string> { "Article Noun", "Article Adjective Noun", "Article Noun Preposition NounPhrase", "NounPhrase Preposition NounPhrase" };
        private List<string> acceptablePronounPhrases = new List<string> { "Pronoun", "Preposition Pronoun" };
        private List<string> acceptableSentences = new List<string> { "NounPhrase VerbPhrase", "PronounPhrase VerbPhrase" };

        private string[] inputStream;
        private TreeSystem system = new TreeSystem();
        
        public void Run()
        {
            while((inputStream = Console.ReadLine().Split(' ')) != new string[] { "quit" })
            {
                foreach (string word in inputStream)
                {
                    if (CanAddToStack(word))
                    {

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
            return true;
        }
    }
}
