using System;
using System.Collections.Generic;
using System.Text;

namespace TreeStructure
{
    class TreeNode
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode[] ChildNodes { get; set; } = new TreeNode[0];

        public void PrintChildren(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(Key);

            for (int i = 0; i < ChildNodes.Length; i++)
                ChildNodes[i].PrintChildren(indent, i == ChildNodes.Length - 1);
        }
    }
}
