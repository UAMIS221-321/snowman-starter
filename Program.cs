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

static string GetMenuChoice(){
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

static void DisplayMenu(){
    Console.Clear();
    Console.WriteLine("1:   Play Snowman");
    Console.WriteLine("2:   See Scoreboard");
    Console.WriteLine("3:   Exit Game");
}

static bool ValidMenuChoice(string userInput){
    /*Step 1 update ValidMenuChoice to return true if the user 
    entered 1, 2 or 3 and return false if they entered anything else.
    */
	if(userInput == "1" || userInput == "2" || userInput == "3"){
		return true;
	}
	else{
		return false;
	}

}

static void Route(string userInput, ref int gamesWon, ref int gamesLost){
    /*Step 2: Update to call Snowman if the user entered 1 and 
        * ScoreBoard if they entered 2
        */
	if(userInput == "1"){
		SnowMan(ref gamesWon, ref gamesLost);
	}
	else if(userInput == "2"){
		ScoreBoard(gamesWon, gamesLost);
	}



}

static void SnowMan(ref int gamesWon, ref int gamesLost){
    Console.Clear();
    string word = GetRandomWord();
    char[] displayWord = SetDisplayWord(word);
    int missed = 0;
    string guessed = "";

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

static void CheckChoice(char[] displayWord, string word, ref int missed, ref string guessed, char pickedLetter){
    /*Check choice should check to see if the letter picked is in the 
        * word.  If it is, it should update the guessed array. and clear the 
        * console.  If it is not, it should tell the user the letter was not 
        * found, to press a key to continue, update the guessed letters array 
        * and clear the console. 
        */

	bool found = false;
	guessed+= pickedLetter;

	for(int i = 0; i < word.Length; i++){
		if(word[i] == pickedLetter){
			displayWord[i] = word[i];
			found = true;
		}
	}
	if(found == false){
		missed++;
		System.Console.WriteLine("LETTER " + pickedLetter + " WAS NOT FOUND");
	}
	
	System.Console.WriteLine(displayWord);
	System.Console.WriteLine("Press any key to continue.");
	Console.ReadKey();
	Console.Clear();


}

static bool KeepGoing(char[] displayWord, int missed){
    /*Update to return true if they have missed less than 7 guesses 
        * AND there are still underscores left meaning they have not 
        * fully guessed the word
        */

	bool flag = false;

	for(int i = 0; i < displayWord.Length; i++){
		if(displayWord[i] == '_'){
			flag = true;
		}
	}

	if(missed < 7 && flag == true){
		return true;
	}

	return false;


}

static void ShowBoard(char[] displayWord, int missed, string guessed){
    Console.WriteLine("Word to guess: ");
    for (int i = 0; i < displayWord.Length; i++)
    {
        Console.Write(displayWord[i]);
    }

    Console.WriteLine();
    Console.WriteLine("Letters Guessed => " + guessed);

    Console.WriteLine("Currently missed " + missed);

}

static char[] SetDisplayWord(string word){
    /*SetDisplayWord to return a character array of 
    * underscores to match the word returned in step 3
    */
	char[] NEWarray = new char[word.Length];
	for(int i = 0; i < word.Length; i++){
		NEWarray[i] = '_';
	}
	return NEWarray;
}
static string GetRandomWord(){
    // Selects a random word from the array below and returns it.


    Random roll = new Random();
    string[] snowmanWords = new string[] { "ROLLTIDE", "ALABAMA", "INNOVATE", "INFORMATION", "CAPSTONE", "SNOWMAN" };

	return snowmanWords[roll.Next(0,5)];
}


static void ScoreBoard(int gamesWon, int gamesLost){
    Console.Clear();
    Console.WriteLine("You have won " + gamesWon + " games");
    Console.WriteLine("You have lost " + gamesLost + " games");
    Console.WriteLine("Press any key to continue....");
    Console.ReadKey();
}

static void Goodbye(int gamesWon, int gamesLost){
    Console.Clear();
    Console.WriteLine("Thank you for playing... \n" +
        "Press any key for one final look at the scoreboard" +
        " before you go");
    Console.ReadKey();
    ScoreBoard(gamesWon, gamesLost);
}
