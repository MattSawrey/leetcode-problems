using System;

namespace SearchInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testNums = new[] { 1, 3, 5, 6 };
            int testTarget = 5;

            Solution solution = new Solution();
            Console.WriteLine(solution.SearchInsert(testNums, testTarget));
        }
    }

    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 1)
                if (target > nums[0])
                    return 1;
                else
                    return 0;

            //Start in the middle and move left or right depending on if our target is smaller or larger than the middle(floor) value.
            int index = (int)Math.Ceiling((double)nums.Length / 2);

            if (target == nums[index])
                return index;
            else if (target > nums[index]) //Target is larger than middle ceiling nums value. Move right until <=
                while (index < nums.Length)
                {
                    ++index;
                    if (index == nums.Length) //Reached the last index. Must be inserted here.
                        return index;
                    if (target <= nums[index])
                        return index;
                }
            else //Target is smaller than middle ceiling nums value. Move left until >=
                while (index > 0)
                {
                    --index;
                    if (target > nums[index]) //Reached the 0 index. Must be inserted here.
                        return index + 1;
                    if (target == nums[index])
                        return index;
                    else if (index == 0)
                        return 0;
                }

            throw new Exception("No suitable index found");
        }
    }
}
