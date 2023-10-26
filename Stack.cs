using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace DataStructuresPortfolio 
{ 
    internal class Stack<Stype>
    {
        private Node head;  // a pointer to the Peek node in the stack.
        private Node bottom;  // a pointer to the bottom node in the stack.
        private int length;  // the number of nodes in the stack.


        public class Node
        {
            public Stype data;  // the data value stored in the node.
            public Node next;  // a pointer to the next node that was added to the
                                // stack.
            public Node prev;  // a pointer to the previous node that was added to
                                // the stack.
        }


        /**
        * Creates an empty stack
        */
        public Stack()
        {
            head = null;
            bottom = null;
            length = 0;
}


        public int Size()
        {
        return length;
        }


        /**
         * Determines whether the stack is empty.
         * @return true if the stack is empty; otherwise, false
         */
        public bool IsEmpty()
        {
            return length == 0;
        }


        /**
         * Adds a node at the top of the stack.
         * @param data the data value to be added.
         */
        public void Push(Stype data)
        {
            Node newNode = new Node();
            newNode.data = data;
            newNode.next = null;
            if (length == 0)
            {
                newNode.prev = null;
                head = newNode;
                bottom = newNode;
            }
            else
            {
                newNode.prev = head;
                head.next = newNode;
                head = newNode;
            }
            length++;
        }


        /**
         * @return the data value in the top node of a non-empty stack.
         * @throws Exception when the stack is empty.
         */
        public Stype Peek()
        {
            if(length == 0)
            {
                throw new Exception("Non-empty stack expected");
            }
            return head.data;
        }


        /**
         * Removes the top node of a non-empty stack.
         * @return the data value in the top node that was removed.
         * @throws Exception when the stack is empty.
         */
        public Stype Pop()
        {
                if(length == 0){
                throw new Exception("Non-empty stack expected");
            }
            Stype data = head.data;
                if(length == 1){
                head = null;
                bottom = null;
            }
                else{
                head = head.prev;
                head.next = null;
            }
            length--;
                return data;
        }


        /**
         * Moves the top node of the stack to its bottom or does nothing
         * if the stack contains less than two elements.
         */
        public void moveTopNodeToBottom()
        {
            if (length >= 2)
            {
                Node node = head;
                head = head.prev;
                head.next = null;
                node.prev = null;
                node.next = bottom;
                bottom.prev = node;
                bottom = node;
            }
        }


        /**
         * Moves the bottom node of the stack to its Peek or does nothing
         * if the stack contains less than two elements.
         */
        public void moveBottomNodeToTop()
        {
            if (length >= 2)
            {
                Node node = bottom;
                bottom = bottom.next;
                bottom.prev = null;
                node.next = null;
                node.prev = head;
                head.next = node;
                head = node;
            }
        }


        /**
         * Returns a string [en-1, ..., e2, e1, e0] representing this stack, 
         * where e0 is the data item in the top node and en-1 is the data item
         * in the bottom node. It returns [] if this stack is empty.     
         */
        public override string ToString()
        {
            string str = "]";
            if (length > 0)
            {
                Node node = head;
                str = node.data + str;
                while (node.prev != null)
                {
                    node = node.prev;
                    str = node.data + ", " + str;
                }
            }
            str = "[" + str;
            return str;
        }    
    }

}