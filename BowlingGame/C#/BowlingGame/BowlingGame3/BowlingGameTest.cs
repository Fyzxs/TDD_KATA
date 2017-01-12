using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame3
{
    [TestClass]
    public class BowlingGameTest
    {
        private Game _game;

        private void RollMany(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                _game.Roll(pins);
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            _game = new Game();
        }

        [TestMethod]
        public void GutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, _game.Score());
        }

        [TestMethod]
        public void AllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, _game.Score());
        }

        [TestMethod]
        public void SingleSpare()
        {
            RollSpare();
            _game.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, _game.Score());
        }

        [TestMethod]
        public void SingleStrike()
        {
            _game.Roll(10);//Strike
            _game.Roll(3);
            _game.Roll(4);
            Assert.AreEqual(24, _game.Score());
        }

        [TestMethod]
        public void PerfectGame()
        {
            RollMany(21, 10);
            Assert.AreEqual(300, _game.Score());
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }
    }
}
