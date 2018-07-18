using Lab05_ContextFreeLanguage.DataStructure;

namespace Lab05_ContextFreeLanguage
{
    public class TreeSystem
    {
        public TreeSystem()
        {
            RootNode = new Node();
        }
        public TreeSystem(Node rootNode)
        {
            RootNode = rootNode;
        }
        public Node RootNode { get; set; }
    }
}