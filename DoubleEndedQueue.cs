using DataStrucures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPortfolio
{
    public class Customer
    {
        public int items;

        public Customer()
        {
            Random random = new Random();
            items = random.Next(5, 25);
        }
    }
    public class Store
    {
        private int lines;
        private int customers;
        private DoubleEndedQueue<Customer>[] store;

        public Store(int numLines = 4, int numCustomers = 12)
        {
            lines = numLines;
            customers = numCustomers;
            store = new DoubleEndedQueue<Customer>[lines];
            for (int i = 0; i < lines; i++)
            {
                Random rand = new Random();
                int customerPerLine = rand.Next(0, numCustomers);

                for (int j = 0; j < customerPerLine; j++)
                {
                    store[i].Enq_Back(new Customer());
                }
                numCustomers -= customerPerLine;
            }
        }
        public bool LineIsEmpty(int i)
        {
            return store[i].IsEmpty();
        }
        public void SimulatePurchase()
        {
            
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < lines; i++)
            {
                sb.Append("Line " + i);
            }
            sb.AppendLine();
            for(int i = 0; i < lines; i++)
            {
                for(int j = 0; j < store[i].Size(); j++)
                {
                    
                }
            }

            return sb.ToString();
        }

    }
    public class DoubleEndedQueue<T>
    {
        private T[] elements;
        private int front;
        private int back;
        private int size;

        
        public DoubleEndedQueue(int capacity = 10)
        {
            elements = new T[capacity];
            front = -1;
            back = 0;
            size = 0;
        }
        
        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == elements.Length;
        }

        public int Size()
        {
            return size;
        }

        public void Enq_Front(T item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Deque is full");
            }

            if (front == -1)
            {
                front = 0;
                back = 0;
            }
            else if (front == 0)
            {
                front = elements.Length - 1;
            }
            else
            {
                front--;
            }

            elements[front] = item;
            size++;
        }

        public void Enq_Back(T item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Deque is full");
            }

            if (front == -1)
            {
                front = 0;
                back = 0;
            }
            else if (back == elements.Length - 1)
            {
                back = 0;
            }
            else
            {
                back++;
            }

            elements[back] = item;
            size++;
        }

        public T Deq_Front()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Deque is empty");
            }

            T item = elements[front];

            if (front == back)
            {
                front = -1;
                back = -1;
            }
            else if (front == elements.Length - 1)
            {
                front = 0;
            }
            else
            {
                front++;
            }

            size--;
            return item;
        }

        public T Deq_Back()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Deque is empty");
            }

            T item = elements[back];

            if (front == back)
            {
                front = -1;
                back = -1;
            }
            else if (back == 0)
            {
                back = elements.Length - 1;
            }
            else
            {
                back--;
            }

            size--;
            return item;
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Deque is empty");
            }

            return elements[front];
        }

        public T GetBack()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Deque is empty");
            }

            return elements[back];
        }
    }

}
