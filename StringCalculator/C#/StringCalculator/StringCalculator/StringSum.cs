using System;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    internal class StringSum
    {
        public int Sum(string numberString)
        {
            if (IsEmpty(numberString)) return 0;
            var numbers = SplitNumbers(numberString);
            ThrowOnNegatives(numbers);
            return numbers.Sum(int.Parse);
        }

        private static void ThrowOnNegatives(string[] numbers)
        {

            var negatives = numbers.Where(n => int.Parse(n) < 0).ToList();
            if (!negatives.Any()) return;

            throw new ArgumentException($"Negative Values [{string.Join(",", negatives)}] not allowed");
        }

        private static string[] SplitNumbers(string numberString)
        {
            if (!numberString.StartsWith("//")) return numberString.Split(',', '\n');
            
            int firstLineEnd = numberString.IndexOf('\n');
            string delim = numberString.Substring(2, 1);
            return numberString.Substring(firstLineEnd + 1).Split(delim.ToCharArray());
        }

        private static bool IsEmpty(string numberString)
        {
            return numberString == string.Empty;
        }
    }
}