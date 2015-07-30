using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListImplementations
{
	class Program
	{
		static void Main(string [ ] args)
		{
			//Test list reversal
			TestListReversal();
			Console.ReadLine();
		}

		private static void TestListReversal()
		{
			LinkedList linkList = new LinkedList();
			linkList.AddFront(1);
			linkList.AddFront(2);
			linkList.AddFront(3);
			linkList.AddFront(4);
			Console.Out.WriteLine("Current List: " + linkList);
			linkList.ReverseRecursive();
			Console.Out.WriteLine("After recursivly reversing List: " + linkList);
			linkList.ReverseIterative();
			Console.Out.WriteLine("After iteratively reversing List: " + linkList);
		}
	}
}
