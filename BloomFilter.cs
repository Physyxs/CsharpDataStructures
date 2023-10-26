using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataStructuresPortfolio
{
    class BloomFilter
    {
        private BitArray bitArray;
        private int size;
        private int numIndices = 4; //represents 4 indices

        /**
         * Constructor for BloomFilter with default of 100 bins
         */
        public BloomFilter(int numBins = 100)
        {
            size = numBins;
            bitArray = new BitArray(numBins);
        }
        /**
         * Method that adds a string to the Bloom Filter
         */
        public void Add(string item)
        {
            byte[] itemBytes = Encoding.UTF8.GetBytes(item);
            byte[] md5Hash = MD5.Create().ComputeHash(itemBytes);
            byte[] sha256Hash = SHA256.Create().ComputeHash(itemBytes);

            for (int i = 0; i < numIndices; i++)
            {
                int index = GetIndex(md5Hash, sha256Hash, i);
                bitArray.Set(index, true);
            }
        }
        /**
         * Method the checks whether an item is in the BloomFilter
         */
        public bool Has(string item)
        {
            byte[] itemBytes = Encoding.UTF8.GetBytes(item);
            byte[] md5Hash = MD5.Create().ComputeHash(itemBytes);
            byte[] sha256Hash = SHA256.Create().ComputeHash(itemBytes);

            for (int i = 0; i < numIndices; i++)
            {
                int index = GetIndex(md5Hash, sha256Hash, i);
                if (!bitArray.Get(index))
                {
                    return false;
                }
            }

            return true;
        }
        /**
         * Helper Method for handling the index of each item, used for Add(item) and Has(item)
         */
        private int GetIndex(byte[] md5Hash, byte[] sha256Hash, int iteration)
        { 
            int md5HalfLength = md5Hash.Length / 2;
            int sha256HalfLength = sha256Hash.Length / 2;

            int md5Index = BitConverter.ToInt32(md5Hash, iteration % md5HalfLength) % size;
            int sha256Index = BitConverter.ToInt32(sha256Hash, (iteration + md5HalfLength) % sha256HalfLength) % size;

            return Math.Abs(md5Index + sha256Index) % size;
        }
    }

}
