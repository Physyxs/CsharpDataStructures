using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructuresPortfolio
{
    internal class SlowSort
    {
        public static void BubbleSort(int[] list)
        {
            bool swap;

            for (int i = 0; i < list.Length - 1; i++)
            {
                swap = false;

                for (int j = 0; j < list.Length - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        // Swap list[j] and list[j + 1]
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swap = true;
                    }
                }

                // If no two elements were swapped in the inner loop, the array is already sorted
                if (!swap)
                {
                    break;
                }
            }

        }
    }
}