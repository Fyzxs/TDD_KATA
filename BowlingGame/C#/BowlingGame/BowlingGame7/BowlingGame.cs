using System;

namespace BowlingGame7
{
    public class BowlingGame : GameScoring.IScoreEngine
    {
        private const int StepOneThrow = 1;
        private const int StepFrame = 2;
        private const int Frames = 10;
        private const int AllPins = 10;
        private delegate int Scoring(int ptr, int[]throws);

        private static readonly Tuple<int, Scoring> SimpleScoring = new Tuple<int, Scoring>
            (StepFrame, (ptr, throws) => throws[ptr] + throws[ptr + 1]);

        private static readonly Tuple<int, Scoring> SpareScoring = new Tuple<int, Scoring>
            (StepFrame, (ptr, throws) => AllPins + throws[ptr + 2]);

        private static readonly Tuple<int, Scoring> StrikeScoring = new Tuple<int, Scoring>
            (StepOneThrow, (ptr, throws) => AllPins + throws[ptr + 1] + throws[ptr + 2]);

        private int _score;

        public int InternalScore(int[] throws)
        {
            int score = 0;
            for (int frame = 0, ptrRoll = 0; frame < Frames; frame++)
            {
                Tuple<int, Scoring> scoring = Factory(ptrRoll, throws);
                score += scoring.Item2(ptrRoll, throws);
                ptrRoll += scoring.Item1;
            }

            _score = score;
        }

        public int Score()
        {
            return _score;
        }

        private Tuple<int, Scoring> Factory(int ptr, int[] throws)
        {
            if (IsStrike(ptr, throws)) return StrikeScoring;
            if (IsSpare(ptr, throws)) return SpareScoring;

            return SimpleScoring;
        }

        private bool IsStrike(int ptrRoll, int[] throws) => AllPins == throws[ptrRoll];

        private bool IsSpare(int ptrRoll, int[] throws) => AllPins == throws[ptrRoll] + throws[ptrRoll];

        public int Score(int[] values)
        {
            throw new NotImplementedException();
        }
    }
}