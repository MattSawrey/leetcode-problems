using System;

namespace LongestCommonPrefix
{
    //Write a function to find the longest common prefix string amongst an array of strings.

    //If there is no common prefix, return an empty string "".

    //Example 1:

    //Input: ["flower","flow","flight"]
    //Output: "fl"

    //Example 2:

    //Input: ["dog","racecar","car"]
    //Output: ""
    //Explanation: There is no common prefix among the input strings.

    //Note:

    //All given inputs are in lowercase letters a-z.

    class Program
    {
        static string[] test1 = new string[] { "flower", "flow", "flight" };
        static string[] test2 = new string[] { "dog", "racecar", "car" };
        static string[] test3 = new string[] { };

        static void Main(string[] args)
        {
            Console.WriteLine(LongestCommonPrefix(test1) + ". Should = 'fl'");
            Console.WriteLine(LongestCommonPrefix(test2) + ". Should = ''");
            Console.WriteLine(LongestCommonPrefix(test3) + ". Should = ''");
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            char[] commonPrefixCharArray = null;
            for (int i = 0; i < strs.Length; i++)
            {
                if (i == 0)
                {
                    commonPrefixCharArray = strs[i].ToCharArray();
                    continue;
                }
                char[] charArray = strs[i].ToCharArray();
                for (int x = 0; x < commonPrefixCharArray.Length; x++)
                {
                    //if the compare to array 
                    if (x > charArray.Length - 1 || commonPrefixCharArray[x] != charArray[x])
                    {
                        Array.Resize(ref commonPrefixCharArray, x);
                        continue;
                    }
                }
            }
            return new string(commonPrefixCharArray);
        }
    }
}
