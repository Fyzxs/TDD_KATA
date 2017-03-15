using System;
using System.Linq;

namespace BowlingGame7
{
    public class BlackJackGame : GameScoring.IScoreEngine
    {
        private const int MaxScore = 21;

        private int ScoreInternal(int[] cards)
        {
            return cards.Sum();
        }

        public int Score(int[] values)
        {
            int score = ScoreInternal(values);
            return score <= MaxScore ? score : throw new ArgumentOutOfRangeException();
        }
    }
}