// Zachariah Kendall
// CSCD 211 Section 2
//
// This is a singly linked list with a dummy head node.
// Also I used generics so that most of the list can support
//  any data type, not just Integers.

package listtester;

import java.util.InputMismatchException;
import java.util.Random;
import java.util.Scanner;

public class ListTester
{
    static Scanner kb = new Scanner(System.in);

    public static void main(String[] args)
    {
	Random rand = new Random();
	LinkedList<Integer> list = new LinkedList();

	int choice;
	printMenu();
	choice = getNumInput();
	while (choice != 9)
	{
	    switch (choice)
	    {
		case 0:
		    list.clear();
		    list.addNode(2);
		    list.addNode(1);
		    list.addNode(2);
		    list.addNode(2);
		    System.out.println("Temp list made.");
		    break;
		case 1:
		    list.clear();   //make sure list is fresh
		    System.out.print("Enter desired length: ");
		    int len = getNumInput();
		    for (int i = 0; i < len; i++)
		    {
			list.addNode((Integer) rand.nextInt(10));
		    }
		    System.out.println(len + " nodes added.");
		    break;
		case 2:
		    list.sort();
		    System.out.println("List sorted.");
		    break;
		case 3:
		    System.out.print("\nList contains:\n" + list.toString());
		    break;
		case 4:
		    System.out.print("\nReverse:\n" + list.toReverseString());
		    break;
		case 5:
		    System.out.println(LinkedList.getEvens(list).toString());
		    break;
		case 6:
		    System.out.print("Interval to print: ");
		    list.printNth(getNumInput());
		    break;
		case 7:
		    System.out.print("Number to remove: ");
		    int num = getNumInput();
		    System.out.println("Removed " + list.removeNodes(num) + " nodes from the list.");
		    break;
		case 8:
		    list.clear();
		    System.out.println("List cleared.");
		    break;
		default:
		    System.out.println("Not a menu option.");
	    }

	    printMenu();
	    choice = getNumInput();
	}


    }

    public static int getNumInput()
    {
	try {
	    return kb.nextInt();
	} catch (InputMismatchException e) {
	    System.out.print("\nInvalid Input. Only numbers accepted. Try again: ");
	    //kb.nextLine();
	    return getNumInput();
	}
    }

    public static void printMenu()
    {
	String menu = "\n";
	menu += "   Options:\n";
	menu += "\t1. Create a new list.\n";
	menu += "\t2. Sort the list.\n";
	menu += "\t3. Print the list.\n";
	menu += "\t4. Print the list in reverse order.\n";
	menu += "\t5. Generate and print sub-list containing all even numbers.\n";
	menu += "\t6. Print every Nth node in the list.\n";
	menu += "\t7. Delete node(s) containing a specific integer.\n";
	menu += "\t8. Delete the contents of the current list.\n";
	menu += "\t9. Quit.\n";
	menu += "   Select: ";
	System.out.print(menu);
    }

}
