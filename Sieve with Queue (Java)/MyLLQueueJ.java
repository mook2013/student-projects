// Zachariah Kendall
// Here I wrote my own queue that implements the Queue interface.
// For this I had to write my own iterator, which was a learning experience.
// This took longer than I expected.
// Compared to the built in datastructures, mine is HORRIBLY slow.
// I suspect the bottleneck is in the iterator :(


import java.util.Collection;
import java.util.Iterator;
import java.util.NoSuchElementException;
import java.util.Queue;

public class MyLLQueueJ<T> implements Queue
{
    private Node<T> head = null;
    private Node<T> tail = null;
    private Count size = new Count();

    public MyLLQueueJ()
    {
    }

    @Override
    public void clear()
    {
        head.next = null;
        tail = null;
        size.zero();
    }

    @Override
    public String toString()
    {
        String str = "";
        Node current = head;
        while (current != null)
        {
            str += String.valueOf(current.data) + " ";
            current = current.next;
        }
        return str;
    }

    @Override
    public boolean add(Object e)
    {
        Node n = new Node(e);
        if (isEmpty())
            head = n;
        else
            tail.next = n;
        tail = n;

        size.add();
        return true;
    }

    @Override
    public boolean offer(Object e)
    {
        // Since it's a linked list, we'll 'never' run out of capacity
        // ergo no reason to return false.
        Node n = new Node(e);
        if (isEmpty())
            head = n;
        else
            tail.next = n;
        tail = n;

        size.add();
        return true;
    }

    @Override
    public T remove()
    {
        if(isEmpty())
            throw new NoSuchElementException ();

        Node ret = head;
        head = head.next;
        if (head==tail)
            tail = null;
        size.substract();
        return (T) ret.data;
    }

    @Override
    public T poll()
    {
        if(isEmpty())
            return null;

        Node ret = head;
        head = head.next;
        if (head==tail)
            tail=null;
        size.substract();
        return (T) ret.data;
    }

    @Override
    public T element()
    {
        if(isEmpty())
            throw new NoSuchElementException ();
        return head.data;
    }

    @Override
    public T peek()
    {
        if(isEmpty())
            return null;
        return head.data;
    }

    @Override
    public int size()
    {
        return size.get();
    }

    @Override
    public boolean isEmpty()
    {
        if (size.get()==0)
            return true;
        return false;
    }

    @Override
    public boolean contains(Object o)
    {
        Node cur = head;
        while (cur != null)
        {
            if (cur.data == o)
                return true;
            cur = cur.next;
        }
        return false;
    }

    @Override
    public Iterator iterator()
    {
        return new MyIt(head, size);
    }

//    // This method is for itorator to remove last next() element.
//    // Ergo, remove node previous to n.
//    private Node remove(Node n)
//    {
//  Node previous = head;
//  Node current = head.next;
//  while(current != null)          // Check through very end
//  {
//      if (current.next == n)
//      {
//      previous.next = current.next;   //Dereference node to be removed.
//      size.substract();
//      return previous.next;
//      }
//      else
//      {
//      previous = current;     //Step along.
//      current = current.next;
//      }
//  }
//  return null;
//    }

    @Override
    public boolean remove(Object o)
    {
        Node cur = head;
        while(cur.next != null)
        {
            if (cur.next==o)
            {
                cur.next = cur.next.next;
                return true;
            }
        }
        return false;
    }

    // I don't use the rest of these for the Sieve assignment (or the iterator above)
    //   so I'll not write them now.
    @Override
    public Object[] toArray()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public Object[] toArray(Object[] a)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public boolean containsAll(Collection c)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public boolean addAll(Collection c)
    {
        Iterator<Integer> it = c.iterator();
        while(it.hasNext())
        {
            add(it.next());
        }
        return true;
    }

    @Override
    public boolean removeAll(Collection c)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public boolean retainAll(Collection c)
    {
        throw new UnsupportedOperationException("Not supported yet.");
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

//////////////////////////////////////////////////////////////////////////
            ////  Iterator class /////
//////////////////////////////////////////////////////////////////////////
    private class MyIt<T> implements Iterator
    {
        private Node last;
        private Node cursor;
        private Node head;
        private Count currentSize;
        private boolean canRemove = false;
        
        public MyIt(Node h, Count c)
        {
            this.cursor = head = h;
            this.currentSize = c;
        }
        
        @Override
        public boolean hasNext()
        {
            return cursor != null;
        }
        
        @Override
        public Object next()
        {
            Object ret = cursor.data;
            last = cursor;
            cursor = cursor.next;
            canRemove = true;
            return ret;
        }
        
        @Override
        public void remove()
        {
            if(canRemove)
            {
                if (last == head)
                {
                    last = head = head.next;
                } else {
                    Node cur = head;
                    while(cur.next != last)
                    {
                        cur = cur.next;
                    }
                    cur.next = cursor; // jump last to disassociate
                    last = null;
                }
                currentSize.substract();
                canRemove = false; //Can only remove once per next()
            }
        }
    }

/*/////////////////////////////////////////////////////////////////////////
            ////  Counter class /////
    /*This class is so that I can pass my count to my iterator to be changed
    instead of passing my list in. Hoping to crappy up shitty performance
    by keeping track of previous there and doing removal there.
/////////////////////////////////////////////////////////////////////////*/
    private class Count
    {
        int count = 0;
        public Count()
        {}

        public void add()
        {
            count++;
        }
        public void substract()
        {
            count--;
        }
        public void zero()
        {
            count = 0;
        }
        public int get()
        {
            return count;
        }

    }

}
