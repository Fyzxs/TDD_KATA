using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame7
{
    [TestClass]
    public class BowlingGameTest
    {
        private BowlingGame _g;

        [TestInitialize]
        public void Initialize()
        {
            _g = new BowlingGame();
        }

        [TestMethod]
        public void GutterGame()
        {
            Assert.AreEqual(0, _g.Score(new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
        }

        [TestMethod]
        public void AllSinglePin()
        {
            Assert.AreEqual(20, _g.Score(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        }

        [TestMethod]
        public void SingleSpare()
        {
            Assert.AreEqual(18, _g.Score(new[] { 5, 5, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
        }

        [TestMethod]
        public void SingleStrike()
        {
            Assert.AreEqual(24, _g.Score(new[] { 10, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
        }

        [TestMethod]
        public void PerfectGame()
        {
            Assert.AreEqual(300, _g.Score(new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }));
        }
    }
}