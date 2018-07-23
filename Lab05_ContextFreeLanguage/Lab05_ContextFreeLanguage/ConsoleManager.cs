using Lab05_ContextFreeLanguage.DataStructure;
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
        private List<string> acceptableVerbs = new List<string> { "ran", "bites", "scurries", "sat", "chased" };
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
        private List<Node> nodeCollection = new List<Node>();
        
        public void Run()
        {
            bool inputFailed = false;
            while((inputStream = Console.ReadLine().Split(' ')) != new string[] { "quit" })
            {
                stack.Clear();
                nodeCollection.Clear();
                counter = 0;
                inputFailed = false;
                foreach (string word in inputStream)
                {
                    if (CanAddToStack(word) && !inputFailed)
                    {
                        bool done = false;
                        while (!done)
                        {
                            if (stack.Contains("NounPhrase") && stack.Contains("VerbPhrase") && counter >= inputStream.Length && stack.Count == 2
                                || (stack.Contains("Pronoun") && stack.Contains("VerbPhrase") && counter >= inputStream.Length && stack.Count == 2)
                                || (stack.Contains("PronounPhrase") && stack.Contains("VerbPhrase") && counter >= inputStream.Length && stack.Count == 2))
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "NounPhrase" || (string)x.Value == "VerbPhrase" || (string)x.Value == "Pronoun" || (string)x.Value == "VerbPhrase" || (string)x.Value == "PronounPhrase" || (string)x.Value == "VerbPhrase");
                                var parentNode = new Node() { Nodes = list };
                                PopStackWithAmount(2);
                                stack.Push("Sentence");
                                parentNode.Value = stack.Peek();
                                foreach (Node n in list)
                                {
                                    n.Parent = parentNode;
                                }
                                nodeCollection.Add(parentNode);
                            }
                            else if (stack.Contains("a") || stack.Contains("the") || stack.Contains("an"))
                            {
                                nodeCollection.Add(new Node() { Value = stack.Peek() });
                                PopStackWithAmount(1);
                                stack.Push("Article");
                                done = true;
                                nodeCollection.Add(new Node() { Value = stack.Peek(), Nodes = new List<Node>() { nodeCollection.Find(x => x.Value.Equals("a") || x.Value.Equals("an") || x.Value.Equals("the")) } });
                                nodeCollection.RemoveAll(x => x.Value.Equals("a") || x.Value.Equals("an") || x.Value.Equals("the"));
                            }
                            else if (stack.Contains("dog") || stack.Contains("cat") || stack.Contains("squirrel") || stack.Contains("girl") || stack.Contains("boy"))
                            {
                                nodeCollection.Add(new Node() { Value = stack.Peek() });
                                PopStackWithAmount(1);
                                stack.Push("Noun");
                                nodeCollection.Add(new Node() { Value = stack.Peek(), Nodes = new List<Node>() { nodeCollection.Find(x => x.Value.Equals("dog") || x.Value.Equals("cat") || x.Value.Equals("squirrel") || x.Value.Equals("girl") || x.Value.Equals("boy")) } });
                                nodeCollection.RemoveAll(x => x.Value.Equals("dog") || x.Value.Equals("cat") || x.Value.Equals("squirrel") || x.Value.Equals("girl") || x.Value.Equals("boy"));
                            }
                            else if (stack.Contains("ran") || stack.Contains("bites") || stack.Contains("scurries") || stack.Contains("sat") || stack.Contains("chased"))
                            {
                                nodeCollection.Add(new Node() { Value = stack.Peek() });
                                PopStackWithAmount(1);
                                stack.Push("Verb");
                                nodeCollection.Add(new Node() { Value = stack.Peek(), Nodes = new List<Node>() { nodeCollection.Find(x => x.Value.Equals("ran") || x.Value.Equals("bites") || x.Value.Equals("scurries") || x.Value.Equals("sat") || x.Value.Equals("chased")) } });
                                nodeCollection.RemoveAll(x => x.Value.Equals("ran") || x.Value.Equals("bites") || x.Value.Equals("scurries") || x.Value.Equals("sat") || x.Value.Equals("chased"));
                            }
                            else if (stack.Contains("with") || stack.Contains("from") || stack.Contains("to"))
                            {
                                nodeCollection.Add(new Node() { Value = stack.Peek() });
                                PopStackWithAmount(1);
                                if ((string)stack.Peek() == "Preposition")
                                {
                                    inputFailed = true;
                                }
                                stack.Push("Preposition");
                                done = true;
                                nodeCollection.Add(new Node() { Value = stack.Peek(), Nodes = new List<Node>() { nodeCollection.Find(x => x.Value.Equals("with") || x.Value.Equals("from") || x.Value.Equals("to")) } });
                                nodeCollection.RemoveAll(x => x.Value.Equals("with") || x.Value.Equals("from") || x.Value.Equals("to"));
                            }
                            else if (stack.Contains("he") || stack.Contains("she") || stack.Contains("him") || stack.Contains("her"))
                            {
                                nodeCollection.Add(new Node() { Value = stack.Peek() });
                                PopStackWithAmount(1);
                                stack.Push("Pronoun");
                                nodeCollection.Add(new Node() { Value = stack.Peek(), Nodes = new List<Node>() { nodeCollection.Find(x => x.Value.Equals("he") || x.Value.Equals("she") || x.Value.Equals("him") || x.Value.Equals("her")) } });
                                nodeCollection.RemoveAll(x => x.Value.Equals("he") || x.Value.Equals("she") || x.Value.Equals("him") || x.Value.Equals("her"));
                            }
                            else if (stack.Contains("happily") || stack.Contains("quickly") || stack.Contains("good") || stack.Contains("bad"))
                            {
                                nodeCollection.Add(new Node() { Value = stack.Peek() });
                                PopStackWithAmount(1);
                                stack.Push("Adjective");
                                if (counter < inputStream.Length)
                                {
                                    done = true;
                                }
                                nodeCollection.Add(new Node() { Value = stack.Peek(), Nodes = new List<Node>() { nodeCollection.Find(x => x.Value.Equals("happily") || x.Value.Equals("quickly") || x.Value.Equals("good") || x.Value.Equals("bad")) } });
                                nodeCollection.RemoveAll(x => x.Value.Equals("happily") || x.Value.Equals("quickly") || x.Value.Equals("good") || x.Value.Equals("bad"));
                            }
                            else if (stack.Contains("Article") && stack.Contains("Adjective") && stack.Contains("Noun"))
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Article" || (string)x.Value == "Adjective" || (string)x.Value == "Noun");
                                var parentNode = new Node() { Nodes = list };
                                if (counter < inputStream.Length)
                                {
                                    if (inputStream[counter] != "with")
                                    {
                                        PopStackWithAmount(3);
                                        stack.Push("NounPhrase");
                                        parentNode.Value = stack.Peek();
                                        foreach (Node n in list)
                                        {
                                            n.Parent = parentNode;
                                        }
                                        nodeCollection.Add(parentNode);
                                        nodeCollection.RemoveAll(x => (string)x.Value == "Article" || (string)x.Value == "Adjective" || (string)x.Value == "Noun");
                                    }
                                    else
                                    {
                                        done = true;
                                    }
                                }
                                else if (counter == inputStream.Length)
                                {
                                    PopStackWithAmount(3);
                                    stack.Push("NounPhrase");
                                    parentNode.Value = stack.Peek();
                                    foreach (Node n in list)
                                    {
                                        n.Parent = parentNode;
                                    }
                                    nodeCollection.Add(parentNode);
                                    nodeCollection.RemoveAll(x => (string)x.Value == "Article" || (string)x.Value == "Adjective" || (string)x.Value == "Noun");
                                }
                            }
                            else if (stack.Contains("Article") && stack.Contains("Noun") && stack.Contains("Preposition") && (string)stack.Peek() == "NounPhrase")
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Article" || (string)x.Value == "Noun" || (string)x.Value == "Preposition" || (string)x.Value == "NounPhrase");
                                var parentNode = new Node() { Nodes = list };
                                PopStackWithAmount(4);
                                stack.Push("NounPhrase");
                                parentNode.Value = stack.Peek();
                                foreach (Node n in list)
                                {
                                    n.Parent = parentNode;
                                }
                                nodeCollection.Add(parentNode);
                                nodeCollection.RemoveAll(x => (string)x.Value == "Article" || (string)x.Value == "Noun" || (string)x.Value == "Preposition" || (string)x.Value == "NounPhrase");
                            }
                            else if (stack.Contains("Verb") && stack.Contains("Adjective") && stack.Contains("Preposition") && (string)stack.Peek() == "NounPhrase")
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Verb" || (string)x.Value == "Adjective" || (string)x.Value == "Preposition" || (string)x.Value == "NounPhrase");
                                var parentNode = new Node() { Nodes = list, Value = stack.Peek() };
                                PopStackWithAmount(4);
                                stack.Push("VerbPhrase");
                                foreach (Node n in list)
                                {
                                    n.Parent = parentNode;
                                }
                                nodeCollection.Add(parentNode);
                            }
                            else if (stack.Contains("Verb") && stack.Contains("Preposition") && (string)stack.Peek() == "NounPhrase")
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Verb" || (string)x.Value == "Preposition");
                                list.Add(nodeCollection.FindLast(x => (string)x.Value == "NounPhrase"));
                                var parentNode = new Node() { Nodes = list };
                                PopStackWithAmount(3);
                                stack.Push("VerbPhrase");
                                parentNode.Value = stack.Peek();
                                foreach (Node n in list)
                                {
                                    n.Parent = parentNode;
                                }
                                nodeCollection.Add(parentNode);
                                nodeCollection.RemoveAll(x => (string)x.Value == "Verb" || (string)x.Value == "Preposition");
                                nodeCollection.RemoveAt(nodeCollection.Count - 2);
                            }
                            else if (stack.Contains("Verb") && stack.Contains("Preposition") && (string)stack.Peek() == "Pronoun")
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Verb" || (string)x.Value == "Preposition" || (string)x.Value == "Pronoun");
                                var parentNode = new Node() { Nodes = list };
                                PopStackWithAmount(3);
                                stack.Push("VerbPhrase");
                                parentNode.Value = stack.Peek();
                                foreach (Node n in list)
                                {
                                    n.Parent = parentNode;
                                }
                                nodeCollection.Add(parentNode);
                                nodeCollection.RemoveAll(x => (string)x.Value == "Verb" || (string)x.Value == "Preposition" || (string)x.Value == "Pronoun");
                            }
                            else if (stack.Contains("Article") && stack.Contains("Noun"))
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Article" || (string)x.Value == "Noun");
                                var parentNode = new Node() { Nodes = list };
                                if (counter >= inputStream.Length)
                                {
                                    PopStackWithAmount(2);
                                    stack.Push("NounPhrase");
                                    parentNode.Value = stack.Peek();
                                    foreach (Node n in list)
                                    {
                                        n.Parent = parentNode;
                                    }
                                    nodeCollection.Add(parentNode);
                                    nodeCollection.RemoveAll(x => (string)x.Value == "Article" || (string)x.Value == "Noun");
                                }
                                else
                                {
                                    if (inputStream[counter] != "with")
                                    {
                                        PopStackWithAmount(2);
                                        stack.Push("NounPhrase");
                                        parentNode.Value = stack.Peek();
                                        foreach (Node n in list)
                                        {
                                            n.Parent = parentNode;
                                        }
                                        nodeCollection.Add(parentNode);
                                        nodeCollection.RemoveAll(x => (string)x.Value == "Article" || (string)x.Value == "Noun");
                                    }
                                    else
                                    {
                                        done = true;
                                    }
                                }
                            }
                            else if (stack.Contains("Article") && stack.Contains("Adjective") && stack.Contains("Noun") && stack.Contains("Preposition"))
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Article" || (string)x.Value == "Adjective" || (string)x.Value == "Noun" || (string)x.Value == "Preposition");
                                var parentNode = new Node() { Nodes = list };
                                PopStackWithAmount(4);
                                stack.Push("NounPhrase");
                                parentNode.Value = stack.Peek();
                                foreach (Node n in list)
                                {
                                    n.Parent = parentNode;
                                }
                                nodeCollection.Add(parentNode);
                                nodeCollection.RemoveAll(x => (string)x.Value == "Article" || (string)x.Value == "Adjective" || (string)x.Value == "Noun" || (string)x.Value == "Preposition");
                            }
                            else if (stack.Contains("Verb") && stack.Contains("Adjective") && (string)stack.Peek() == "NounPhrase")
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Verb" || (string)x.Value == "Adjective" || (string)x.Value == "NounPhrase");
                                var parentNode = new Node() { Nodes = list };
                                PopStackWithAmount(3);
                                stack.Push("VerbPhrase");
                                parentNode.Value = stack.Peek();
                                foreach (Node n in list)
                                {
                                    n.Parent = parentNode;
                                }
                                nodeCollection.Add(parentNode);
                                nodeCollection.RemoveAll(x => (string)x.Value == "Verb" || (string)x.Value == "Adjective" || (string)x.Value == "NounPhrase");
                            }
                            else if (stack.Contains("Verb") && stack.Contains("Adjective"))
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Verb" || (string)x.Value == "Adjective");
                                var parentNode = new Node() { Nodes = list};
                                PopStackWithAmount(2);
                                stack.Push("VerbPhrase");
                                parentNode.Value = stack.Peek();
                                foreach (Node n in list)
                                {
                                    n.Parent = parentNode;
                                }
                                nodeCollection.Add(parentNode);
                                nodeCollection.RemoveAll(x => (string)x.Value == "Verb" || (string)x.Value == "Adjective");
                            }
                            else if (stack.Contains("Verb") && stack.Contains("PronounPhrase"))
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Verb" || (string)x.Value == "PronounPhrase");
                                var parentNode = new Node() { Nodes = list, Value = stack.Peek() };
                                PopStackWithAmount(2);
                                stack.Push("VerbPhrase");
                                foreach (Node n in list)
                                {
                                    n.Parent = parentNode;
                                }
                                nodeCollection.Add(parentNode);
                            }
                            else if (stack.Contains("VerbPhrase") && (string)stack.Peek() == "NounPhrase")
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "VerbPhrase" || (string)x.Value == "NounPhrase");
                                var parentNode = new Node() { Nodes = list};
                                PopStackWithAmount(2);
                                stack.Push("VerbPhrase");
                                parentNode.Value = stack.Peek();
                                foreach (Node n in list)
                                {
                                    n.Parent = parentNode;
                                }
                                nodeCollection.Add(parentNode);
                                nodeCollection.RemoveAll(x => (string)x.Value == "VerbPhrase" || (string)x.Value == "NounPhrase");
                            }
                            else if (stack.Contains("Verb") && (string)stack.Peek() == "NounPhrase")
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Verb");
                                list.Add(nodeCollection.FindLast(x => (string)x.Value == "NounPhrase"));
                                var parentNode = new Node() { Nodes = list };
                                if (counter >= inputStream.Length)
                                {
                                    PopStackWithAmount(2);
                                    stack.Push("VerbPhrase");
                                    parentNode.Value = stack.Peek();
                                    foreach (Node n in list)
                                    {
                                        n.Parent = parentNode;
                                    }
                                    nodeCollection.Add(parentNode);
                                    nodeCollection.RemoveAll(x => (string)x.Value == "Verb");
                                    nodeCollection.RemoveAt(nodeCollection.Count - 1);
                                }
                                else
                                {
                                    if (inputStream[counter] != "with")
                                    {
                                        PopStackWithAmount(2);
                                        stack.Push("VerbPhrase");
                                        parentNode.Value = stack.Peek();
                                        foreach (Node n in list)
                                        {
                                            n.Parent = parentNode;
                                        }
                                        nodeCollection.Add(parentNode);
                                        nodeCollection.RemoveAll(x => (string)x.Value == "Verb" || (string)x.Value == "NounPhrase");
                                    }
                                    else
                                    {
                                        done = true;
                                    }
                                }
                            }
                            else if (stack.Contains("Verb"))
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Verb");
                                var parentNode = new Node() { Nodes = list };
                                if (counter <= inputStream.Length)
                                {
                                    if (counter == inputStream.Length)
                                    {
                                        PopStackWithAmount(1);
                                        stack.Push("VerbPhrase");
                                        foreach (Node n in list)
                                        {
                                            n.Parent = parentNode;
                                        }
                                        nodeCollection.Add(parentNode);
                                        nodeCollection.RemoveAll(x => (string)x.Value == "Verb");
                                    }
                                    else if (inputStream[counter] != "a" && inputStream[counter] != "the" && inputStream[counter] != "an"
                                        && inputStream[counter] != "dog" && inputStream[counter] != "cat" && inputStream[counter] != "squirrel" && inputStream[counter] != "boy" && inputStream[counter] != "girl"
                                        && inputStream[counter] == "quickly" && inputStream[counter] == "happily")
                                    {
                                        PopStackWithAmount(1);
                                        stack.Push("VerbPhrase");
                                        parentNode.Value = stack.Peek();
                                        foreach (Node n in list)
                                        {
                                            n.Parent = parentNode;
                                        }

                                        nodeCollection.Add(parentNode);
                                        nodeCollection.RemoveAll(x => (string)x.Value == "Verb");
                                    }
                                    else
                                    {
                                        done = true;
                                    }
                                }
                            }
                            else if (stack.Contains("Preposition") && stack.Contains("Pronoun"))
                            {
                                var list = nodeCollection.FindAll(x => (string)x.Value == "Preposition" || (string)x.Value == "Pronoun");
                                var parentNode = new Node() { Nodes = list };
                                PopStackWithAmount(2);
                                stack.Push("PronounPhrase");
                                parentNode.Value = stack.Peek();
                                foreach (Node n in list)
                                {
                                    n.Parent = parentNode;
                                }
                                nodeCollection.Add(parentNode);
                                nodeCollection.RemoveAll(x => (string)x.Value == "Preposition" || (string)x.Value == "Pronoun");
                            }
                            else
                            {
                                done = true;
                            }
                        }
                    }
                }
                if (!stack.Contains("Sentence"))
                {
                    PrintFailure();
                }
                else
                {
                    system.RootNode = nodeCollection[nodeCollection.Count - 1];
                    PrintSuccess();
                }
            }
        }
        private void PrintSuccess()
        {
            ResponseTree tree = new ResponseTree(system);
            tree.PrintResponse();
        }
        private void PrintFailure()
        {
            Console.WriteLine("I'm not sure I follow you");
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
        private void PopStackWithAmount(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                stack.Pop();
            }
        }
    }
}
