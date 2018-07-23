using Lab05_ContextFreeLanguage.DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05_ContextFreeLanguage
{
    public class ResponseTree
    {
        private readonly TreeSystem system;

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
            List<Node> nodes = system.TreeSystemToList();

            if (nodes.Contains(nodes.Find(x => x.Value.Equals("Noun"))) && nodes.Contains(nodes.Find(x => x.Value.Equals("Adjective"))))
            {
                List<Node> adjectives = nodes.FindAll(x => x.Value.Equals("Adjective"));
                if ()

                }
            }
            else if ()
            {

            }
            return null;
        }
    }
}
