using System;

namespace ReverseInteger
{
    class Program
    {
        // https://leetcode.com/problems/reverse-integer/
        // Given a 32-bit signed integer, reverse digits of an integer.

        static void Main(string[] args)
        {
            int testNumber = 123456789;
            Solution solution = new Solution();
            Console.WriteLine(solution.Reverse(testNumber));
        }
    }

    public class Solution
    {
        public int Reverse(int x)
        {
            long result = 0;
            while (x != 0)
            {
                decimal xDividedByTen = (decimal)x / 10;
                int numberToAdd = (int)((xDividedByTen - Math.Truncate(xDividedByTen)) * 10); //Retreive the last digit from x

                //Assign the new result, but check that it doesn't overflow int. Overflow assignments to int don't throw an error in c#
                long newResult = (result * 10) + numberToAdd;
                if (newResult >= int.MaxValue || newResult <= int.MinValue)
                    return 0;
                else
                    result = newResult;

                x = (x - numberToAdd) / 10; //removes a digit from the end of x
            }
            return (int)result;
        }
    }
}
