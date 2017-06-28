using System;

namespace guessingGame
{
  class Program
  {
    static void Main(string[] args)
    {
    	int numberToGuess;
    	int numberOfGuesses = 0;
    	Console.WriteLine("Player One, enter your number: ");
    	numberToGuess = Int32.Parse(Console.ReadLine());
    	while (numberToGuess < 1 || numberToGuess > 10){
    		Console.WriteLine("Not a valid number, try again!");
    		numberToGuess = Int32.Parse(Console.ReadLine());
    	}
    	int guess = 0;
    	while ((guess != numberToGuess) && (numberOfGuesses < 5)){
    		Console.WriteLine("Player Two, make a guess: ");
    		guess = Int32.Parse(Console.ReadLine());
    		numberOfGuesses++;
    	}
    	if (numberOfGuesses < 5){
    		Console.WriteLine("Player Two Won!");
    	}
    	else{
    		Console.WriteLine("Player One Won!");
    	}
    }
  }
}