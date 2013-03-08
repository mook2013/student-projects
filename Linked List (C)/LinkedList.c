// Zachariah Kendall
// March 3, 2013
//

#include <stdio.h>
#include <stdlib.h>
#include "LinkedList.h"


void addFirst(int item)
{
	node * tmp = (node*)calloc(1, sizeof(node));
	tmp->next = NULL;
	tmp->data = item;

	if(head == NULL)
		head = tmp;
	else
	{
		tmp->next = head;
		head = tmp;
	}
	size++;
}

void addOrdered(int item)
{
	node * tmp = (node*) calloc(1, sizeof(node));
	tmp->data = item;
	tmp->next = NULL;

	if(head == NULL)
	{
		head = tmp;
	}
	else
	{
		if(head->data > item)
		{
			addFirst(item);
			free(tmp);
			size++;
			return;
		}
		node * cur = head;
		while(cur->next != NULL)
		{
			if(cur->next->data > item)
			{ // Instert node
				tmp->next = cur->next;
				cur->next = tmp;
				size++;
				return;
			}
			cur = cur->next;
		}
		// Add to end
		cur->next = tmp;
	}
	size++;
}

void printList()
{
	if(head == NULL)
		printf("List is empty\n");
	else
	{
		node * cur = head;
		while(cur != NULL)
		{
			printf("%d\n", cur->data);
			cur = cur->next;
		}
	}

}

void removeItem(int item)
{
	if(head == NULL)
		printf("List is empty\n");
	else
	{
		node* cur = head;
		if(head->data == item)
		{
			head = head->next;
			free(cur);
			printf("Removed %i\n", item);
			size--;
			return;
		}
		node* rem;

		while(cur->next != NULL)
		{
			if(cur->next->data == item)
			{
				rem = cur->next;
				cur->next = cur->next->next;
				free(rem);
				printf("Removed %i\n", item );
				size--;
				return;
			}
			cur = cur->next;
		}
		printf("Item not found\n");
	}
}

void clearList()
{
	if(head == NULL)
		printf("List is empty\n");
	else
	{
		node * cur = head;
		while(cur != NULL)
		{
			head = cur->next;
			free(cur);
			cur = head;
		}
	}
	size = 0;
}
