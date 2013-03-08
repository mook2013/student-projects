// Zachariah Kendall
// Homework 10
// March 3, 2013
// Write the methods for the linked list calls in main

#include <stdio.h>
#include <stdlib.h>
#include "LinkedList.h"

node * head = NULL;
int size = 0;

int main()
{
	int nums[] = {10,20,30,40,50,60,70,80,90,100};

	int x = 0;

	for(x = 9; x > -1; x--)
		addFirst(nums[x]);

	printList();

	removeItem(10);
	printList();

	removeItem(100);
	printList();

	removeItem(40);
	printList();

	removeItem(100);
	printList();

	clearList();

	printList();

	for(x = 0; x < 15; x++)
	addOrdered(rand() % 500);

	printList();

	clearList();

	return 0;

}// end main
