    // Sieve3 is also the same but uses MyLLQueueJ
//

import java.util.Iterator;

public class Sieve3
{
    MyLLQueueJ<Integer> primes; // Mine!
    int lastComp = 0;

    public Sieve3()
    {

    }

    void computeTo(int max)
    {
        if(max < 2)
            throw new IllegalArgumentException();
        lastComp=max;
        MyLLQueueJ<Integer> nums = new MyLLQueueJ<>(); // Use my own Queue Linked Listed. . .
        for (int i = 2; i <= max; i++)
        {
            nums.add(i);
        }
        primes = new MyLLQueueJ<>();   // Mine.
        int p;
        do{
            p = nums.remove();
            Iterator<Integer> it = nums.
            iterator();
            while(it.hasNext())
            {
                int i = it.next();
                if (i % p == 0)
                it.remove(); //removes last returned element
        }
        primes.add(p);

        while (p < Math.sqrt(max));
        primes.addAll(nums);
        }
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
