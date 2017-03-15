using System;
using System.CodeDom;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame7
{
    [TestClass]
    public class BlackjackGameTests
    {
        private BlackJackGame _g;
        
        [TestInitialize]
        public void Setup()
        {
            _g = new BlackJackGame();
        }

        [TestMethod]
        public void TwoAndTwo()
        {
            _g.Game(new []{2, 2});

            Assert.AreEqual(4, _g.Score());
        }

        [TestMethod]
        public void TwoAndTwoAndTwo()
        {
            _g.Game(new[] { 2, 2, 2 });

            Assert.AreEqual(6, _g.Score());
        }

        [TestMethod]
        public void BustWithThirty()
        {
            _g.Game(new []{10, 10, 2});

            Assert.ThrowsException<BustException>(() => _g.Score());
        }
    }

    public class BustException : Exception
    {
    }

    public class BlackJackGame
    {
        private const int MaxScore = 21;
        private int[] _cards;
        
        public int Score()
        {
            int score = _cards.Sum();

            return score <=  MaxScore ? score : throw new BustException();
        }

        public void Game(int[] cards)
        {
            _cards = cards;
        }
    }
}
