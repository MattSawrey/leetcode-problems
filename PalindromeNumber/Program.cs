using System;

namespace PalindromeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int testValTrue = 12321;
            int testValFalse1 = 123421;
            int testValFalse2 = -1;

            Solution solution = new Solution();
            Console.WriteLine(solution.IsPalindrome(testValTrue));
            Console.WriteLine(solution.IsPalindrome(testValFalse1));
            Console.WriteLine(solution.IsPalindrome(testValFalse2));
        }
    }

    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            int[] digits = ToIntArray(x);

            if (digits.Length == 1)
                return true;

            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != digits[digits.Length - (i + 1)])
                    return false;
            }

            return true;
        }

        public int[] ToIntArray(int num)
        {
            int[] intArray = new int[NumDigits(num)];
            int iterator = intArray.Length - 1;
            for (int i = (int)Math.Pow(10, iterator); i >= 1; i /= 10)
            {
                intArray[iterator] = (int)Math.Floor((decimal)num / i);
                num -= intArray[iterator] * i;
                iterator--;
            }
            return intArray;
        }

        public int NumDigits(int testNum)
        {
            long longTestNum = Math.Abs((long)testNum);
            long testMagnitude = 10;
            int numDigits = 1;
            while (true)
            {
                if (longTestNum < testMagnitude)
                    return numDigits;

                numDigits++;
                testMagnitude *= 10;
            }
        }
    }
}
