using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTests
{
    [TestClass]
    public class BowlingGameTest
    {
        private Game _game;

        [TestInitialize]
        public void Setup()
        {
            _game = new Game();
        }

        private void RollMany(int many, int pinsDown)
        {
            for (int i = 0; i < many; i++)
            {
                _game.Roll(pinsDown);
            }
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        private void RollStrike()
        {
            _game.Roll(10);
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
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(17, 0);
            Assert.AreEqual(24, _game.Score());
        }

        [TestMethod]
        public void PerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, _game.Score());
        }

    }
}
