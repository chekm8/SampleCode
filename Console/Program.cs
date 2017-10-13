using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeSample
{
    internal static class Program
    {
        private static void Main()
        {
            const string data = "(id,created,employee(id,firstname,employeeType(id), lastname),location)";

            var nodes = GetTree(data);

            PrintTreeTitle("Normal");
            PrintTree(nodes, string.Empty);
            PrintTreeTitle("Sorted");
            PrintTree(nodes, string.Empty, true);
            Console.ReadLine();
        }

        private static void PrintTreeTitle(string title)
        {
            var aspacer = new string('=', 25);
            Console.WriteLine($"{Environment.NewLine}{aspacer}{title}{aspacer}");
        }

        private static void PrintTree(List<TreeNode> treeNodes, string level, bool isAlphabeticSort = false)
        {
            var nodes = isAlphabeticSort ? treeNodes.OrderBy(o => o.Value).ToList() : treeNodes;
            foreach (var node in nodes)
            {
                if (node.Value.Length > 0)
                {
                    Console.WriteLine($"{level} {node.Value}"); //trim off any whitespaces around the value
                }
                PrintTree(node.SubNodes, $"{level}-", isAlphabeticSort);
            }
        }

        private static List<TreeNode> GetTree(string data)
        {
            var happyLilTree = new TreeNode { Parent = null, Value = "root", SubNodes = new List<TreeNode>() };
            var node = happyLilTree;
            foreach (var c in data)
            {
                switch (c)
                {
                    case '(':
                        node = new TreeNode { Parent = node };
                        node.Parent.SubNodes.Add(node);
                        break;
                    case ')':
                        node = new TreeNode { Parent = node.Parent?.Parent };
                        node.Parent?.SubNodes.Add(node);
                        break;
                    case ',':
                        if (!string.IsNullOrWhiteSpace(node.Value))
                        {
                            node = new TreeNode { Parent = node.Parent };
                            node.Parent.SubNodes.Add(node);
                        }
                        break;
                    default:
                        node.Value += c;
                        break;
                }
            }

            return happyLilTree.SubNodes;
        }
    }
}
