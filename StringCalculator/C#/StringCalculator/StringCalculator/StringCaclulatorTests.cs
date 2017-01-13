using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator
{
    [TestClass]
    public class StringCaclulatorTests
    {
        private readonly StringSum _s = new StringSum();
        [TestMethod]
        public void EmptyString()
        {
            Assert.AreEqual(0, _s.Sum(""));
        }

        [TestMethod]
        public void SingleDigit()
        {
            Assert.AreEqual(3, _s.Sum(3.ToString()));
        }

        [TestMethod]
        public void TwoDigitsComma()
        {
            Assert.AreEqual(5, _s.Sum("3,2"));
        }

        [TestMethod]
        public void TwoDigitsNewLine()
        {
            Assert.AreEqual(5, _s.Sum("3\n2"));
        }

        [TestMethod]
        public void ThreeDigitsEitherDelimiter()
        {
            Assert.AreEqual(9, _s.Sum("3\n2,4"));
        }

        [TestMethod]
        public void UnknownNumbersEitherDelim()
        {
            int rnd = new Random().Next(5, 20);
            StringBuilder sb = new StringBuilder();
            int sum = 0;
            for (int i = 1; i < rnd; i++)
            {
                sum += i;
                sb.Append(i);
                sb.Append(i%2 == 0 ? ',' : '\n');//Alternating delimiter
            }
            sb.Remove(sb.Length - 1, 1);
            Assert.AreEqual(sum, _s.Sum(sb.ToString()));
        }

        [TestMethod]
        public void ConfigurableDelimiter()
        {
            Assert.AreEqual(6, _s.Sum("//;\n1;2;3"));
        }

        [TestMethod]
        public void NegativeThrows()
        {
            try
            {
                _s.Sum("-13");
                Assert.Fail("Exception Not Thrown");
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(e.Message.Contains("-13"));
            }
        }
        [TestMethod]
        public void NegativeThrowContainsAllNegatives()
        {
            try
            {
                _s.Sum("-13,1,-12");
                Assert.Fail("Exception Not Thrown");
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(e.Message.Contains("-13,-12"));
            }
        }

    }
}
