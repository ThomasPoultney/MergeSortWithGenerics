using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> unsorted = new List<int> { 0, 1, 2, 2, 2, 2, 3, 5, 8, 4, 2, 7, 9, 21, 32 };
            List<int> sorted = MergeSort(unsorted);

            for (int i = 0; i < sorted.Count; i++)
            {
                Console.Write(sorted[i] + ",");
            }
        }


        private static List<T> MergeSort<T>(List<T> unsorted) where T : IComparable
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<T> left = new List<T>();
            List<T> right = new List<T>();

            int middle = unsorted.Count / 2;

            left = unsorted.GetRange(0, middle);
            right = unsorted.GetRange(middle, unsorted.Count - middle);
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<T> Merge<T>(List<T> left, List<T> right) where T : IComparable
        {
            List<T> result = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First().CompareTo(right.First()) <= 0)
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
