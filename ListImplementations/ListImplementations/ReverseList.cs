using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListImplementations
{
	public partial class LinkedList
	{
		public void ReverseRecursive()
		{
			head = ReverseRecursive(head);
		}

		public void ReverseIterative()
		{
			head = ReverseIterative(head);
		}

		private static Node ReverseRecursive(Node head)
		{
			if (null == head) return null;
			Node nextToRoot = head.next;
			
			if (null == nextToRoot) return head;

			Node reversedHead = ReverseRecursive(nextToRoot);
			nextToRoot.next = head;
			head.next = null;
			return reversedHead;
		}

		private static Node ReverseIterative(Node head)
		{
			Node reversedhead = null;
			Node curr = head;
			while(null != curr)
			{
				Node temp = curr.next;
				curr.next = reversedhead;
				reversedhead = curr;
				curr = temp;
			}
			return reversedhead;
		}
	}
}
