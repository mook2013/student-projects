package listtester;

public class LinkedList<T extends Comparable>
{
    private Node<T> head = new Node(0);		// Dummy head node, contains no data..
    private int length = 0;

    public LinkedList()
    {
    }

    public void addNode(T element)
    {
	Node current = head;
	while (current.next != null)
	{
	    current = current.next;
	}
	current.next = new Node(element);
	length++;
    }

    //Remove by index
    public void removeNode(int i)
    {

	if (i < 1 || i > length)
	{
	    System.out.println("Attempted to remove node " + i + ". No such index.");
	    return;
	}

	Node current = head;
	for (int j = 0; j < i - 1; j++)	// Cycle until 2 before target
	{
	    if (current.next == null)
	    {
		System.out.println("Attempted to remove node " + i + ". No such index.");
		return;
	    }
	    current = current.next;
	}
	current.next = current.next.next;

	length--;
    }

    // Remove by content. Return count.
    public int removeNodes(Integer num)
    {
	int removed = 0;
	Node previous = head;
	Node current = head.next;
	while(current != null)			// Check through very end
	{
	    if (current.data == num)
	    {
		previous.next = current.next;	//Dereference node to be removed.
		current = current.next;
		length--;
		removed++;
	    }
	    else
	    {
		previous = current;		//Step along.
		current = current.next;
	    }
	}

	return removed;
    }

    public void clear()
    {
	head.next = null;
	length = 0;
    }

    public T getNode(int n)
    {
	Node current = head;
	for (int i = 0; i < n; i++)
	{
	    current = current.next;
	}
	return (T)current.data;
    }

    public void sort() // Bubble Sort
    {
	Node<T> cur = head;
	for (int i = 1; i < length; i++)
	{
	    for (int j = 0; j < length - i; j++)
	    {
		if (cur.data.compareTo(cur.next.data) > 0)
		{
		    T tmp = cur.data;
		    cur.data = cur.next.data;
		    cur.next.data = tmp;
		}
		cur = cur.next;
	    }
	    cur = head; //Start back at beginning.
	}
    }

//--------Old recursive version-------//

//    public void sort(int count)
//    {
//	if (count == 0)	//Needed for recursion.
//	{
//	    count = length;
//	}
//
//	int progress = 0;
//	Node<T> current = head.next;
//	Node<T> previous;
//
//	//first pass
//	while (progress < count - 1)
//	{
//	    progress++;
//	    previous = current;
//	    current = current.next;
//	    if (previous.data.compareTo(current.data) > 0)
//	    {
//		swap(previous, current);
//	    }
//
//	}
//	if (count > 2)
//	{
//	    sort(count - 1);	    //Recursively call sort method.
//	}
//    }

//    public void swap(Node<T> one, Node<T> two)
//    {
//	// Swap data only!
//	// There's no reason to swap actual nodes :D
//	T tmp;
//	tmp = one.data;
//	one.data = two.data;
//	two.data = tmp;
//    }

    
    // Static method to get even elements in a list of Integers (only).
    public static <T> LinkedList<Integer> getEvens(LinkedList<Integer> list)
    {

	LinkedList<Integer> even = new LinkedList();

	Node<Integer> current = list.head;
	while (current.next != null)
	{
	    current = current.next;
	    if (current.data % 2 == 0)
	    {
		even.addNode(current.data);
	    }
	}

	return even;
    }

    @Override
    public String toString()
    {
	String str = "";
	Node current = head;
	while (current.next != null)
	{
	    current = current.next;
	    str += String.valueOf(current.data) + "\n";
	}
	return str;
    }

    public String toReverseString()
    {
	String str = "";
	Node current = head;
	while (current.next != null)
	{
	    current = current.next;
	    str = String.valueOf(current.data) + "\n" + str;
	}
	return str;
    }

    public void printNth(int n)
    {
	Node current = head;
	while (current.next != null)
	{
	    //current = current.next;
	    for (int i = 0; i < n; i++)
	    {
		if (current.next == null)    //to skip printing last node.
		{
		    return;
		}
		current = current.next;
	    }
	    System.out.println(current.data);

	}
    }

//////////////////////////////////////////////////////////////////////////
		    ////  Node class /////
//////////////////////////////////////////////////////////////////////////

    private static class Node<T>
    {

	public Node<T> next = null;
	public T data;

	public Node(T elem)
	{
	    data = elem;
	}
    }

}
