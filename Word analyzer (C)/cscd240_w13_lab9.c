// Zachariah Kendall
// Homework 9 - 

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "wordCount.h"

//Globals
FILE* fin = NULL;
char** pList = NULL;

int main(int argc, char*argv[])
{
	//Get file
	if (argc < 2)
		requestFile();
	else
	{
		fin = fopen(argv[1], "r");

		if(fin == NULL)
			requestFile();
	}

	// Count lines and build array for words
	int size = buildArray();

	// Read lines into array and print stats
	readWords(size);
	fclose(fin);

	//Free memory!!!
	freeListMemory(size);

	return 0;
}

