// I put code to check performance between Sieve and Sieve2 in SieveMain.
// Sieve2 is the same as Sieve1 except swapping ArrayDeque for LinkedList.
//
// Here are my results (as printed to output):
//    Performace check for calculating primes to 100,000 one hundred times:
//    LinkedList average: 39722919
//    ArrayDeque average: 295557883
//    Nanosecond difference: 255834964
//
// Conclusion: LinkedLists are much faster than arrays...
//

import java.util.ArrayDeque;
import java.util.Iterator;
import java.util.Queue;

public class Sieve2
{
    Queue<Integer> primes;
    int lastComp = 0;

    public Sieve2()
    {
    }

    void computeTo(int max)
    {
    	if(max < 2)
            throw new IllegalArgumentException();
	lastComp=max;
	Queue<Integer> nums = new ArrayDeque<>();
	for (int i = 2; i <= max; i++)
	{
	    nums.add(i);
	}
	primes = new ArrayDeque<>();
	int p;
	do{
	    p = nums.remove();
	    Iterator<Integer> it = nums.iterator();
	    while(it.hasNext())
	    {
		int i = it.next();
		if (i % p == 0)
		    it.remove(); //removes last returned element
	    }
	    primes.add(p);

	} while (p < Math.sqrt(max));
	primes.addAll(nums);
    }

    void reportResults()
    {
	if (primes.isEmpty())
	    throw new IllegalArgumentException();
	System.out.println("Primes up to " + lastComp + " are as follows:");
	String results = "";
	int count = 0;
	Iterator<Integer> it = primes.iterator();
	while(it.hasNext())
	{
	    results += "" + it.next() + " ";
	    count++;
	    if(count % 12 == 0)
		results += "\n";
	}
	System.out.println(results);
    }

    int getMax()
    {
	if(lastComp == 0)
	    throw new IllegalStateException();
	return lastComp;
    }

    int getCount()
    {
	if(lastComp == 0)
	    throw new IllegalStateException();
	return primes.size();
    }

}
