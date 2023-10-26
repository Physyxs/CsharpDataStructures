using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPortfolio
{
    internal class DynamicArray<Atype>
    {
        private Atype[] array;
        private int size;
        private int length;

        public DynamicArray()
        {
            length = 1;
            size = 0;
            array = new Atype[length];
        }
        
        public void Add(Atype item, int pos)
        {
            //Check if array is full
            if(size == length)
            {
                SizeUp();
            }
            //Check if pos out of bounds
            if(pos < 0 || pos > size)
            {
                Console.WriteLine("Not a possible insert position.");
            }
            else 
            {
                //Check if array[pos] is full
                if (array[pos] != null)
                {
                    ShiftUp(pos);
                }
                
                array[pos] = item;
                size++;
            }
        }

        public dynamic Remove(int pos)
        {
            dynamic item;
            //Check if pos out of bounds
            if (pos < 0 || pos > size - 1)
            {
                Console.WriteLine("No item in this position.");
                item = null;
            }
            else
            {
                item = array[pos];
                ShiftDown(pos);
            }
            
            return item;
        }

        public int Size()
        {
            return size;
        }
        private void ShiftDown(int pos)
        {
            for (int i = pos; i < size -1; i++)
            {
                array[i] = array[i + 1];
            }
            //array[Size - 1] = null;
            size--;
        }
        private void ShiftUp(int pos)
        {
            for (int i = 0; i < size - pos; i++)
            {
                array[size - i] = array[size - i - 1];
            }
        }
        private void SizeUp()
        {
            length *= 2;
            Atype[] temp = array;
            array = new Atype[length];
            for (int i = 0; i < size; i++)
            {
                array[i] = temp[i];
            }
        }
        public Atype Set(Atype item, int pos)
        {
            Atype temp = array[pos];
            array[pos] = item;
            item = temp;

            return item;
        }
        public override String ToString()
        {
            if(size == 0) { return "[]"; }

            StringBuilder sb = new StringBuilder("[");
            for (int i = 0; i < size-1; i++)
            {
                sb.Append(array[i]+", ");
            }
            sb.Append(array[size-1] + "]");
            return sb.ToString();
        }
    }
}
