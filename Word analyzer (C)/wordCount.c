#include "wordCount.h"

void requestFile()
{
	char fn[50];
	while(1)
	{
		printf("No file opened. Please enter file name:");
		scanf("%s", fn);
		fin = fopen(fn, "r");

		if(fin != NULL)
			return;
	}
	free(fn);
}


int buildArray()
{
	int iCount = 0;
	char cTemp[50];
	while(!feof(fin))
	{
		fscanf(fin, "%s", cTemp);
		iCount++;
	}
	rewind(fin);

	pList = (char**)calloc(iCount, sizeof(char*));

	for(int i = 0; i < iCount; i++)
	{
		fscanf(fin, "%s", cTemp);
		int len = strlen(cTemp);
		*(pList + i) = (char*) calloc(len+1, sizeof(char));
		strcpy(*(pList + i), cTemp);
	}

	return iCount;
}

void readWords(int numWords)
{
	int totalchars = 0;
	int iLongest = 0;
	int iShortest = 100;
	int* histogram = (int*)calloc(22, sizeof(int));
	char cLongest[30];
	char cShortest[30];

	char word[50];
	int len = 0;
	for(int i = 0; i < numWords; i++)
	{
		len = strlen(*(pList + i));
		totalchars += len;
		histogram[len]++;
		if(len > iLongest)
		{
			iLongest = len;
			strcpy(cLongest, *(pList+i));
		}
		if(len < iShortest)
		{
			iShortest = len;
			strcpy(cShortest, *(pList+i));
		}
	}

	printf("The longest word, %s, is %d letters.\n", cLongest, iLongest);
	printf("The shortest word, %s, is %d letters.\n", cShortest, iShortest);
	printf("The average word is %d letters.\n", totalchars/numWords);

	//Print graph
	printf("Letters | Count");
	for(int i = 0; i < 22; i++)
	{
		printf("\n%7d - %-7d:", i, *(histogram+i));
		printTicks(*(histogram+i) / 50);
	}
	printf("\n");
	free(histogram);
}

void printTicks(int num)
{
	for (int i = 0; i < num; ++i)
	{
		printf("-");
	}
}


void freeListMemory(int size)
{
	for(int i = 0; i < size; i++)
	{
		free(*(pList+i));
	}
	free(pList);
}