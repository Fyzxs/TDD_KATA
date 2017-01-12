namespace BowlingGame4
{
    internal class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _ptr;

        public void Roll(int pins)
        {
            _rolls[_ptr++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int pinsIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(pinsIndex))
                {
                    score += StrikeBonuns(pinsIndex);
                    pinsIndex += 1;
                    continue;
                }
                if (IsSpare(pinsIndex))
                {
                    score += 10 + SpareBonus(pinsIndex);
                }
                else
                {
                    score += _rolls[pinsIndex] + _rolls[pinsIndex + 1];
                }
                pinsIndex += 2;
            }
            return score;
        }

        private int SpareBonus(int pinsIndex)
        {
            return _rolls[pinsIndex + 2];
        }

        private int StrikeBonuns(int pinsIndex)
        {
            return 10 + _rolls[pinsIndex + 1] + _rolls[pinsIndex + 2];
        }

        private bool IsStrike(int pinsIndex)
        {
            return _rolls[pinsIndex] == 10;
        }

        private bool IsSpare(int pinsIndex)
        {
            return _rolls[pinsIndex] + _rolls[pinsIndex + 1] == 10;
        }
    }
}