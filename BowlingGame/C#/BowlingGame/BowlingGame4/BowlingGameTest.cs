using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame4
{
    [TestClass]
    public class BowlingGameTest
    {
        private Game _g;

        [TestInitialize]
        public void Initialize()
        {
            _g = new Game();
        }
        [TestMethod]
        public void GutterGame()
        {
            RollMany(20, 0);

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
            RollSpare();
            _g.Roll(4);
            RollMany(17, 0);

            Assert.AreEqual(18, _g.Score());
        }

        [TestMethod]
        public void SingleStrike()
        {
            _g.Roll(10);
            _g.Roll(3);
            _g.Roll(4);
            RollMany(16, 0);

            Assert.AreEqual(24, _g.Score());
        }

        [TestMethod]
        public void PerfectGame()
        {
            RollMany(21, 10);

            Assert.AreEqual(300, _g.Score());
        }

        private void RollSpare()
        {
            _g.Roll(5);
            _g.Roll(5);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                _g.Roll(pins);
            }
        }
    }
}
