using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPortfolio
{
    public class HashTable<Htype>
    {
        private LinkedList<Htype>[] buckets;
        private int capacity;
        /**
         * Constructor for HashTable with default of 100 bins
         */
        public HashTable(int numbins = 100)
        {
            capacity = numbins;
            buckets = new LinkedList<Htype>[numbins];

            for (int i = 0; i < numbins; i++)
            {
                buckets[i] = new LinkedList<Htype>();
            }
        }
        /**
         * Helper Method for generating hashcode
         */
        private int GetBucketIndex(Htype item)
        {
            int hashCode = item.GetHashCode();
            return Math.Abs(hashCode) % capacity;
        }
        /**
         * Method for adding an item into the HashTable
         */
        public void Add(Htype item)
        {
            int bucketIndex = GetBucketIndex(item);
            var bucket = buckets[bucketIndex];

            foreach (var value in bucket)
            {
                if (value.Equals(item))
                {
                    throw new ArgumentException("An element with the same value already exists in the HashTable.");
                }
            }

            bucket.AddLast(item);
        }
        /**
         * Method to check whether an item is in the HashTable
         */
        public bool Has(Htype item)
        {
            int bucketIndex = GetBucketIndex(item);
            var bucket = buckets[bucketIndex];

            foreach (var value in bucket)
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }
        /**
         * Method for removing a given item from the HashTable
         * @returns value: the value if item is found
         */
        public Htype? Remove(Htype item)
        {
            int bucketIndex = GetBucketIndex(item);
            var bucket = buckets[bucketIndex];

            var node = bucket.First;

            while (node != null)
            {
                var value = node.Value;

                if (value.Equals(item))
                {
                    bucket.Remove(node);
                    return value;
                }

                node = node.Next;
            }

            throw new ArgumentException("Item not found in HashTable.");
        }
        /**
         * Method for clearing the entire HashTable
         */
        public void Clear()
        {
            for (int i = 0; i < capacity; i++)
            {
                buckets[i].Clear();
            }
        }
        /**
         * Method for counting the number of items in the HashTable
         * @returns count: the number of items in the HashTable
         */
        public int Count()
        {
            int count = 0;

            foreach (var bucket in buckets)
            {
                count += bucket.Count;
            }

            return count;
        }
    }

}
