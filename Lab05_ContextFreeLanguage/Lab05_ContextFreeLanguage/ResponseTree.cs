using Lab05_ContextFreeLanguage.DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05_ContextFreeLanguage
{
    public class ResponseTree
    {
        private TreeSystem system;
        private bool checkResponse = false;
        private int? similarTreeIndex = null;

        private readonly string[] nounResponses = new string[]
        {
            "What else did the [NOUN] do?",
            "Nice! Do you love [NOUN]s?"
        };
        private readonly string[] nounAdjectiveResponses = new string[]
        {
            "Is that so? [ADJECTIVE]? With the [NOUN]? No way...",
            "Is the [NOUN] really [ADJECTIVE]?"
        };
        private readonly string[] pronounResponses = new string[]
        {
            "What else did [PRONOUN] do?",
            "How is [PRONOUN] doing?"
        };
        private List<TreeSystem> stackTree = new List<TreeSystem>();

        public ResponseTree(TreeSystem temp)
        {
            system = temp;
        }
        public void AddNewTree(TreeSystem temp)
        {
            system = new TreeSystem(temp);
        }
        public void PrintResponse(bool pass)
        {
            if (pass)
            {
                checkResponse = false;
                if (stackTree.Count > 0)
                {
                    if (CheckTreeExists())
                    {
                        checkResponse = true;
                    }
                    Console.WriteLine(OutputSelected());
                }
                else
                {
                    Console.WriteLine(OutputSelected());
                }
            }
            else
            {
                if (stackTree.Count > 0)
                {
                    Console.WriteLine(stackTree[stackTree.Count - 1].ResponseMessage);
                }
                else
                {
                    Console.WriteLine("I'm not sure I follow you");
                }
            }
        }
        private bool CheckTreeExists()
        {
            similarTreeIndex = stackTree.Count - 1;
            for (int i = stackTree.Count - 1; i >= 0; i--)
            {
                if(CheckTreeNodeMatch(system.RootNode, stackTree[i].RootNode))
                {
                    return true;
                }

                similarTreeIndex--;
            }
            return false;
        }
        private bool CheckTreeNodeMatch(Node systemNode, Node treeNode)
        {
            if (systemNode == null && treeNode == null)
            {
                return true;
            }
            else if (systemNode == null || treeNode == null)
            {
                return false;
            }
            else
            {
                if (!systemNode.Value.Equals(treeNode.Value))
                {
                    return false;
                }
                else
                {
                    if (systemNode.Nodes != null && treeNode.Nodes != null) {
                        if (systemNode.Nodes.Count != treeNode.Nodes.Count)
                        {
                            return false;
                        }
                        else
                        {
                            for (int i = 0; i < systemNode.Nodes.Count; i++)
                            {
                                if(!CheckTreeNodeMatch(systemNode.Nodes[i], treeNode.Nodes[i]))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }
        private string OutputSelected()
        {
            List<Node> nodeCollection = system.TreeSystemToList();
            List<Node> adjectives, nouns, pronouns;
            Random random = new Random();
            string output = "";
            string[] temp = null;
            
            if (nodeCollection.Contains(nodeCollection.Find(x => x.Value.Equals("Noun"))) && nodeCollection.Contains(nodeCollection.Find(x => x.Value.Equals("Adjective"))))
            {
                adjectives = nodeCollection.FindAll(x => x.Value.Equals("Adjective"));
                nouns = nodeCollection.FindAll(x => x.Value.Equals("Noun"));
                output = nounAdjectiveResponses[random.Next(0, nounAdjectiveResponses.Length)];

                if (!checkResponse)
                {
                    temp = NodeAdjectiveList(adjectives, nouns, random, output);
                }
                else
                {
                    while (output.Equals(stackTree[(int)similarTreeIndex].ResponseMessage))
                    {
                        output = nounAdjectiveResponses[random.Next(0, nounAdjectiveResponses.Length)];
                    }
                    temp = NodeAdjectiveList(adjectives, nouns, random, output);
                }
            }
            else if (nodeCollection.Contains(nodeCollection.Find(x => x.Value.Equals("Pronoun"))))
            {
                pronouns = nodeCollection.FindAll(x => x.Value.Equals("Pronoun"));

                output = pronounResponses[random.Next(0, pronounResponses.Length)];

                if (!checkResponse)
                {
                    temp = PronounList(pronouns, random, output);
                }
                else
                {
                    while (output.Equals(stackTree[(int)similarTreeIndex].ResponseMessage))
                    {
                        output = pronounResponses[random.Next(0, nounAdjectiveResponses.Length)];
                    }
                    temp = PronounList(pronouns, random, output);
                }
            }
            else if (nodeCollection.Contains(nodeCollection.Find(x => x.Value.Equals("Noun"))))
            {
                nouns = nodeCollection.FindAll(x => x.Value.Equals("Noun"));
                output = nounResponses[random.Next(0, pronounResponses.Length)];

                if (!checkResponse)
                {
                    temp = NounList(nouns, random, output);
                }
                else
                {
                    while (output.Equals(stackTree[(int)similarTreeIndex].ResponseMessage))
                    {
                        output = nounResponses[random.Next(0, nounResponses.Length)];
                    }
                    temp = NounList(nouns, random, output);
                }
            }
            stackTree.Add(new TreeSystem() { RootNode = system.RootNode, ResponseMessage = output });
            output = "";

            for(int i = 0; i < temp.Length; i++)
            {
                output += (i == temp.Length - 1) ? temp[i] : temp[i] + " ";
            }
            return output;
        }

        private static string[] NounList(List<Node> nouns, Random random, string output)
        {
            string[] temp = output.Split(' ');
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Equals("[NOUN]"))
                {
                    temp[i] = (string)nouns[random.Next(0, nouns.Count)].Nodes[0].Value;
                }
                else if (temp[i].Equals("[NOUN]s?"))
                {
                    temp[i] = (string)nouns[random.Next(0, nouns.Count)].Nodes[0].Value + "s?";
                }
            }

            return temp;
        }

        private static string[] PronounList(List<Node> pronouns, Random random, string output)
        {
            string[] temp = output.Split(' ');
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Equals("[PRONOUN]"))
                {
                    temp[i] = (string)pronouns[random.Next(0, pronouns.Count)].Nodes[0].Value;
                }
            }

            return temp;
        }

        private static string[] NodeAdjectiveList(List<Node> adjectives, List<Node> nouns, Random random, string output)
        {
            string[] temp = output.Split(' ');
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Equals("[NOUN]?"))
                {
                    temp[i] = (string)nouns[random.Next(0, nouns.Count)].Nodes[0].Value + "?";
                }
                else if (temp[i].Equals("[NOUN]"))
                {
                    temp[i] = (string)nouns[random.Next(0, nouns.Count)].Nodes[0].Value;
                }
                else if (temp[i].Equals("[ADJECTIVE]?"))
                {
                    temp[i] = (string)adjectives[random.Next(0, adjectives.Count)].Nodes[0].Value + "?";
                }
            }

            return temp;
        }
    }
}
