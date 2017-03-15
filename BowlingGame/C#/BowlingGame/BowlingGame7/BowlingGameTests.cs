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
            _g.Game(new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            Assert.AreEqual(0, _g.Score());
        }

        [TestMethod]
        public void AllSinglePin()
        {
            _g.Game(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            Assert.AreEqual(20, _g.Score());
        }

        [TestMethod]
        public void SingleSpare()
        {
            _g.Game(new[] { 5, 5, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            Assert.AreEqual(18, _g.Score());
        }

        [TestMethod]
        public void SingleStrike()
        {
            _g.Game(new[] { 10, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            Assert.AreEqual(24, _g.Score());
        }

        [TestMethod]
        public void PerfectGame()
        {
            _g.Game(new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });

            Assert.AreEqual(300, _g.Score());
        }
    }
}