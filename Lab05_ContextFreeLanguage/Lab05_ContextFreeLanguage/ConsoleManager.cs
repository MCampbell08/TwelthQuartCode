using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05_ContextFreeLanguage
{
    public class ConsoleManager
    {
        private static Stack<Object> stack = new Stack<object>();
        private string[] acceptableArticles = new string[] { "a", "the", "an" };
        private string[] acceptableNouns = new string[] { "dog", "cat", "squirrel" };
        private string[] acceptableVerbs = new string[] { "ran", "bites", "scurries", "sat" };
        private string[] acceptablePronouns = new string[] { "he", "she", "him", "her" };
        private string[] acceptableAdjectives = new string[] { "happily", "quickly", "good", "bad" };
        private string[] acceptablePrepostions = new string[] { "with", "from", "to" };
        private string[] acceptableVerbPhrases = new string[] { "Verb", "Verb Adjective", "Verb NounPhrase", "Verb Adjective NounPhrase", "Verb Adjective ProunounPhrase" };
        private string[] acceptableNounPhrases = new string[] { "Article Noun", "Article Adjective Noun", "Article Noun Preposition NounPhrase", "NounPhrase Preposition NounPhrase" };
        private string[] acceptablePronounPhrases = new string[] { "Pronoun", "Preposition Pronoun" };
        private string[] acceptableSentences = new string[] { "NounPhrase VerbPhrase", "PronounPhrase VerbPhrase" };

        private string[] inputStream;
        private TreeSystem system = new TreeSystem();
        
        public void Run()
        {
            while((inputStream = Console.ReadLine().Split(' ')) != new string[] { "quit" })
            {

            }
            
        }

        private void 
    }
}
