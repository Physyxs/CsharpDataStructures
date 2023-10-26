using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPortfolio
{
    public class BinarySearchTree
    {
        /**
         * Private Class for handling the Tree Nodes
         */
        private class Node
        {
            public int value;
            public Node leftChild;
            public Node rightChild;

            public Node(int val)
            {
                value = val;
                leftChild = null;
                rightChild = null;
            }
        }

        private Node root;
        /**
         * Creates an empty BinarySearchTree
         */
        public BinarySearchTree()
        {
            root = null;
        }
        /**
         * Public Method for Adding Nodes to Tree
         */
        public void Add(int val)
        {
            root = AddNode(root, val);
        }
        /**
         * Private Recursive Helper Method for Add to add nodes to tree
         */
        private Node AddNode(Node current, int val)
        {
            if (current == null)
            {
                return new Node(val);
            }

            if (val < current.value)
            {
                current.leftChild = AddNode(current.leftChild, val);
            }
            else if (val > current.value)
            {
                current.rightChild = AddNode(current.rightChild, val);
            }

            return current;
        }
        /**
         * Public method for finding a node
         */
        public bool Has(int val)
        {
            return HasNode(root, val);
        }
        /**
         * Private Recursive Helper method for finding a node
         */
        private bool HasNode(Node current, int val)
        {
            if (current == null)
            {
                return false;
            }

            if (val == current.value)
            {
                return true;
            }

            if (val < current.value)
            {
                return HasNode(current.leftChild, val);
            }
            else
            {
                return HasNode(current.rightChild, val);
            }
        }
        /**
         * Public method for removing a node
         */
        public void Remove(int val)
        {
            root = RemoveNode(root, val);
        }
        /**
         * Private recursive method for removing a node
         */
        private Node RemoveNode(Node current, int val)
        {
            if (current == null)
            {
                return null;
            }

            if (val < current.value)
            {
                current.leftChild = RemoveNode(current.leftChild, val);
            }
            else if (val > current.value)
            {
                current.rightChild = RemoveNode(current.rightChild, val);
            }
            else
            {
                if (current.leftChild == null && current.rightChild == null)
                {
                    return null;
                }
                else if (current.leftChild == null)
                {
                    return current.rightChild;
                }
                else if (current.rightChild == null)
                {
                    return current.leftChild;
                }
                else
                {
                    Node successor = FindMinimum(current.rightChild);
                    current.value = successor.value;
                    current.rightChild = RemoveNode(current.rightChild, successor.value);
                }
            }

            return current;
        }
        /**
         * Private Helper method to find the smallest node
         */
        private Node FindMinimum(Node current)
        {
            while (current.leftChild != null)
            {
                current = current.leftChild;
            }
            return current;
        }
        /**
         * Public method for calculating the tree height
         * It subtracts 1 to not include the root
         */
        public int Height()
        {
            return HeightCalc(root)-1;
        }
        /**
         * Private Recursive method for calculating the tree height
         */
        private int HeightCalc(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftHeight = HeightCalc(node.leftChild);
            int rightHeight = HeightCalc(node.rightChild);

            return 1 + Math.Max(leftHeight, rightHeight);
        }
        /**
         * ToString override method to print the tree from top to bottom
         * Utilizes the Portfolio's Queue class to handle each layer
         */
        public override String ToString()
        {
            if (root == null) { return ""; }
            StringBuilder sb = new StringBuilder();
            DataStructuresPortfolio.Queue<Node> q1 = new DataStructuresPortfolio.Queue<Node>();
            DataStructuresPortfolio.Queue<Node> q2 = new DataStructuresPortfolio.Queue<Node>();
            Node current = root;
            q1.Enqueue(current);

            while (!q1.IsEmpty() || !q2.IsEmpty())
            {
                while (!q1.IsEmpty())
                {
                    current = q1.Dequeue();
                    sb.Append(current.value + " ");
                    if (current.leftChild != null) { q2.Enqueue(current.leftChild); }
                    if (current.rightChild != null) { q2.Enqueue(current.rightChild); }
                }
                sb.AppendLine();
                while (!q2.IsEmpty())
                {
                    current = q2.Dequeue();
                    sb.Append(current.value + " ");
                    if (current.leftChild != null) { q1.Enqueue(current.leftChild); }
                    if (current.rightChild != null) { q1.Enqueue(current.rightChild); }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
        
        
    }

}
