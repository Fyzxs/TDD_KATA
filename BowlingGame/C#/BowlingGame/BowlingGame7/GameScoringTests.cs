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
            int actual = new GameScoring().Score(new []{1,2,3,4,5,6,7,8,9,10}, new SimpleScore());
            Assert.AreEqual(55, actual);
        }

        [TestMethod]
        public void ShouldScoreBlackJack()
        {
            int blackjackScore = new GameScoring().Score(new[] { 1, 2, 3, 4 }, new BlackJackGame());
            Assert.AreEqual(10, blackjackScore);
        }

        [TestMethod]
        public void ShouldScoreBowling()
        {
            int blackjackScore = new GameScoring().Score(new[] { 1, 2, 3, 4 }, new BlackJackGame());
            Assert.AreEqual(10, blackjackScore);
        }
    }

    public class SimpleScore : GameScoring.IScoreEngine
    {
        public int Score(int[] values)
        {
            return values.Sum();
        }
    }

    public class GameScoring
    {
        public interface IScoreEngine
        {
            int Score(int[] values);
        }

        public int Score(int[] ints, IScoreEngine simpleScore)
        {
            return simpleScore.Score(ints);
        }
    }
}
