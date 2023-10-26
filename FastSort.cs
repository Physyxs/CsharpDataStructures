using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPortfolio
{
    internal class FastSort
    {
        public static void MergeSort(int[] list)
        {
            if (list == null || list.Length <= 1)
            {
                return; // Array is already sorted or empty
            }

            int n = list.Length;
            int[] temp = new int[n];
            MergeSortHelper(list, temp, 0, n - 1);
        }

        private static void MergeSortHelper(int[] list, int[] temp, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSortHelper(list, temp, left, mid); // Sort left half
                MergeSortHelper(list, temp, mid + 1, right); // Sort right half
                Merge(list, temp, left, mid, right); // Merge sorted halves
            }
        }

        private static void Merge(int[] list, int[] temp, int left, int mid, int right)
        {
            // Copy elements to temporary array
            for (int m = left; m <= right; m++)
            {
                temp[m] = list[m];
            }

            int i = left; // Pointer for left subarray
            int j = mid + 1; // Pointer for right subarray
            int k = left; // Pointer for merged array

            // Merge the two sorted subarrays into the original array
            while (i <= mid && j <= right)
            {
                if (temp[i] <= temp[j])
                {
                    list[k++] = temp[i++];
                }
                else
                {
                    list[k++] = temp[j++];
                }
            }

            // Copy remaining elements from the left subarray, if any
            while (i <= mid)
            {
                list[k++] = temp[i++];
            }

            // Copy remaining elements from the right subarray, if any
            while (j <= right)
            {
                list[k++] = temp[j++];
            }
        }
    }
}
