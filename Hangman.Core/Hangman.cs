using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman.Core
{
    public class Hangman
    {
        private string _wordToGuess;
        private StringBuilder _maskedWordWithCorrectGuesses;
        private HashSet<char> _guessedCharacters;
        private int _guessesLeft;

        public Hangman(string wordToGuess, int numberOfGuesses = 10)
        {
            if (string.IsNullOrWhiteSpace(wordToGuess))
                throw new ArgumentException("wordToGuess cannot be null or empty");
            // OO: Throw exceptions if numberOfGuesses <=0
            if (numberOfGuesses < 1)
                numberOfGuesses = 10;

            wordToGuess = wordToGuess.Trim();
            _wordToGuess = wordToGuess.ToUpper();
            _maskedWordWithCorrectGuesses = new StringBuilder().Append('-', wordToGuess.Length);
            _guessedCharacters = new HashSet<char>();
            _guessesLeft = numberOfGuesses;
        }

        public string MaskedWordWithCorrectGuesses => _maskedWordWithCorrectGuesses.ToString();

        public int GuessesLeft => _guessesLeft;

        // OO: It's a bit better to return IEnumerable<char> (advanced stuff)
        public IEnumerable<char> GuessedCharacters => _guessedCharacters;

        // OO: Nice :)
        // OO: You may press Alt-Enter here (use expression body)
        public bool GameEnded() => _maskedWordWithCorrectGuesses.ToString() == _wordToGuess || _guessesLeft == 0;

        // OO: Nice :)
        public GuessResult Guess(string input)
        {
            input = input.ToUpper();

            if (input.Length > 1)
            {
                // Check if guessed the whole word
                if (GuessedCorrectWord(input))
                {
                    return GuessResult.CorrectGuess;
                }
                else
                {
                    _guessesLeft--;
                    return GuessResult.IncorrectGuess;
                }
            }

            // Validate that input is one valid character
            if (!IsGuessOneValidCharacter_Regex(input))
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

        // OO: Nice method, just think about the name
        // OO: If you want, use "regular expressions"
        private bool IsGuessOneValidCharacter(string input)
        {
            string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";

            if (input.Length < 1 || input.Length > 1)
                return false;

            if (allowedCharacters.Contains(input[0]))
                return true;

            return false;
        }

        private bool IsGuessOneValidCharacter_Regex(string input)
        {
            return Regex.IsMatch(input, @"^[A-ZÅÄÖ]$");
        }

        private bool GuessedCorrectWord(string input)
        {
            if (input == _wordToGuess)
            {
                _maskedWordWithCorrectGuesses = new StringBuilder(_wordToGuess);
                return true;
            }
            return false;
        }
    }
}
