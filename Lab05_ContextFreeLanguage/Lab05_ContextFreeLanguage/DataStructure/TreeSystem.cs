using Lab05_ContextFreeLanguage.DataStructure;
using System;
using System.Collections.Generic;

namespace Lab05_ContextFreeLanguage
{
    public class TreeSystem
    {
        public TreeSystem()
        {
            RootNode = new Node();
        }
        public TreeSystem(TreeSystem tree)
        {
            RootNode = new Node();
            RootNode.Nodes = tree.RootNode.Nodes;
            RootNode.Value = tree.RootNode.Value;
            RootNode.Parent = tree.RootNode.Parent;
        }
        public TreeSystem(Node rootNode)
        {
            RootNode = rootNode;
        }
        public string ResponseMessage { get; set; }
        public Node RootNode { get; set; }

        public List<Node> TreeSystemToList()
        {
            List<Node> list = new List<Node>();
            return ArrayLooper(list, RootNode);
        }
        private List<Node> ArrayLooper(List<Node> list, Node node)
        {
            int counter = 0;
            if (node != null)
            {
                if (node.Value != null)
                {
                    counter++;
                    list.Add(node);
                }
                if (node.Nodes != null)
                {
                    foreach (Node child in node.Nodes)
                    {
                        ArrayLooper(list, child);
                    }
                }
            }
            return list;
        }
    }
}