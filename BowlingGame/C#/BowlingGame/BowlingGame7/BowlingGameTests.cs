using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame7
{
    [TestClass]
    public class BowlingGameTest
    {
        private BowlingGame _g;

        [TestInitialize]
        public void Initialize()
        {
            _g = new BowlingGame();
        }

        [TestMethod]
        public void GutterGame()
        {
            _g.Game(new []{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0});

            Assert.AreEqual(0, _g.Score());
        }

        [TestMethod]
        public void AllSinglePin()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, _g.Score());
        }

        [TestMethod]
        public void SingleSpare()
        {
            _g.Game(5);
            _g.Game(5);
            _g.Game(4);
            RollMany(17, 0);

            Assert.AreEqual(18, _g.Score());
        }

        [TestMethod]
        public void SingleStrike()
        {
            _g.Game(10);
            _g.Game(3);
            _g.Game(4);
            RollMany(16, 0);

            Assert.AreEqual(24, _g.Score());
        }

        [TestMethod]
        public void PerfectGame()
        {
            RollMany(21, 10);

            Assert.AreEqual(300, _g.Score());
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                _g.Game(pins);
            }
        }
    }
}