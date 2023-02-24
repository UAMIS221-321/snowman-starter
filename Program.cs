using System;

int gamesWon = 0;
int gamesLost = 0;

string userInput = GetMenuChoice();
while (userInput != "3")
{
    Route(userInput, ref gamesWon, ref gamesLost);
    userInput = GetMenuChoice();
}

Goodbye(gamesWon, gamesLost);


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
    /*Step 1 update ValidMenuChoice to return true if the user 
    entered 1, 2 or 3 and return false if they entered anything else.
    */
    switch(userInput){
        case "1":
            return true;
            break;
        case "2":
            return true;
            break;
        case "3":
            return true;
            break;
        default:
            return false;
            break;
    }

}

static void Route(string userInput, ref int gamesWon, ref int gamesLost)
{
/*Step 2: Update to call Snowman if the user entered 1 and 
* ScoreBoard if they entered 2
*/

    switch(userInput){
    case "1":
        SnowMan(ref gamesWon, ref gamesLost);
        break;
    case "2":
        ScoreBoard(gamesWon, gamesLost);
        break;
    default:
        break;
    }
}

static void SnowMan(ref int gamesWon, ref int gamesLost)
{
    Console.Clear();
    string word = GetRandomWord();
    char[] displayWord = SetDisplayWord(word);
    int missed = 0;
    string guessed = "Letters guessed: ";

    while (KeepGoing(displayWord, missed))
    {
        ShowBoard(displayWord, missed, guessed);
        Console.WriteLine();
        char pickedLetter = Console.ReadLine().ToUpper()[0];
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

static void CheckChoice(char[] displayWord, string word, ref int missed,
            ref string guessed, char pickedLetter)
{
/*Update Check choice.  It should check to see if the letter picked is in the 
* word.  If it is, it should updated the guessed array (remember to handle 
* the situation where it is the first letter picked) and clear the 
* console.  If it is not, it should tell the user the letter was not 
* found, to press a key to continue.  Update the guessed letters array 
* and clear the console. 
*/

//If the user has already guessed a letter, then dont continue
    if(AlreadyGuessed(guessed, pickedLetter)){
        System.Console.WriteLine("You have already guessed " + pickedLetter);
    } else{
        guessed += pickedLetter;
        bool correct = false;

    //Searches over the word looking to see if the picked letter was found inside
        for (int i = 0; i < displayWord.Length; i++){
            if(word[i] == pickedLetter){
                displayWord[i] = pickedLetter;
                correct = true;
            }
        }

        //Checks to see if they got it correct or not
        if(!correct){
            System.Console.WriteLine("\nThe letter was not found!");
            missed++;
        }

    }
    Pause();
}
//Takes the letters that have been guessed and the most recent guess.
//Then searches to see if the picked letter has been found.

static bool AlreadyGuessed(string guessed, char pickedLetter){
    bool found = false;

    for (int i = 0; i < guessed.Length; i++){
        if(guessed[i] == pickedLetter){
            found = true;
        }
    }

    return found;
}

static bool KeepGoing(char[] displayWord, int missed)
{
/*Update to return true if they have missed less than 7 guesses 
* AND there are still underscores left meaning they have not 
* fully guessed the word
*/
    if(missed < 7 && CheckUnderScore(displayWord)){
        return true;
    }
    return false;

}

static bool CheckUnderScore(char[] displayWord){
    for (int i = 0; i < displayWord.Length; i++){
        if(displayWord[i] == '_'){
        return true;
        }
    }
    return false;
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

    int length = word.Length;
    char[] wordChar = new char[length];
    for (int i = 0; i < length; i++){
        wordChar[i] = '_';
    }
    return wordChar;

}
static string GetRandomWord()
{
/* Gets all words from a file, then returns a random word in the array to be used in the game
Note: The number generator should only generate a number within the range of the amount words in the file, 
you can assume this number can change depending
on the words in the file
*/    
    string[] allWords = GetAllWords();
    int randy = new Random().Next(0, 3);
    return allWords[randy];


}

static string[] GetAllWords()
{
//Get all the words from a file and store them in an array, returns the amount of words their our
    int count = 0;
    return new string[]{"CAPSTONE", "WINCHESTER", "BRUNO"};


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


static void Pause(){
    Console.WriteLine("\nPress any key to continue");
    Console.ReadKey();
    Console.Clear();
}
