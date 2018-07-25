using Lab05_ContextFreeLanguage.DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05_ContextFreeLanguage
{
    public class ResponseTree
    {
        private readonly TreeSystem system;

        private string[] nounResponses = new string[]
        {
            "What else did the [NOUN] do?",
            "Nice! Do you love [NOUN]s?"
        };
        private string[] nounAdjectiveResponses = new string[]
        {
            "Is that so? [ADJECTIVE]? With the [NOUN]? No way..."
        };
        private string[] pronounResponses = new string[]
        {
            "What else did [PRONOUN] do?",
            "How is [PRONOUN] doing?"
        };


        public ResponseTree(TreeSystem temp)
        {
            system = temp;
        }
        public void PrintResponse()
        {
            Console.WriteLine(OutputSelected());
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

                output = nounAdjectiveResponses[0];
                temp = output.Split(' ');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Equals("[NOUN]?"))
                    {
                        temp[i] = (string)nouns[random.Next(0, nouns.Count)].Nodes[0].Value + "?";
                    }
                    else if (temp[i].Equals("[ADJECTIVE]?"))
                    {
                        temp[i] = (string)adjectives[random.Next(0, adjectives.Count)].Nodes[0].Value + "?";
                    }
                }
            }
            else if (nodeCollection.Contains(nodeCollection.Find(x => x.Value.Equals("Pronoun"))))
            {
                pronouns = nodeCollection.FindAll(x => x.Value.Equals("Pronoun"));

                output = pronounResponses[random.Next(0, pronounResponses.Length - 1)];
                temp = output.Split(' ');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Equals("[PRONOUN]"))
                    {
                        temp[i] = (string)pronouns[random.Next(0, pronouns.Count)].Nodes[0].Value;
                    }
                }
            }
            else if (nodeCollection.Contains(nodeCollection.Find(x => x.Value.Equals("Noun"))))
            {
                nouns = nodeCollection.FindAll(x => x.Value.Equals("Noun"));
                output = nounResponses[random.Next(0, pronounResponses.Length - 1)];

                temp = output.Split(' ');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Equals("[NOUN]"))
                    {
                        temp[i] = (string)nouns[random.Next(0, nouns.Count)].Nodes[0].Value;
                    }
                }
            }
            output = "";
            for(int i = 0; i < temp.Length; i++)
            {
                output += (i == temp.Length - 1) ? temp[i] : temp[i] + " ";
            }
            return output;
        }
    }
}
