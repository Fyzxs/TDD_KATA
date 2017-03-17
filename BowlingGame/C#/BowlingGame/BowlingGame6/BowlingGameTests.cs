using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame6
{
    [TestClass]
    public class BowlingGameTests
    {
        private Game _game;

        [TestInitialize]
        public void Setup()
        {
            _game = new Game();
        }

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
            DoThrows(20, 0);
            Assert.AreEqual(0, _game.Score());
        }
        
        [TestMethod]
        public void AllSinglePin()
        {
            DoThrows(20, 1);
            Assert.AreEqual(20, _game.Score());
        }

        [TestMethod]
        public void ASpare()
        {
            _game.Throw(new Throw(4));
            _game.Throw(new Throw(6));//spare
            _game.Throw(new Throw(3));
            DoThrows(17, 0);
            Assert.AreEqual(16, _game.Score());
        }
        

        [TestMethod]
        public void IsSpareWithShouldBeFalseForNonSpare()
        {
            Throw firstThrow = new Throw(1);
            Throw secondThrow = new Throw(8);
            Assert.IsFalse(firstThrow.IsAllPins(secondThrow));
        }
        [TestMethod]
        public void IsSpareWithShouldBeTrueForSpare()
        {
            Throw firstThrow = new Throw(2);
            Throw secondThrow = new Throw(8);
            Assert.IsTrue(firstThrow.IsAllPins(secondThrow));
        }

        [TestMethod]
        public void IsAllPinsShouldBeFalseGivenNot10()
        {
            Throw firstThrow = new Throw(1);
            Assert.IsFalse(firstThrow.IsAllPins());
        }

        [TestMethod]
        public void IsAllPinsShouldBeTrueGiven10()
        {
            Throw firstThrow = new Throw(10);
            Assert.IsTrue(firstThrow.IsAllPins());
        }

        [TestMethod]
        public void SingleStrike()
        {
            _game.Throw(new Throw(10));
            _game.Throw(new Throw(3));
            _game.Throw(new Throw(4));
            DoThrows(16, 0);
            Assert.AreEqual(24, _game.Score());
        }
        [TestMethod]
        public void PerfectGame()
        {
            DoThrows(12, 10);
            Assert.AreEqual(300, _game.Score());
        }

        private void DoThrows(int throws, int pins)
        {
            for (int ctr = 0; ctr < throws; ctr++)
            {
                _game.Throw(new Throw(pins));
            }
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

        public bool IsAllPins(Throw other)
        {
            return this._pinsDown + other._pinsDown == 10;
        }

        public bool IsAllPins()
        {
            return IsAllPins(new Throw(0));
        }
    }

    public class Game
    {
        private readonly List<Throw> _throws = new List<Throw>(21);

        internal void Throw(Throw @throw)
        {
            _throws.Add(@throw);
        }

        public int Score()
        {
            int score = 0;
            for (int frame = 0, index = 0; frame < 10; frame++)
            {
                var @throw = _throws[index];

                @throw.IncrementScore(ref score);

                if (IsStrike(@throw))
                {
                    score = ScoreStrike(@throw, score, index);
                    index += 1;
                }
                else if (IsSpare(@throw, index))
                {
                    score = ScoreSpare(@throw, score, index);
                    index += 2;
                }
                else
                {
                    score = ScoreFrame(@throw, score, index);
                    index += 2;
                }
            }

            return score;
        }

        private int ScoreFrame(Throw @throw, int score, int index)
        {
            @throw.IncrementScore(ref score);
            _throws[index + 1].IncrementScore(ref score);
            return score;
        }

        private int ScoreSpare(Throw @throw, int score, int index)
        {
            @throw.IncrementScore(ref score);
            _throws[index + 1].IncrementScore(ref score);
            _throws[index + 2].IncrementScore(ref score);
            return score;
        }

        private int ScoreStrike(Throw @throw, int score, int index)
        {
            @throw.IncrementScore(ref score);
            _throws[index + 1].IncrementScore(ref score);
            _throws[index + 2].IncrementScore(ref score);
            return score;
        }

        private bool IsSpare(Throw @throw, int index)
        {
            return @throw.IsAllPins(_throws[index + 1]);
        }

        private static bool IsStrike(Throw @throw)
        {
            return @throw.IsAllPins();
        }
    }
}
