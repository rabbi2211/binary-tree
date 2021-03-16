using System;

namespace BTree
{

    public enum TreeOperations { CreateTree, Display, Search, InOrderTraveral, PreOrderTraversal, PostOrderTraveral, LevelOrderTraversal, InsertNode, DeleteNode, DeleteTree }
    public class Program
    {
        static BinaryTree tree = new BinaryTree();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***************************************");
            Console.WriteLine("***************************************");
            Console.WriteLine("Tree Operations");
            foreach (var operation in Enum.GetNames(typeof(TreeOperations)))
            {

                int value = (int)Enum.Parse(typeof(TreeOperations), operation);
                Console.WriteLine($" {value }. {operation}");
            }
            Console.WriteLine("***************************************"); 
            Console.WriteLine("***************************************");

            int operationToPerform = Int32.MaxValue;
            while (operationToPerform >= 0)
            {

                Console.Write($"\n Enter operation to Perform:_");
                string operation = Console.ReadLine();

                switch (Convert.ToInt32(operation))
                {
                    case (int)TreeOperations.CreateTree:
                        {
                            Console.Write($"Inserting Nodes in Tree \n");
                            for (int i = 1; i < 5; i++)
                            {
                                tree.Insert(i * 11);
                            }
                            break;
                        }

                    case (int)TreeOperations.Display:
                        {
                            Console.Write($"Tree: ");
                            tree.LevelOrderTraversal();
                            break;
                        }
                    case (int)TreeOperations.InOrderTraveral:
                        {
                            Console.Write($"In Order Traversal: ");
                            tree.InOrderTraversal(tree.RootNode());
                            break;
                        }
                    case (int)TreeOperations.PreOrderTraversal:
                        {
                            Console.Write($"Pre Order Traversal: ");
                            tree.PreOrderTraversal(tree.RootNode());
                            break;
                        }
                    case (int)TreeOperations.PostOrderTraveral:
                        {
                            Console.Write($"Post Order Traversal: ");
                            tree.PostOrderTraversal(tree.RootNode());
                            break;
                        }
                    case (int)TreeOperations.LevelOrderTraversal:
                        {
                            Console.Write($"Level Order Traversal: ");
                            tree.LevelOrderTraversal();
                            break;
                        }
                    case (int)TreeOperations.InsertNode:
                        {
                            Console.Write($"\n Enter Value of node to INSERT");
                            tree.Insert(Convert.ToInt32(Console.ReadLine()));
                            break;
                        }
                    case (int)TreeOperations.Search:
                        {
                            Console.Write($"\n Enter Value to SEARCH-");
                            tree.Search(Convert.ToInt32(Console.ReadLine()));
                            break;
                        }
                    case (int)TreeOperations.DeleteNode:
                        {
                            Console.Write($"\n Enter Value to DELETE");
                            tree.DeleteNode(Convert.ToInt32(Console.ReadLine()));
                            break;
                        }
                    case (int)TreeOperations.DeleteTree:
                        {
                            Console.Write($"\n Deleting TREE");
                            tree.DeleteTree();
                            break;
                        }


                    default:
                        Console.WriteLine("***Not a Valid Operation.****");
                        break;

                }
            }







            Console.Read();
        }
    }

}
