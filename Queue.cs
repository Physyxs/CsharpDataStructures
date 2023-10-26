using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructuresPortfolio
{
    internal class Queue<Qtype>
    {

        private Node rear;
        private Node front;
        private int length;


        /**
         * this inner class is used to create nodes of a singly-linked queue
         */
        private class Node
        {
            public Qtype data;
            public Node? next;

            public Node(Qtype item)
            {
                data = item;
                next = null;
            }
        }


        /**
         * Creates an empty singly-linked queue
         */
        public Queue()
        {
            length = 0;
            front = null;
            rear = null;
        }

        /**
         * Returns the length of the Queue
         * @return int of length
         */
        public int Size()
        {
            return length;
        }


        /**
         * Determines whether the queue is empty.
         * @return true if the queue is empty;
         * otherwise, false
         */
        public bool IsEmpty()
        {
            return front == null;
        }


        /**
         * Inserts an item at the back of the queue.
         * @param data: the value to be inserted.
         */
        public void Enqueue(Qtype data)
        {
            Node newNode = new Node(data);
            if (rear == null)
            {
                newNode.next = newNode;
                rear = newNode;
                front = newNode;
            }
            else
            {
                newNode.next = rear.next;
                rear.next = newNode;
                rear = newNode;
                rear.next = front;
            }
            length++;
        }


        /**
         * Accesses the item at the front of a non-empty queue
         * @return item at the front of the queue.
         * @throws Exception when this queue is empty
         */
        public Qtype Peek()
        {
            return front.data;
        }


        /**
         * Deletes the item at the front of the queue.
         * @return item at the front of the queue.
         * @throws Exception when this queue is empty
         */
        public Qtype Dequeue()
        {
            if (rear == null)
            {
                return default(Qtype);
            }
            Qtype value = front.data;
            if (rear == front)
            {
                rear = null;
                front = null;
            }
            else
            {
                rear.next = front.next;
                front = front.next;
            }
            length--;
            return value;
        }

        /**
         * Returns a string representing this queue, 
         * It starts with the front node and ends with rear
         * It returns [] if this queue is empty.     
         */
        public override System.String ToString()
        {
            if (rear == null)
            {
                return "[]";
            }
            StringBuilder sb = new StringBuilder("[");
            Node current = front;
            for (int i = 0; i < length - 1; i++)
            {
                sb.Append(current.data + ", ");
                current = current.next;
            }
            sb.Append(current.data + "]");
            return sb.ToString();

        }
    }
    
}
