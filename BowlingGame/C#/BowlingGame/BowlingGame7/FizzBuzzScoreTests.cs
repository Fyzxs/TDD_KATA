using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame7
{
    [TestClass]
    public class FizzBuzzScoreTests
    {
        private readonly FizzBuzzScore _fizzBuzzScore = new FizzBuzzScore();

        [TestMethod]
        public void ReturnsANumber()
        {
            string actual = _fizzBuzzScore.Score(1);
            Assert.AreEqual(1.ToString(), actual);
        }

        [TestMethod]
        public void ReturnsFizzGiven3()
        {
            string actual = _fizzBuzzScore.Score(3);
            Assert.AreEqual("Fizz", actual);
        }

        [TestMethod]
        public void ReturnsFizzGivenMultiplesOf3LessThan15()
        {
            for (int i = 1; i < 5; i++)
            {
                string actual = _fizzBuzzScore.Score(3*i);
                Assert.AreEqual("Fizz", actual);
            }
        }

        [TestMethod]
        public void ReturnsFizzGivenMultiplesOf3From16LessThan30()
        {
            for (int i = 6; i < 10; i++)
            {
                string actual = _fizzBuzzScore.Score(3*i);
                Assert.AreEqual("Fizz", actual);
            }
        }
        [TestMethod]
        public void ReturnsBuzzGiven5()
        {
            string actual = _fizzBuzzScore.Score(5);
            Assert.AreEqual("Buzz", actual);
        }


        [TestMethod]
        public void ReturnsFizzGivenMultiplesOf5LessThan15()
        {
            for (int i = 1; i < 3; i++)
            {
                string actual = _fizzBuzzScore.Score(5 * i);
                Assert.AreEqual("Buzz", actual);
            }
        }

        [TestMethod]
        public void ReturnsFizzGivenMultiplesOf5From16LessThan30()
        {
            for (int i = 4; i < 6; i++)
            {
                string actual = _fizzBuzzScore.Score(5 * i);
                Assert.AreEqual("Buzz", actual);
            }
        }
        [TestMethod]
        public void ReturnsFizzBuzzGiven15()
        {
            string actual = _fizzBuzzScore.Score(15);
            Assert.AreEqual("FizzBuzz", actual);
        }
    }
}
