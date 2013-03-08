// Zachariah Kendall

#ifndef LINGO_H
#define LINGO_H

//Prototypes
int compareAnswers(char answer[], char current[], char guess[], char letters[]);
void getGuess(char guess[]);
void seedHints(char answer[], char current[]);
int chooseWord(char **List, int iListLength, char word[]);
char* requestName(char pName[50]);
void setHighScore(char pName[], int highScore, int highRounds);
void getHighScore(char pName[], int* pScore, int* pHighRounds);
FILE* requestFile(FILE *fin);
char** buildArray(FILE *fin, char **pList, int *iListLength);
void freeArray(char **pList, int iListLength);
int again();
void strip(char str[]);

#endif