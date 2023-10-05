// Snowman_Starter

using System;

//Start main 

int gamesWon = 0;
int gamesLost = 0;

string userInput = GetMenuChoice();
while (userInput != "3")
{
    Route(userInput, ref gamesWon, ref gamesLost);
    userInput = GetMenuChoice();
}

Goodbye(gamesWon, gamesLost);

// End main

static string GetMenuChoice()
{
    DisplayMenu();
    string userInput = Console.ReadLine();

    while (!ValidMenuChoice(userInput))
    {
        Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
        Console.WriteLine("Press any key to continue....");
        Console.ReadKey();

        DisplayMenu();
        userInput = Console.ReadLine();
    }

    return userInput;
}

static void DisplayMenu()
{
    Console.Clear();
    Console.WriteLine("1:   Play Snowman");
    Console.WriteLine("2:   See Scoreboard");
    Console.WriteLine("3:   Exit Game");
}

static bool ValidMenuChoice(string userInput)
{
    /*update ValidMenuChoice to return true if the user 
    entered 1, 2 or 3 and return false if they entered anything else.
    */

}

static void Route(string userInput, ref int gamesWon, ref int gamesLost)
{
    /*Update to call Snowman if the user entered 1 and 
        * ScoreBoard if they entered 2
        */

}

static void SnowMan(ref int gamesWon, ref int gamesLost)
{
    Console.Clear();
    string word = GetRandomWord();
    char[] displayWord = SetDisplayWord(word);
    int missed = 0;
    string guessed = "";
    char pickedLetter = '?';

    while (KeepGoing(displayWord, missed))
    {
        ShowBoard(displayWord, missed, guessed);
        Console.WriteLine();
        try
        {
            pickedLetter = Console.ReadLine().ToUpper()[0];
        }
        catch
        {
            pickedLetter = '?';
        }
        CheckChoice(displayWord, word, ref missed, ref guessed, pickedLetter);
    }

    if (missed == 7)
    {
        Console.WriteLine("Sorry you lost");
        gamesLost++;
    }
    else
    {
        Console.WriteLine("You Won!");
        gamesWon++;
    }
    Console.WriteLine("Press any key to continue.....");
    Console.ReadKey();
}

static void CheckChoice(char[] displayWord, string word, ref int missed, ref string guessed, char pickedLetter)
{
    /*Check choice should check to see if the letter picked is in the 
        * word.  If it is, it should update the guessed array. and clear the 
        * console.  If it is not, it should tell the user the letter was not 
        * found, increase missed count, update the guessed letters array, 
        * prompt user to press a key to continue, and clear the console. 
        */

}

static bool KeepGoing(char[] displayWord, int missed)
{
    /*Update to return true if they have missed less than 7 guesses 
        * AND there are still underscores left meaning they have not 
        * fully guessed the word
        */

}

static void ShowBoard(char[] displayWord, int missed, string guessed)
{
    Console.WriteLine("Word to guess: ");
    for (int i = 0; i < displayWord.Length; i++)
    {
        Console.Write(displayWord[i]);
    }

    Console.WriteLine();
    Console.WriteLine("Letters Guessed => " + guessed);

    Console.WriteLine("Currently missed " + missed);

}

static char[] SetDisplayWord(string word)
{
    /*SetDisplayWord to return a character array of 
    * underscores to match the word returned in step 3
    */

}

static string GetRandomWord()
{
    // Calls the GetWordList to retrieve the list of words,
    // chooses a word randomly from the list, and return that word


}

static string[] GetWordList()
{
    // Opens file where words are stored, puts them in an array, and returns array

}

static void ScoreBoard(int gamesWon, int gamesLost)
{
    Console.Clear();
    Console.WriteLine("You have won " + gamesWon + " games");
    Console.WriteLine("You have lost " + gamesLost + " games");
    Console.WriteLine("Press any key to continue....");
    Console.ReadKey();
}

static void Goodbye(int gamesWon, int gamesLost)
{
    Console.Clear();
    Console.WriteLine("Thank you for playing... \n" +
        "Press any key for one final look at the scoreboard" +
        " before you go");
    Console.ReadKey();
    ScoreBoard(gamesWon, gamesLost);
}