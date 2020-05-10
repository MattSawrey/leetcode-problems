using System;

namespace MergeSortedLists
{
    class Program
    {
        // https://leetcode.com/problems/merge-two-sorted-lists/
        // Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.

        static void Main(string[] args)
        {
            // Defining list node 1
            ListNode a = new ListNode(-9);
            ListNode b = new ListNode(-7);
            ListNode c = new ListNode(-3);
            ListNode d = new ListNode(-3);
            ListNode e = new ListNode(-1);
            ListNode f = new ListNode(2);
            ListNode g = new ListNode(3);
            a.next = b;
            b.next = c;
            c.next = d;
            d.next = e;
            e.next = f;
            f.next = g;

            //1->2->4

            // Defining list node 2
            ListNode a2 = new ListNode(-7);
            ListNode b2 = new ListNode(-7);
            ListNode c2 = new ListNode(-6);
            ListNode d2 = new ListNode(-6);
            ListNode e2 = new ListNode(-5);
            ListNode f2 = new ListNode(-3);
            ListNode g2 = new ListNode(2);
            ListNode h2 = new ListNode(4);
            a2.next = b2;
            b2.next = c2;
            c2.next = d2;
            d2.next = e2;
            e2.next = f2;
            f2.next = g2;
            g2.next = h2;
            //1->3->4

            Solution solution = new Solution();
            Console.WriteLine(solution.MergeTwoLists(a, a2));
        }
    }

    public class Solution
    {
        // Takes in initial nodes of Linked Lists.
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            // end the merging if either node is null, as the fact that the remaining list is sorted means the remaining list is ordered correctly.
            if (l1 == null)
                return l2;
            else if (l2 == null)
                return l1;

            if (l1.val <= l2.val)
            {
                MergeTwoLists(l1.next, l2);
                if (l1.next == null || l2.val < l1.next.val)
                    l1.next = l2;
                return l1;
            }
            else
            {
                MergeTwoLists(l2.next, l1);
                if (l2.next == null || l1.val < l2.next.val)
                    l2.next = l1;
                return l2;
            }
        }
    }

    // ListNode Definition
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public override string ToString()
        {
            return val.ToString() + (next != null ? ", " + next.ToString() : "");
        }
    }
}
