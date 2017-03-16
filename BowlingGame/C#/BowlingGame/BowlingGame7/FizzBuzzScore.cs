using System.Text;

namespace BowlingGame7
{
    public class FizzBuzzScore : GameScoring.IScoreEngine<int, string>
    {
        public string Score(int number)
        {
            StringBuilder sb = new StringBuilder();
            
            if (number % 3 == 0)
            {
                sb.Append("Fizz");
            }

            if (number % 5 == 0)
            {
                sb.Append("Buzz");
            }

            if (sb.Length == 0)
            {
                sb.Append(number);
            }

            return sb.ToString();
        }
    }
}