// Zachariah Kendall
// Methods for Lingo Game
// March 6, 2013

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "lingo.h"


int compareAnswers(char answer[], char current[], char guess[], char letters[])
{
    // Check every guessed letter against every answer letter
    int correct = 0;
    for (int i = 0; i < 5; ++i)
    {
        for (int j = 0; j < 5; ++j)
        {
            if(answer[j] == guess[i])
            {
                if(j == i) // Exact match
                {
                    current[j] = answer[j];
                }
                else  // Add to letters
                {
                    int unique = 1;
                    for (int k = 0; k < 5; ++k)
                    {  // Don't add duplicate letters
                        if(letters[k] == guess[i])
                            unique = 0; // false
                    }
                    if(unique)
                        letters[correct++] = guess[i];
                }
            }
        }
    }
    return strcmp(answer, guess);
}


void getGuess(char guess[])
{
    printf("Your guess: ");
    fgets(guess, 7, stdin);
    strip(guess);
    //scanf("%s", guess);
    //getchar(); // Eat newline
}


void strip(char str[])
 {
    int len = strlen(str);
    if(str[len-2] == '\r')
        str[len-2] = '\0';
    else if(str[len-1] == '\n')
        str[len-1] = '\0';
}


void seedHints(char answer[], char current[])
{
    // Select random letters
    strcpy(current, "_____");
    int l1, l2;
    l1 = rand() % 5;
    do{ l2 = rand() % 5; } while (l1 == l2);
    // Put 2 correct letters in player copy
    current[l1] = answer[l1];
    current[l2] = answer[l2];
}


int chooseWord(char **pList, int iListLength, char word[])
{
    int attempts = 100;
    while(attempts--)
    {
        int i = rand() % (iListLength);
        if(strcmp(*(pList+i), "\0") == 0)
        {
            continue; // Word used, get another
        }
        printf("\n");
        strcpy(word, *(pList+i)); // Get word
        strcpy(*(pList+i), "\0"); // Mark used
        return 1;
    }
    printf("\nThe word list appears to be exhausted\n");
    return 0;
}


char* requestName(char name[50])
{
    printf("Enter your name: \n");
    scanf("%s", name);
    getchar();  // eat newline.
    return name;
}


void setHighScore(char pName[], int highScore, int highRounds)
{
    FILE* fhs = fopen("high.scores", "w");
    fprintf(fhs, "%s %d %d", pName, highScore, highRounds);\
    printf("Your new high score, %d in %d rounds, has been saved in the file, \"high.scores\"\n", highScore, highRounds);
    fclose(fhs);
}

void getHighScore(char pName[], int* pHightScore, int* pHighRounds)
{
    FILE* fhs = fopen("high.scores", "r");
    if (fhs == NULL)
    {
        printf("There is no saved high score.\n");
        strcpy(pName, "\0");
    }
    else
    {
        fscanf(fhs, "%s %i %i", pName, pHightScore, pHighRounds);
        printf("The high score is %d in %d rounds by \"%s\"\n", *pHightScore, *pHighRounds, pName);
    }
    if(fhs != NULL)
        fclose(fhs);
}


FILE* requestFile(FILE *fin)
{
    char fn[50];
    printf("No word file opened. Enter file name:");
    scanf("%s", fn);
    fin = fopen(fn, "r");
    return fin;
}


char** buildArray(FILE *fin, char **pList, int *iListLength)
{
    char cTemp[10];
    // Count lines
    while(!feof(fin))
    {
        fscanf(fin, "%s", cTemp);
        (*iListLength)++;
    }
    fseek(fin, 0, SEEK_SET);

    // Build outer array
    pList = (char**)calloc(*iListLength, sizeof(char*));

    // Build inner arrays
    for (int i = 0; i < *iListLength; i++)
    {
        fscanf(fin, "%s", cTemp);
        int l = strlen(cTemp);
        *(pList+i) = (char*)calloc(l+1, sizeof(char));
        strcpy(*(pList+i), cTemp);  
    }
    return pList;
}


void freeArray(char **pList, int iListLength)
{
    for (int i = 0; i < iListLength; ++i)
    {
        free(*(pList+i));
    }
    free(pList);
}


int again()
{
    char answer[20];
    while(1)
    {
        printf("\nDo you want to play again? (yes/no)\n");
        scanf("%s", answer);
        getchar();  // eat carriage
        if(strcmp(answer,"yes")==0)
            return 1;
        if(strcmp(answer,"no")==0)
            return 0;
    }
}
