using System;
using System.Collections.Generic;

namespace ValidParentheses
{
    class Program
    {
        // https://leetcode.com/problems/valid-parentheses/
        /*
            Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
            An input string is valid if:
                1. Open brackets must be closed by the same type of brackets.
                2. Open brackets must be closed in the correct order.
            Note that an empty string is also considered valid.
        */

        static void Main(string[] args)
        {
            var tests = new[]
            {
                new { TestString = "()", ExpectedValue = true}
                , new { TestString = "()[]{}", ExpectedValue = true}
                , new { TestString = "(]", ExpectedValue = false}
                , new { TestString = "([)]", ExpectedValue = false}
                , new { TestString = "{[]}", ExpectedValue = true}
                , new { TestString = "", ExpectedValue = true}
                , new { TestString = "]", ExpectedValue = false}
            };

            Solution solution = new Solution();

            for (int i = 0; i < tests.Length; i++)
            {
                var result = solution.IsValid(tests[i].TestString);
                var wasTestSuccessfull = result == tests[i].ExpectedValue;

                Console.WriteLine($"Test {i} has {(wasTestSuccessfull ? "succeeded" : "failed.")}");
            }
        }
    }

    public class Solution
    {
        static char[] OpeningParentheses = new char[] { '(', '[', '{' };

        public bool IsValid(string s)
        {
            var chars = s.ToCharArray();
            if (chars.Length == 0)
                return true;

            Stack<char> expectedClosingParentheses = new Stack<char>();
            for (int i = 0; i < chars.Length; i++)
            {
                // Add opening parenthesis to list
                if (isOpeningParentheses(chars[i]))
                {
                    expectedClosingParentheses.Push(GetClosingParenthesesFromOpening(chars[i]));
                    continue;
                }

                // If not opening parentheses, must be closing. Therefore check it correctly closes the latest opening
                if (expectedClosingParentheses.Count == 0)
                {
                    // found the incorrect closing parentheses
                    return false;
                }
                else if (chars[i] == expectedClosingParentheses.Peek())
                {
                    expectedClosingParentheses.Pop();
                    continue;
                }
                else
                {
                    // found the incorrect closing parentheses
                    return false;
                }
            }
            // Reached the end of the char array and there are still unclosed pairs
            return expectedClosingParentheses.Count == 0;
        }

        private bool isOpeningParentheses(char value)
        {
            for (int i = 0; i < OpeningParentheses.Length; i++)
            {
                if (OpeningParentheses[i] == value)
                    return true;
            }
            return false;
        }

        private char GetClosingParenthesesFromOpening(char openingParentheses)
        {
            switch (openingParentheses)
            {
                case '(':
                    return ')';
                case '{':
                    return '}';
                case '[':
                    return ']';
                default:
                    throw new Exception("Not a valid char supplied!");
            }
        }
    }
}
