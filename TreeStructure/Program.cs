using System;

namespace TreeStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var simpleItems = new KeyValue[]
            {
                new KeyValue {Key = "1", Value = "One"},
                new KeyValue {Key = "2", Value = "No way!"},
                new KeyValue {Key = "11", Value = "Night"},
                new KeyValue {Key = "111", Value = "To start"}
            };

            var tree = new MyTree();
            tree.Initialize(simpleItems);

            tree.Root.PrintChildren("", true);
            Console.ReadLine();

            Console.WriteLine("Enter Node key to delete:");

            try
            {
                tree.DeleteElement(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            tree.Root.PrintChildren("", true);
            Console.ReadLine();
        }
    }
}
