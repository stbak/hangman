using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman.Core
{
    public class Hangman
    {
        private string _wordToGuess;
        private StringBuilder _maskedWordWithCorrectGuesses;
        private HashSet<char> _guessedCharacters;
        private int _guessesLeft;

        public Hangman(string wordToGuess, int numberOfGuesses)
        {
            if (string.IsNullOrEmpty(wordToGuess))
                throw new ArgumentException("wordToGuess cannot be null or empty");
            if (numberOfGuesses < 1)
                numberOfGuesses = 10;

            _wordToGuess = wordToGuess.ToUpper();
            _maskedWordWithCorrectGuesses = new StringBuilder().Append('-', wordToGuess.Length);
            _guessedCharacters = new HashSet<char>();
            _guessesLeft = numberOfGuesses;
        }

        public string MaskedWordWithCorrectGuesses => _maskedWordWithCorrectGuesses.ToString();

        public int GuessesLeft => _guessesLeft;

        public HashSet<char> GuessedCharacters => _guessedCharacters;

        public bool GameEnded()
        {
            return _maskedWordWithCorrectGuesses.ToString() == _wordToGuess || _guessesLeft == 0;
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
            if (_guessedCharacters.Contains(guess))
                return GuessResult.AlreadyGuessed;

            // Add guess to guesses
            _guessedCharacters.Add(guess);

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
                    _maskedWordWithCorrectGuesses[i] = guess;
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
            // Check if user guessed the whole word
            if (input == _wordToGuess)
            {
                // Update _maskedWordWithCorrectGuesses to same as the word to guess
                _maskedWordWithCorrectGuesses = new StringBuilder(_wordToGuess);
                return true;
            }
            return false;
        }
    }
}
