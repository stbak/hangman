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
            _wordToGuess = wordToGuess;
            _guessedWord.Append('-', wordToGuess.Length);
            _guessesLeft = numberOfGuesses;
        }

        public string GetGuessedWord()
        {
            return _guessedWord.ToString();
        }

        public int GuessesLeft()
        {
            return _guessesLeft;
        }

        public HashSet<char> GetGuesses()
        {
            return _guesses;
        }

        public GuessResult Guess(string input)
        {
            if (ValidInput(input)) // todo: namngivning
            {
                char guess = input[0];

                // todo: finlir: göra koden smalare
                if (_guesses.Contains(guess))
                {
                    return GuessResult.AlreadyGuessed;
                }
                else
                {
                    // Add guess to guesses
                    _guesses.Add(guess);

                    if (_wordToGuess.Contains(guess.ToString()))
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
            }
            else
            {
                return GuessResult.InvalidGuess;
            }
        }

        private bool ValidInput(string input)
        {
            if (input.Length < 1 || input.Length > 1)
            {
                return false;
            }
            if (IsInputOk(input[0]))
            {
                return true;
            }
            return false;
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

        private Boolean IsInputOk(char guess)
        {

            bool valid = false;
            char[] allowedCharacters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Å', 'Ä', 'Ö' }; //, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö' };
            foreach (char c in allowedCharacters)
            {

                if (guess == c)
                {
                    valid = true;
                }
            }

            return valid;
        }
    }
}
