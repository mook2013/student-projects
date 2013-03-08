// Zachariah Kendall
#ifndef LINKEDLIST_H
#define LINKEDLIST_H

void addFirst(int item);
void addOrdered(int item);
void removeItem(int item);
void printList();
void clearList();

struct node
{
	int data;
	struct node * next;

};
typedef struct node node;

extern node *head;
extern int size;

#endif