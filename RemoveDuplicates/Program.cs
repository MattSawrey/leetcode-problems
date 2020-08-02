using System;

namespace RemoveDuplicates
{
  // Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
  // Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

  class Program
  {
    static void Main(string[] args)
    {
      var testArray1 = new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
      var testArray2 = new[] { 0 };
      var testArray3 = new[] { 2, 2 };

      Console.WriteLine("Should be 5 = " + RemoveDuplicates(testArray1));
      Console.WriteLine("Should be 1 = " + RemoveDuplicates(testArray2));
      Console.WriteLine("Should be 1 = " + RemoveDuplicates(testArray3));
    }

    public static int RemoveDuplicates(int[] nums)
    {
      if (nums == null || nums.Length == 0)
        return 0;

      int distinctIndex = 0;

      for (int index = 0; index < nums.Length; index++)
      {
        if (index == 0 || nums[index] > nums[index - 1])
        {
          nums[distinctIndex] = nums[index];
          distinctIndex++;
        }
      }

      return distinctIndex;
    }
  }
}
