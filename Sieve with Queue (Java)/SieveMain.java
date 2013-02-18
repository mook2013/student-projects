// Zachariah Kendall
// Assignment 3
// Description:
//      This program computes all the prime numbers up to a given integer n.
//      It uses the classic "Sieve of Eratosthenes".

import java.util.*;

public class SieveMain {
    public static void main(String[] args) {
        System.out.println("This program computes all prime numbers up to a");
        System.out.println("maximum using the Sieve of Eratosthenes.");
        System.out.println();
        Scanner console = new Scanner(System.in);
        Sieve s = new Sieve();
        // Sieve2 s = new Sieve2();
        // Sieve3 s = new Sieve3();
        for(;;) {
            System.out.print("Maximum n to compute (0 to quit)? ");
            int max = console.nextInt();
            if (max == 0)
                break;
            System.out.println();
            s.computeTo(max);
            s.reportResults();
            int percent = s.getCount() * 100 / s.getMax();
            System.out.println("% of primes = " + percent);
            System.out.println();
        }


	// Performance Testing //
        
//	System.out.println("Do Benchmark (0 to quit)?");
//	if (console.nextInt()==0)
//	    return;
//	System.out.println("Performance check for calculating primes to 100,000 one hundred times:");
//	long lTotal = 0;
//	for (int i = 0; i < 100; i++)
//	{
//	    long start = System.nanoTime();
//            s.computeTo(100000);    //Calculate Primes to 100,000
//	    long elapsed = (System.nanoTime() - start);
//
//	    lTotal += elapsed;
//	}
//	System.out.println("LinkedList average: \t" + lTotal/100 );
////////////////
//	long qTotal = 0;
//	Sieve2 s2 = new Sieve2();
//	for (int i = 0; i < 100; i++)
//	{
//	    long start = System.nanoTime();
//            s2.computeTo(100000);    //Calculate Primes to 100,000
//	    long elapsed = (System.nanoTime() - start);
//	    qTotal += elapsed;
//	}
//	System.out.println("ArrayDeque average: \t" + qTotal/100 );
//	System.out.println("Nanosecond difference: \t" + (qTotal/100 - lTotal/100));

/////////////////////////////////////////////////////////////////////////////////////////

//	long mTotal = 0;
//	Sieve3 s3 = new Sieve3();
//	for (int i = 0; i < 100; i++)
//	{
//	    System.out.println(i + "a");
//	    long start = System.nanoTime();
//            s3.computeTo(100000);    //Calculate Primes to 100,000
//	    long elapsed = (System.nanoTime() - start);
//	    mTotal += elapsed;
//	    System.out.println(i + "b");
//	}
//	System.out.println("MyLLQueueJ average: \t" + mTotal/100 );

    }
}