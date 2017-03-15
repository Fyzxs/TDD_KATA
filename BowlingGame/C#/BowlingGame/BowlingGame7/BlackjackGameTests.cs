using System;
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

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _g.Score());
        }
    }
}
