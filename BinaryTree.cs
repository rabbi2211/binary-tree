using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace BTree
{
    public class BinaryTree
    {

        private Node root;
        private Queue<Node> _queue;
        private Queue<Node> _searchQueue;
        public Node ROOT { get { return root; } }
        public BinaryTree()
        {
            root = null;
            _queue = new Queue<Node>();
        }

        #region  Operations
        /// <summary>
        /// Get  the Root Node
        /// </summary>
        /// <returns></returns>
        public Node RootNode() => root;

        /// <summary>
        /// Search an item in a tree
        /// </summary>
        /// <param name="item"></param>
        public void Search(int item)
        {
            _searchQueue = new Queue<Node>();
            _searchQueue.Enqueue(ROOT);
            while (_searchQueue.Count > 0)
            {
                Node current = _searchQueue.Dequeue();
                if (current.Data == item)
                {
                    Console.WriteLine($"{item} exist in Tree");
                    return;
                }
                else
                {
                    if (current.Left != null)
                    {
                        _searchQueue.Enqueue(current.Left);
                    }
                    if (current.Right != null)
                    {
                        _searchQueue.Enqueue(current.Right);
                    }
                }
            }
            Console.WriteLine($" {item} doesn't exist in Tree");
        }
        /// <summary>
        /// Insert an Item into the tree
        /// </summary>
        /// <param name="itemToInsert"></param>
        public void Insert(int itemToInsert)
        {
            Node _nodeToInsert = new Node();
            _nodeToInsert.Data = itemToInsert;
            //Case 1 When tree is empty
            if (ROOT == null)
            {
                root = _nodeToInsert;
                WriteLine($" Root {_nodeToInsert.Data} Inserted");
                return;
            }

            _queue.Enqueue(ROOT);
            while (_queue.Any())
            {
                Node currentNode = _queue.Dequeue();
                if (currentNode.Left == null)
                {
                    currentNode.Left = _nodeToInsert;
                    WriteLine($" Left  Child {_nodeToInsert.Data} Inserted.");
                    break;
                }
                else if (currentNode.Right == null)
                {
                    currentNode.Right = _nodeToInsert;
                    WriteLine($" Right Child {_nodeToInsert.Data} Inserted.");
                    break;
                }
                else
                {
                    _queue.Enqueue(currentNode.Left);
                    _queue.Enqueue(currentNode.Right);
                }

            }

        }

        /// <summary>
        /// Delete Node in the the tree
        /// </summary>
        public void DeleteNode(int item)
        {
            _searchQueue = new Queue<Node>();
            _searchQueue.Enqueue(ROOT);
            while (_searchQueue.Count > 0)
            {
                Node currentNode = _searchQueue.Dequeue();
                
                if (currentNode.Data == item)
                {
                    currentNode.Data = FindDeepestNode().Data;
                    DeleteDeepestNode();
                    Console.WriteLine($" {item} Deleted the Item from Tree");
                    return;
                }
                else
                {
                    if (currentNode.Left != null)
                    {
                        _searchQueue.Enqueue(currentNode.Left);
                    }
                    if (currentNode.Right != null)
                    {
                        _searchQueue.Enqueue(currentNode.Right);
                    }
                }
            }
            Console.WriteLine($"{item } not found in tree to be deleted");
        }


        private void DeleteDeepestNode()
        {
            _searchQueue = new Queue<Node>();
            _searchQueue.Enqueue(ROOT);
            Node currentNode = new Node();
            Node previousNode = new Node();
            while (_searchQueue.Count > 0)
            {
                previousNode = currentNode;
                currentNode = _searchQueue.Dequeue();
                if (currentNode.Left == null)
                {
                    previousNode.Right = null;
                    return;
                }
                else if (currentNode.Right == null)
                {
                    currentNode.Left = null;
                    return;
                }
                _searchQueue.Enqueue(currentNode.Left);
                _searchQueue.Enqueue(currentNode.Right);
            }

        }
        /// <summary>
        /// Find the deepest node in the tree
        /// </summary>
        /// <returns></returns>
        private Node FindDeepestNode()
        {
            _searchQueue = new Queue<Node>();
            _searchQueue.Enqueue(ROOT);
            Node current = new Node();
            while (_searchQueue.Count > 0)
            {
                current = _searchQueue.Dequeue();
                if (current.Left != null) _searchQueue.Enqueue(current.Left);
                if (current.Right != null) _searchQueue.Enqueue(current.Right);

            }
            return current;
        }

        /// <summary>
        /// Delete the tree 
        /// </summary>
        public void DeleteTree()
        {
            root = null;
            Write($" Tree has been Deleted Successfully.");
        }


        #endregion

        #region Traversal Operations

        /// <summary>
        /// Traverses the tree in Pre Order Way
        /// </summary>
        /// <param name="node"></param>
        public void PreOrderTraversal(Node node)
        {
            if (node == null) return;
            Write($" {node.Data} ");
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }
        /// <summary>
        /// Traverses the tree in Post Order Way
        /// </summary>
        /// <param name="node"></param>
        public void PostOrderTraversal(Node node)
        {
            if (node == null) return;
            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Write($" {node.Data} ");

        }
        /// <summary>
        /// Traverses the tree In Order Fashion
        /// </summary>
        /// <param name="node"></param>
        public void InOrderTraversal(Node node)
        {
            if (node == null) return;

            InOrderTraversal(node.Left);
            Write($" {node.Data} ");
            InOrderTraversal(node.Right);
        }
        /// <summary>
        /// Traverse the Tree in a Level Order Fashion
        /// </summary>
        public void LevelOrderTraversal()
        {
            Queue<Node> nodesQueue = new Queue<Node>();
            nodesQueue.Enqueue(ROOT);

            while (nodesQueue.Count > 0)
            {
                Node current = nodesQueue.Dequeue();
                Write($" {current.Data} ");
                if (current.Left != null) nodesQueue.Enqueue(current.Left);
                if (current.Right != null) nodesQueue.Enqueue(current.Right);
            }
        }
        #endregion
        
    }


}
