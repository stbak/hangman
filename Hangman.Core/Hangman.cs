using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman.Core
{
    public class Hangman
    {
        private string _wordToGuess;
        private StringBuilder _guessedWord = new StringBuilder();
        private HashSet<char> _guesses = new HashSet<char>();
        private int _guessesLeft = 6;

        public Hangman(string wordToGuess, int numberOfGuesses)
        {
            _wordToGuess = wordToGuess.ToUpper();
            _guessedWord.Append('-', wordToGuess.Length);
            _guessesLeft = numberOfGuesses;
        }

        public string GetGuessedWord()
        {
            return _guessedWord.ToString();
        }

        public int GetGuessesLeft()
        {
            return _guessesLeft;
        }

        public HashSet<char> GetGuesses()
        {
            return _guesses;
        }

        public bool GameEnded()
        {
            return _guessedWord.ToString() == _wordToGuess || _guessesLeft == 0;
        }

        public GuessResult Guess(string input)
        {
            input = input.ToUpper();

            // Check if guessed the whole word
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

        private bool GuessedCorrectWord(string input)
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
