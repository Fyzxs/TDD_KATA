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
            Assert.AreEqual(4, _g.Score(new[] { 2, 2 }));
        }

        [TestMethod]
        public void TwoAndTwoAndTwo()
        {
            Assert.AreEqual(6, _g.Score(new[] { 2, 2, 2 }));
        }

        [TestMethod]
        public void BustWithThirty()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _g.Score(new[] { 10, 10, 2 }));
        }
    }
}
