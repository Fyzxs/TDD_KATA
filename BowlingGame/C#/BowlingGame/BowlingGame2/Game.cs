using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame2
{
    internal class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            var score = 0;
            for (int frameIndex = 0, rollIndex = 0; frameIndex < 10; frameIndex += 1)
            {
                if (IsStrike(rollIndex))
                {
                    score += StrikeScore(rollIndex);
                    rollIndex += 1;
                }
                else
                {
                    score += IsSpare(rollIndex) 
                        ? SpareScore(rollIndex) 
                        : FrameScore(rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }

        private int FrameScore(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex + 1];
        }

        private int SpareScore(int rollIndex)
        {
            return 10 + _rolls[rollIndex + 2];
        }

        private int StrikeScore(int rollIndex)
        {
            return 10 + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
        }

        private bool IsStrike(int rollIndex)
        {
            return _rolls[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex + 1] == 10;
        }
    }
}
