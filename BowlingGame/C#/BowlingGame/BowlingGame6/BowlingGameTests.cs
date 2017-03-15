using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame6
{
    [TestClass]
    public class BowlingGameTests
    {
        private Game _game;

        [TestMethod]
        public void ThrowTakesCount()
        {
            new Throw(10);
        }

        [TestMethod]
        public void IncrementsScore()
        {
            Throw t = new Throw(10);
            int score = 12;
            t.IncrementScore(ref score);
            Assert.AreEqual(score, 22); 
        }

        [TestMethod]
        public void AllGutterThrows()
        {
            _game = new Game();
            DoThrows(20, 0);
            
            Assert.AreEqual(0, _game.Score());
        }
        
        [TestMethod]
        public void AllSinglePin()
        {
            DoThrows(20, 1);
            Assert.AreEqual(20, _game.Score());
        }

        private void DoThrows(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }

    public class Throw
    {
        private readonly int _pinsDown;

        public Throw(int pinsDown)
        {
            _pinsDown = pinsDown;
        }

        public void IncrementScore(ref int score)
        {
            score += _pinsDown;
        }
    }

    public class Game
    {
        private int _score;

        internal void Pins(Throw @throw)
        {
            @throw.IncrementScore(ref _score);
        }

        public int Score()
        {
            return _score;
        }
    }
}
