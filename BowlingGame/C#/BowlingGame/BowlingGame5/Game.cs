using System;
using System.Threading.Tasks;

namespace BowlingGame5
{
    public class Game
    {
        private const int StepOneThrow = 1;
        private const int StepFrame = 2;
        private const int Frames = 10;
        private delegate int Scoring(int ptr, Game game);

        private static readonly Tuple<int, Scoring> SimpleScoring = new Tuple<int, Scoring>
            (StepFrame, (ptr, game) => game._rolls[ptr] + game._rolls[ptr + 1]);

        private static readonly Tuple<int, Scoring> SpareScoring = new Tuple<int, Scoring>
            (StepFrame, (ptr, game) => 10 + game._rolls[ptr + 2]);

        private static readonly Tuple<int, Scoring> StrikeScoring = new Tuple<int, Scoring>
            (StepOneThrow, (ptr, game) => 10 + game._rolls[ptr + 1] + game._rolls[ptr + 2]);

        private readonly int[] _rolls = new int[21];
        private int _ptrRolls;

        public void Roll(int pins) => _rolls[_ptrRolls++] = pins;

        public int Score()
        {
            int score = 0;
            for (int frame = 0, ptrRoll = 0; frame < Frames; frame++)
            {
                Tuple<int, Scoring> scoring = Factory(ptrRoll);
                score += scoring.Item2(ptrRoll, this);
                ptrRoll += scoring.Item1;
            }
            return score;
        }

        private Tuple<int, Scoring> Factory(int ptr)
        {
            if (IsStrike(ptr)) return StrikeScoring;
            if (IsSpare(ptr)) return SpareScoring;
            return SimpleScoring;
        }

        private bool IsStrike(int ptrRoll) => 10 == _rolls[ptrRoll];
        
        private bool IsSpare(int ptrRoll) => 10 == _rolls[ptrRoll] + _rolls[ptrRoll];
    }
}