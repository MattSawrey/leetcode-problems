using System;
using System.Linq;
using System.Collections.Generic;

namespace Permutations
{
    class Program
    {
        // Given a collection of distinct integers, return all possible permutations
        // Input: [1,2,3]
        // Output:
        // [
        //   [1,2,3],
        //   [1,3,2],
        //   [2,1,3],
        //   [2,3,1], 
        //   [3,1,2],
        //   [3,2,1]
        // ]

        static int[] nums = { 1, 2, 3 };

        static void Main(string[] args)
        {
            var permutations = Permute(nums).ToArray();

            for(int i = 0; i < permutations.Length; i++)
            {
                for(int y = 0; y < permutations[i].Count; y++)
                {
                    Console.WriteLine(permutations[i].ToArray().ArrayToString());
                }
            }
            Console.WriteLine("Hello World!");
        }

        public static IList<IList<int>> Permute(int[] nums) 
        {
            // Formula for total number of possible permutations.
            // Loop over every element in an array, placing that element at the start of the returned permutation.
            // Then the number of possible permuations from that elements is


            IList<IList<int>> permutations = new List<IList<int>>();

            // For each element in the array
            for(int i = 0; i < nums.Length; i++)
            {
                List<int> currentPermutation = new List<int>();
                currentPermutation.AddRange(nums.ToList());

                int currentElement = currentPermutation[i];
                currentPermutation.RemoveAt(i);

                // Shift each value iteratively back
                for(int q = 0; q < nums.Length; q++)
                {
                    int indexToInsert = q;
                    if(q > i)
                        indexToInsert--;

                    currentPermutation.Insert(indexToInsert, currentElement);
                    permutations.Add(currentPermutation);
                }
            }

            return permutations;
        }
    }

    public static class ArrayExtensions
    {
        public static string ArrayToString (this int[] array)
        {
            string text = "[";
            for(int i = 0; i < array.Length; i++)
            {
                if(i != 0)
                    text += ", ";
                text += array[i];
            }
            text += "]";
            return text;
        }
    }
}
