using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListImplementations
{
	public partial class LinkedList
	{
		private class Node
		{
			public int value;
			public Node next;
			public Node(int value)
			{
				this.value = value;
				this.next = null;
			}

			public override string ToString()
			{
				return value.ToString();
			}
		}

		private Node head;

		public LinkedList()
		{
			head = null;
		}

		public override string ToString()
		{
			Node curr = head;
			StringBuilder sb = new StringBuilder();
			while(null != curr)
			{
				sb.AppendFormat("{0} -> ", curr);
				curr = curr.next;
			}

			sb.Append("NULL");
			return sb.ToString();
		}
	}
}
