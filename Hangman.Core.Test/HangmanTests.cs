using Hangman.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.Core.Test
{
    [TestClass]
    public class HangmanTests
    {


        [TestMethod]
        public void guess_should_be_incorrect()
        {
            var h = new Core.Hangman("SOMMAR", 6);
            GuessResult result = h.Guess("X");

            Assert.AreEqual(GuessResult.IncorrectGuess, result);

        }

        [TestMethod]
        public void guess_should_be_correct()
        {
            var h = new Core.Hangman("SOMMAR", 6);
            GuessResult result = h.Guess("M");

            Assert.AreEqual(GuessResult.CorrectGuess, result);

        }
        [TestMethod]
        public void guess_should_be_invalid()
        {
            var h = new Core.Hangman("SOMMAR", 6);
            GuessResult result = h.Guess("ME");
            Assert.AreEqual(GuessResult.InvalidGuess, result);

            result = h.Guess(".");
            Assert.AreEqual(GuessResult.InvalidGuess, result);s

        }
        [TestMethod]
        public void guess_should_be_AlreadyGuessed()
        {
            //only to add the letter M before to the Hashmap
            var h = new Core.Hangman("SOMMAR", 6);
            GuessResult result = h.Guess("M");
            Assert.AreEqual(GuessResult.CorrectGuess, result);

            //the actual "AlreadyGuessed test"
            result = h.Guess("M");
            Assert.AreEqual(GuessResult.AlreadyGuessed, result);

        }
    }
}
