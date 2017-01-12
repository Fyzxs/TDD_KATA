using System.Linq.Expressions;

namespace BowlingGameTests
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public void Roll(int pinsDown)
        {
            _rolls[_currentRoll++] = pinsDown;
        }

        public int Score()
        {
            int score = 0;
            for (int frame = 0, frameIndex = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }

        private int SpareBonus(int frameIndex) => _rolls[frameIndex + 2];

        private int StrikeBonus(int frameIndex) => _rolls[frameIndex + 1] + _rolls[frameIndex + 2];

        private int SumOfBallsInFrame(int frameIndex) => _rolls[frameIndex] + _rolls[frameIndex + 1];

        private bool IsStrike(int frameIndex) => _rolls[frameIndex] == 10;

        private bool IsSpare(int frameIndex) => _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
    }
}