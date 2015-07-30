namespace ListImplementations
{
	public partial class LinkedList
	{
		//Add in the front of the list
		public void AddFront(int value)
		{
			Node n = new Node(value); ;
			if (null == head)
				head = n;
			else
			{
				n.next = head;
				head = n;
			}
		}
	}
}