using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman.Core
{
    public class Hangman
    {
        private string _wordToGuess;
        private StringBuilder _guessedWord;
        private HashSet<char> _guesses;
        private int _guessesLeft;

        public Hangman(string wordToGuess, int numberOfGuesses)
        {
            if (string.IsNullOrEmpty(wordToGuess))
                throw new ArgumentException("wordToGuess cannot be null or empty");
            if (numberOfGuesses < 1)
                numberOfGuesses = 10;

            _wordToGuess = wordToGuess.ToUpper();
            _guessedWord = new StringBuilder().Append('-', wordToGuess.Length); //Group5 - Will update naming of guessedword. Comment Group4: It is possible to solve it without this parameter. 
            _guesses = new HashSet<char>();
            _guessesLeft = numberOfGuesses;
        }

        public string GuessedWord => _guessedWord.ToString();

        public int GuessesLeft => _guessesLeft;

        public HashSet<char> Guesses => _guesses;

        public bool GameEnded()
        {
            return _guessedWord.ToString() == _wordToGuess || _guessesLeft == 0;
        }

        public GuessResult Guess(string input)
        {
            input = input.ToUpper();

            // Check if guessed the whole word //NOTED -NOT CHANGED -Comment Group4: this is not needed? You quit the while loop when endgame = true.. and a character will not be == whole word. CorrectGuess is if _word.contains(input).. 
            if (GuessedCorrectWord(input))
                return GuessResult.CorrectGuess;

            // Validate input
            if (!ValidInput(input))
                return GuessResult.InvalidGuess;

            char guess = input[0];

            // Check if already guessed
            if (_guesses.Contains(guess))
                return GuessResult.AlreadyGuessed;

            // Add guess to guesses
            _guesses.Add(guess);

            // Check if guess was correct
            if (_wordToGuess.Contains(guess))
            {
                AddCorrectGuess(guess);
                return GuessResult.CorrectGuess;
            }
            else
            {
                _guessesLeft--;
                Console.Beep();
                return GuessResult.IncorrectGuess;
            }
        }

        private void AddCorrectGuess(char guess)
        {
            for (int i = 0; i < _wordToGuess.Length; i++)
            {
                if (guess == _wordToGuess[i])
                {
                    _guessedWord[i] = guess;
                }
            }
        }

        private bool ValidInput(string input)
        {
            string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";

            if (input.Length < 1 || input.Length > 1)
                return false;

            if (allowedCharacters.Contains(input[0]))
                return true;

            return false;
        }

        private bool GuessedCorrectWord(string input) //NOTED - NOT CHANGED Comment Group4: Hard to understand if you ever will return true? input from user input.length = 1... how can it ever be == _wordToGuess?
        {
            if (input == _wordToGuess)
            {
                _guessedWord = new StringBuilder(_wordToGuess);
                return true;
            }
            return false;
        }
    }
}
