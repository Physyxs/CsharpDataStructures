using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPortfolio
{
    internal class MaxHeap
    {
        private int[] heap;
        private int size;
        /**
         * Constructor that creates a MaxHeap with a given capacity
         */
        public MaxHeap(int capacity)
        {
            heap = new int[capacity];
            size = 0;
        }
        /**
         * Checks whether the MaxHeap is Empty
         */
        public bool IsEmpty()
        {
            return size == 0;
        }
        /**
         * Returns the number of items in the MaxHeap
         */
        public int Size()
        {
            return size;
        }
        /**
         * Adds an integer to the MaxHeap
         */
        public void Add(int item)
        {
            if (size == heap.Length)
            {
                throw new InvalidOperationException("Heap is full");
            }

            heap[size] = item;
            HeapifyUp(size);
            size++;
        }
        /**
         * Switches the value of the max value when values are added
         */
        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && heap[index] > heap[parentIndex])
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }
        /**
         * Removes the max value from the Heap and returns it
         */
        public int Next()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Heap is empty");
            }

            int max = heap[0];
            heap[0] = heap[size - 1];
            size--;
            HeapifyDown(0);

            return max;
        }
        /**
         * Replaces the value of the max integer after previous value is removed
         */
        private void HeapifyDown(int index)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int largest = index;

            if (leftChild < size && heap[leftChild] > heap[largest])
            {
                largest = leftChild;
            }

            if (rightChild < size && heap[rightChild] > heap[largest])
            {
                largest = rightChild;
            }

            if (largest != index)
            {
                Swap(index, largest);
                HeapifyDown(largest);
            }
        }
        /**
         * Helper method that handles swapping values in the MaxHeap
         */
        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
        /**
         * Creates an IEnumerable<int> of all the values in the MaxHeap
         */
        public IEnumerable<int> SortedVals()
        {
            MaxHeap sortedHeap = new MaxHeap(size);

            for (int i = 0; i < size; i++)
            {
                sortedHeap.Add(heap[i]);
            }

            while (!sortedHeap.IsEmpty())
            {
                yield return sortedHeap.Next();
            }
        }
        /**
         * Will take an array and build a MaxHeap
         */
        public void HeapSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0);
            }
        }
        /**
         * Helper method for HeapSort(int[] arr) that maintains heap property
         */
        private void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                Heapify(arr, n, largest);
            }
        }    
        

    }
}
