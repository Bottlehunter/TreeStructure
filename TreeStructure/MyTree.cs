using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeStructure
{
    class MyTree
    {
        public TreeNode Root { get; set; } = new TreeNode
        {
            Key = "null",
            Parent = new TreeNode(),
            Value = "I'm a tree root"
        };

        public TreeNode[] TreeNodes { get; set; }

        public void Initialize(KeyValue[] values)
        {
            TreeNodes = new TreeNode[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                TreeNodes[i] = new TreeNode
                {
                    Key = values[i].Key,
                    Value = values[i].Value
                };
            }

            for (int i = 0; i < TreeNodes.Length; i++)
            {
                var node = TreeNodes[i];
                node.Parent = Root;

                for (int j = 0 ; j < TreeNodes.Length; j++)
                {
                    //item cannot be parent or child for itself
                    if (j == i)
                        continue;

                    if (TreeNodes[j].Key.Length < node.Key.Length)
                    {
                        // Looking for parent
                        if (node.Key.StartsWith(TreeNodes[j].Key))
                        {
                            if (node.Parent.Key == Root.Key ||
                                node.Parent.Key.Length < TreeNodes[j].Key.Length)
                            {
                                node.Parent = TreeNodes[j];
                            }
                        }
                    }

                    if (TreeNodes[j].Key.Length > node.Key.Length)
                    {
                        // Looking for children
                        if (TreeNodes[j].Key.StartsWith(node.Key))
                        {
                            if (node.ChildNodes.Length > 0)
                            {
                                for (int k = 0; k < node.ChildNodes.Length; k++)
                                {
                                    var parent = node.ChildNodes[k].Parent;
                                    if (parent != null && parent.Key.Length < TreeNodes[j].Key.Length)
                                    {

                                        node.ChildNodes[k] = TreeNodes[j];
                                    }
                                }
                            }
                            else
                            {
                                node.ChildNodes = node.ChildNodes.Concat(new[] {TreeNodes[j]}).ToArray();
                            }
                        }
                    }
                }
            }
            Root.ChildNodes = TreeNodes.Where(x => x.Parent.Key == Root.Key).ToArray();
        }

        public void DeleteElement(string key)
        {
            var node = TreeNodes.FirstOrDefault(x => x.Key == key);

            if (node == null)
            {
                throw new ArgumentException($"Node with key {key} does not exist");
            }

            if (node.Key == Root.Key)
            {
                throw new ArgumentException("Root element cannot be deleted");
            }

            var parent = node.Parent;
            
            foreach (var childNode in node.ChildNodes)
            {
                childNode.Parent = parent;
            }

            parent.ChildNodes = parent.ChildNodes.Where(val => val.Key != node.Key)
                                                 .Concat(node.ChildNodes).ToArray();

            TreeNodes = TreeNodes.Where(n => n.Key != node.Key).ToArray();
        }

        public void Find(string key)
        {
        }
    }
}
