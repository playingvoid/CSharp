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
	}
}
