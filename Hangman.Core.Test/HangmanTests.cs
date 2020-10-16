using Hangman.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hangman.Core.Test
{
    [TestClass]
    public class HangmanTests
    {
        // OO: Well done :)
        // OO: Continue and test the other public stuff like MaskedWordWithCorrectGuesses, GuessesLeft, GuessedCharacters, GameEnded

        [TestMethod]
        public void guess_should_be_incorrect()
        {
            var h = new Core.Hangman("Sommar", 6);
            GuessResult result = h.Guess("X");

            Assert.AreEqual(GuessResult.IncorrectGuess, result);
        }

        [TestMethod]
        public void guess_should_be_correct()
        {
            var h = new Core.Hangman("Sommar", 6);
            GuessResult result = h.Guess("M");

            Assert.AreEqual(GuessResult.CorrectGuess, result);
        }

        [TestMethod]
        public void guess_should_be_invalid()
        {
            var h = new Core.Hangman("Sommar", 6);
            GuessResult result = h.Guess("ma");
            Assert.AreEqual(GuessResult.InvalidGuess, result);

            result = h.Guess(".");
            Assert.AreEqual(GuessResult.InvalidGuess, result);
        }

        [TestMethod]
        public void guess_should_be_AlreadyGuessed()
        {
            //only to add the letter M to the Hashmap before the test 
            var h = new Core.Hangman("Sommar", 6);
            GuessResult result = h.Guess("M");
            Assert.AreEqual(GuessResult.CorrectGuess, result);

            //the actual "AlreadyGuessed test"
            result = h.Guess("M");
            Assert.AreEqual(GuessResult.AlreadyGuessed, result);
        }

        [TestMethod]
        public void guesses_left_should_be_same_as_passed_into_Game()
        {
            //
            var h = new Core.Hangman("Anyword", 6);
            //Act
            int result = h.GuessesLeft;
            //Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void number_of_guesses_should_be_zero()
        {

            //Det här fixar jag imorgon

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void calling_constructor_without_wordToGuess_should_throw_exception()
        {
            var h = new Hangman(" ", 6);
        }

        [TestMethod]
        public void calling_constructor_with_invalid_numberOfGuesses_should_set_GuessesLeft_to_10()
        {
            var h = new Hangman("Sommar", 0);
            int result = h.GuessesLeft;
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void guessing_the_whole_word_should_return_CorrectGuess_and_MaskedWordWithCorrectGuesses_is_same_as_wordToGuess_and_gameEnded_is_true_and_GuessesLeft_is_unchanged()
        {
            string wordToGuess = "Sommar";
            int numberOfGuesses = 6;
            var h = new Hangman(wordToGuess, numberOfGuesses);

            GuessResult result = h.Guess(wordToGuess.ToLower());
            Assert.AreEqual(GuessResult.CorrectGuess, result);

            string result2 = h.MaskedWordWithCorrectGuesses;
            Assert.AreEqual(wordToGuess.ToUpper(), result2);

            bool result3 = h.GameEnded();
            Assert.IsTrue(result3);

            int result4 = h.GuessesLeft;
            Assert.AreEqual(numberOfGuesses, result4);
        }
    }
}
