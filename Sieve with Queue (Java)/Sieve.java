// Zachariah Kendall's Sieve
// This sieve includes Javadoc for extra credit.
// It uses the built in Queue and LinkedList

import java.util.Iterator;
import java.util.LinkedList;
import java.util.Queue;
/**
 *  The Sieve class used to calculate, store, print prime numbers.
 * @author ZKendall
 */
public class Sieve
{

    Queue <Integer> primes;	// Built in.
    int lastComp = 0;

    public Sieve()
    {

    }

    /**
     *	calculate primes up to a value, max.
     * @param max   the number to calulate primes to
     */
    void computeTo(int max)
    {
        if(max < 2)
            throw new IllegalArgumentException();
    	lastComp=max;
    	Queue<Integer> nums = new LinkedList<>();  //Use built in queue and LL
    	for (int i = 2; i <= max; i++)
    	{
    	    nums.add(i);
    	}
    	primes = new LinkedList<>();	// Built in.

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

    /**
     *	print the computed primes 12 per line
     */
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

    /**
     *
     * @return	the last computed prime
     */
    int getMax()
    {
	if(lastComp == 0)
	    throw new IllegalStateException();
	return lastComp;
    }

    /**
     *
     * @return	the size of the primes list
     */
    int getCount()
    {
	if(lastComp == 0)
	    throw new IllegalStateException();
	return primes.size();
    }

}
