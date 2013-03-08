// Zachariah Kendall
// CSCD 240
// Program 3
// March 5, 2013
// Write a game LINGO, in which the user guesses a blanked out word.
//

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "lingo.h"


int main(int argc, char*argv[])
{
    FILE* fin = NULL;
    FILE* fout = NULL;
    char** pList = NULL;
    char pName[50];
    int score = 0, rounds = 0;
    int highScore = 0, highRounds = 0;
    char pHighName[50];
    int iListLength = 0;
    srand(time(0));

    //Get file
    if (argc < 2)
        fin = requestFile(fin);
    else
    {
        fin = fopen(argv[1], "r");
        if(fin == NULL)
            fin = requestFile(fin);
    }
    if(fin == NULL)
        return -1;

    // Read lines and build array of words
    pList = buildArray(fin, pList, &iListLength);

    //Close file
    fclose(fin);

    // Set up high score
    requestName(pName);
    getHighScore(pHighName, &highScore, &highRounds);

    //Main Game Loop
    do{
        // Still save score if the player loses w/highscore and wants to play again.
        if(score != 0 && score > highScore) 
            setHighScore(pName, score, rounds);

        char answer[6];
        if(!chooseWord(pList, iListLength, answer))
            break;  // Unable to select a unique word

        rounds++;
        char current[6], letters[6], guess[6];
        seedHints(answer, current);
        printf("\nYou are given two letters to start: %s\n", current);
        int chances = 5;
        while(chances)
        {
            printf("\nYou have %d chances.\n", chances);
            strcpy(letters, "     "); // Reset letter bin;
            getGuess(guess);
            if(compareAnswers(answer, current, guess, letters) == 0)
            {
                printf("CORRECT! The word was: %s\n", answer);
                printf("You get %d points\n\n", chances);
                score += chances;
                break;
            }
            else
            {
                printf("Current board: %s\n", current);
                printf("Correct letters: %s\n", letters);
                chances--;
            }
        }

        if(!chances) // Lost
            printf("\nYou lose. The correct word was \"%s\"\n", answer);

        printf("After %d rounds, your score is %d.\n", rounds, score);

        if(strcmp(pHighName, "\0"))  // If there is a name, show high score.
            printf("The all-time high score is held by \"%s\": %d in %d rounds.\n", pHighName, highScore, highRounds );

    } while(again()); // END GAME

    if(score > highScore)
        setHighScore(pName, score, rounds);
    
    //Free memory!!!
    freeArray(pList, iListLength);

    return 1;
} // End Main
