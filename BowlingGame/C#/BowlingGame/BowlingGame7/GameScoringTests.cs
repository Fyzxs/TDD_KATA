using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame7
{
    [TestClass]
    public class GameScoringTests
    {
        [TestMethod]
        public void ShouldScoreSimpleEngine()
        {
            int actual = new GameScoring().Score(new SimpleScore(), new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            Assert.AreEqual(55, actual);
        }

        [TestMethod]
        public void ShouldScoreBlackJack()
        {
            int blackjackScore = new GameScoring().Score(new BlackJackGame(), new[] { 1, 2, 3, 4 });
            Assert.AreEqual(10, blackjackScore);
        }

        [TestMethod]
        public void ShouldScoreBowling()
        {
            int score = new GameScoring().Score(new BowlingGame(), new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            Assert.AreEqual(300, score);
        }

        [TestMethod]
        public void ShouldScoreFizzBuzz()
        {
            string score = new GameScoring().Score(new FizzBuzzScore(), 15);
            Assert.AreEqual("FizzBuzz", score);
        }

    }

    public class SimpleScore : GameScoring.IScoreEngine<int[], int>
    {
        public int Score(int[] values)
        {
            return values.Sum();
        }
    }

    public class GameScoring
    {
        public interface IScoreEngine<in T, out TU>
        {
            TU Score(T values);
        }

        public TU Score<T, TU>(IScoreEngine<T, TU> simpleScore, T values)
        {
            return simpleScore.Score(values);
        }
    }
}
