using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPortfolio
{
    internal class SinglyLinkedList<Ltype>
    {
        private Node head;
        private int length;


        /**
         * This Inner class is used to create Singly Linked Nodes
         */
        private class Node
        {
            public Ltype data;
            public Node next;

            public Node(Ltype item)
            {
                data = item;
                next = null;
            }
        }
        /**
         * Constructor for empty SinglyLinkedList
         */
        public SinglyLinkedList() 
        {
            head = null;
            length = 0;
        }

        /**
         * Method that adds nodes to list at user's choice of position
         * @param the data and position of the node to be inserted
         */
        public void AddAt(Ltype item, int pos)
        {
            //First Check if head is null, if so then fill it
            if (head == null)
            {
                head = new Node(item);
                length++;
            }
            //Then check position to add at
            else
            {
                if (pos < 0) { Console.WriteLine("Position not valid."); }
                //If pos = 0, call AddHead
                else if (pos == 0){ AddHead(item); }
                //If pos >= length, call AddTail
                else if (pos >= length) { AddTail(item); }
                //Else Iterate through list, attach nodes after pos to newNode.next
                //and implement similar structure to AddTail
                else
                {
                    Node oldHead = head;
                    int oldLength = length;

                    Node current = head;
                    for (int i = 0; i < pos; i++)
                    {
                        current = current.next;
                    }
                    head = new Node(item);
                    head.next = current;
                    for (int i = pos; i > 0; i--)
                    {
                        Node iter = oldHead;
                        for (int j = 0; j < i - 1; j++)
                        {
                            iter = iter.next;
                        }
                        AddHead(iter.data);
                    }
                    length = oldLength + 1;
                }
            }
        }
        /**
         * Adds a node to the beginning of the list
         * @param item: data to be inserted into head
         */
        public void AddHead(Ltype item)
        {
            Node newNode = new Node(item);
            newNode.next = head;
            head = newNode;
            length++;
            
        }
        /**
         * Adds a node to the end of the list
         * It calls the AddHead(item) method to add modify head.
         * @param item: data to be inserted into node in the list
         */
        public void AddTail(Ltype item)
        {
            Node oldHead = head;
            int oldLength = length;
            length = 0;
            head = new Node(item);

            for (int i = oldLength; i > 0; i--)
            {
                Node iter = oldHead;
                for (int j = 0; j < i-1; j++)
                {
                    iter = iter.next;
                }
                AddHead(iter.data);
            }
            length++;
        }
        /**
         * Removes the node at the given position and returns its item
         * @param pos: user given position
         * @return item: the item of the removed node
         */
        public Ltype RemoveAt(int pos)
        {
            Ltype item;
            if (head == null) { return default(Ltype); }
            else if (length == 1) { item = RemoveHead(); }
            else if (pos >= length) { item = RemoveTail(); }

            else
            {
                Node oldHead = head;
                int oldLength = length;

                Node current = head;
                for (int i = 0; i < pos; i++)
                {

                    current = current.next;
                }
                item = current.data;
                head = current.next;
                for (int i = pos; i > 0; i--)
                {
                    Node iter = oldHead;
                    for (int j = 0; j < i - 1; j++)
                    {
                        iter = iter.next;
                    }
                    AddHead(iter.data);
                }
                length = oldLength - 1;
            }
            
            return item;
        }
        /**
         * This Method removes the head of the List and returns its value
         * @return head.data
         */
        public Ltype RemoveHead()
        {
            if (head == null) { return default(Ltype); }

            Ltype item = head.data;
            head = head.next;
            length--;

            return item;
        }
        /**
         * This Method removes the tail of the List and returns its value
         * @return item: data at end of Array
         */
        public Ltype RemoveTail()
        {
            Ltype item;

            if (head == null) { return default(Ltype); }

            else if (length == 1) 
            {
                item = head.data;
                head = null; length = 0;
            }

            else
            {
                Node current = head;
                for (int i = 0; i < length - 2; i++)
                {
                    current = current.next;
                }
                item = current.next.data;

                Node oldHead = head;
                int oldLength = length-2;
                length = 0;
                head = new Node(current.data);
                for (int i = oldLength; i > 0; i--)
                {
                    Node iter = oldHead;
                    for (int j = 0; j < i - 1; j++)
                    {
                        iter = iter.next;
                    }
                    AddHead(iter.data);
                }
                length++;

            }

            return item;
        }
        /**
         * Displays the length of the SinglyLinkedList
         */
        public int Size() { return length; }

        /**
         * Overrides ToString() method to print out List
         */
        public override String ToString()
        {
            if (length == 0) { return "[]"; }

            Node current = head;
            StringBuilder sb = new StringBuilder("[");
            while(current.next != null)
            {
                sb.Append(current.data + " -> ");
                current = current.next;
            }
            sb.Append(current.data + "]");

            return sb.ToString();
        }
    }
}
