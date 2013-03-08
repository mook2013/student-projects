// Zachariah Kendall
//

import java.io.File;
import java.io.FileNotFoundException;
import java.math.BigInteger;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.Scanner;
import java.util.Stack;


class inFixPostFix
{
    private LinkedList<String> inFix;
    private HashMap<Character, BigInteger> symbols;

    public inFixPostFix()
    {
	inFix = new LinkedList<>();
	symbols = new HashMap(26);
    }

    void loadFile()
    {
	try {
	    Scanner f = new Scanner(new File("infix.txt"));
	    boolean bValues = true;
	    while(f.hasNext())
	    {
		String line = f.nextLine();
		line = line.trim();
		if(line.length()==0)
		    continue;

		if(line.equals("#") && bValues == true)
		{  //Switch modes and continue to next line
		    bValues = false;
		    continue;
		}

		if(bValues) // Put in symbol table
		{
		    String tokens[] = line.split("[ ]+"); // Regex: one or more spaces
		    symbols.put(tokens[0].charAt(0), new BigInteger(tokens[1]));
		}
		else  // Put in expression list.
		{
		    if(!line.equals("#"))
			inFix.add(line);
		}
	    }
	    f.close();
	} catch (FileNotFoundException ex)
	{
	    System.out.println("Loadfile error: " + ex);
	}
	System.out.println("The symbole table for this file's expressions:\n" + symbols.toString());
    }

    void in2PostFix()
    {
	while(!inFix.isEmpty()) // Go through each expression
	{
	    Stack<Character> stack = new Stack<>();
	    String expression = inFix.pop();
	    System.out.println("\nInfix expession:\t" + expression);
	    String postFix = "";
	    for(char c: expression.toCharArray())
	    {
		if(symbols.containsKey(c)) // isOpperand
		    postFix += c;
		else if (c == '(')
		    stack.push(c);
		else if (c == ')')
		{
		    while(stack.peek() != '(')
		    {
			postFix += stack.pop();
		    }
		    stack.pop(); // remove
		}
		else
		{
		    while (!stack.isEmpty() &&
			    getInPrec(c) <= getOutPrec(stack.peek()))
		    {
			postFix += stack.pop();
		    }
		    stack.push(c);
		}
	    }
	    while (!stack.isEmpty())
	    {
		postFix += stack.pop();
	    }
	    System.out.println("Postfix Pression:\t" + postFix);
	    BigInteger value = evaluatePostFix(postFix);
	    System.out.println("Expression Evaluated:\t" + value);
	}   // end while: end single expression processing
    }

    private BigInteger evaluatePostFix(String postfix)
    {
	Stack<BigInteger> stack = new Stack<>();
	BigInteger left, right;
	for(char c: postfix.toCharArray())
	{
	    if(c != '+' && c != '-' && c != '*' && c != '/' && c != '^')
	    {
		stack.push(symbols.get(c));
	    }
	    else
	    {
		right = stack.pop();
		left = stack.pop();
		switch(c){
		     case '+':
			stack.push(left.add(right));
			break;
		    case '-':
			stack.push(left.subtract(right));
			break;
		    case '*':
			stack.push(left.multiply(right));
			break;
		    case '/':
			stack.push(left.divide(right));
			break;
		    case '^':
			if (right.compareTo(new BigInteger(String.valueOf(Integer.MAX_VALUE))) < 0)
			    stack.push(left.pow(right.intValue()));
			else
			{
			    System.out.println("Exponant too large to calclulate. ");
			    return null;
			}
			break;
		}
	    }
	}
	return stack.pop(); //Last value is final value
    }

    // Return the 'weight' of the operator when it enters the stack
    private int getInPrec(char ch)
    {
	switch(ch)
	{
	    case '(':
		return 100;
	    case ')':
		return 0;
	    case '^':
		return 6;
	    case '/':
		return 3;
	    case '*':
		return 3;
	    case '+':
		return 1;
	    case '-':
		return 1;
	}
	throw new IllegalArgumentException("Nonexistant operator.");
    }

     // Return the weight of the operator when it sits on the stack
    private int getOutPrec(char ch)
    {
	switch(ch)
	{
	    case '(':
		return 0;
	    case ')':
		return 99;
	    case '^':
		return 5;
	    case '/':
		return 4;
	    case '*':
		return 4;
	    case '+':
		return 2;
	    case '-':
		return 2;
	}
	throw new IllegalArgumentException("Nonexistant operator.");
    }
}
