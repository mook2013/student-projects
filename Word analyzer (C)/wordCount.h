#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//Method Prototypes
void requestFile();
int buildArray();
void readWords();
void readWords(int numWords);
void printTicks(int num);
void freeListMemory(int size);

//Globals
extern FILE* fin;
extern char** pList;