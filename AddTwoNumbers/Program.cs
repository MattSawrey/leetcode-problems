using System;
using System.Linq;

namespace AddTwoNumbers
{
    class Program
    {
        // https://leetcode.com/problems/add-two-numbers/
        /*
            You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
            You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        */
        static void Main(string[] args)
        {         
            ListNode a1 = new ListNode(9);
            ListNode a2 = new ListNode(4);
            ListNode a3 = new ListNode(3);
            a1.next = a2;
            a2.next = a3;

            ListNode b1 = new ListNode(1);
            ListNode b2 = new ListNode(9);
            ListNode b3 = new ListNode(9);
            ListNode b4 = new ListNode(9);
            ListNode b5 = new ListNode(9);
            ListNode b6 = new ListNode(9);
            ListNode b7 = new ListNode(9);
            ListNode b8 = new ListNode(9);
            ListNode b9 = new ListNode(9);
            ListNode b10 = new ListNode(9);
            b1.next = b2;
            b2.next = b3;
            b3.next = b4;
            b4.next = b5;
            b5.next = b6;
            b6.next = b7;
            b7.next = b8;
            b8.next = b9;
            b9.next = b10;

            Solution solution = new Solution();
            Console.WriteLine(solution.AddTwoNumbers(a1, b1).ToString());
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
        {
            var numString1 = "";
            var numString2 = "";

            do
            {
                numString1 += l1.val.ToString();
                l1 = l1.next;
            } while(l1 != null);
            numString1 = new string(numString1.Reverse().ToArray());
            var numString1CharArray = numString1.ToCharArray();
            Array.Reverse(numString1CharArray);

            do
            {
                numString2 += l2.val.ToString();
                l2 = l2.next;
            } while(l2 != null);
            numString2 = new string(numString2.Reverse().ToArray());
            var numString2CharArray = numString2.ToCharArray();
            Array.Reverse(numString2CharArray);

            var maxLength = numString1CharArray.Length > numString2CharArray.Length ? numString1CharArray.Length : numString2CharArray.Length;

            ListNode currentNode = null;

            int carried = 0;
            string val = "";
            for (int i = 0; i < maxLength; i++)
            {
                int l1Add = 0;
                if (i < numString1CharArray.Length)
                    l1Add = numString1CharArray[i] - '0';

                int l2Add = 0;
                if (i < numString2CharArray.Length)
                    l2Add = numString2CharArray[i] - '0';

                var toAddTotal = (l1Add + l2Add) + carried;
                var toAddMod = toAddTotal % 10;

                val += toAddMod;

                carried = (toAddTotal - toAddMod) / 10;
            }
            if (carried > 0)
                val += carried;

            var valArray = val.ToCharArray();
            Array.Reverse(valArray);

            for (int i = 0; i < valArray.Length; i++)
            {
                ListNode newNode = new ListNode(valArray[i] - '0');
                newNode.next = currentNode;
                currentNode = newNode;
            }

            return currentNode;
        }
    }

    // Definition for singly-linked list.
    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public override string ToString()
        {
            return $"{val.ToString()}{(next != null ? "," + next.ToString() : "")}";
        }
    }
}
