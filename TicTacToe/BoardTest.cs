using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    class BoardTest
    {
        [Test]
        public void InformsTheGameIsNotOver()
        {
            Board board = new Board();

            Assert.IsFalse(board.IsGameOver());
        }

        [Test]
        public void InformsTheGameIsOverWithNoMoreMoves()
        {
            Board board = new Board("XOXOXOXOX");

            Assert.IsTrue(board.IsGameOver());
        }

        [Test]
        public void InformsGameIsNotOverWithMovesLeft()
        {
            Board board = new Board("XOXO");

            Assert.IsFalse(board.IsGameOver());
        }

        [Test]
        public void InformsGameHasNotBeenWon()
        {
             Board board = new Board("XOX" +
                                     "XXO" +
                                     "OXO");

            Assert.IsFalse((board.IsGameWon()));
        }

        [Test]
        public void InformsGameHasBeenWonForTopRow()
        {
            Board board = new Board("XXX" +
                                    "OXO" +
                                    "XOO");

            Assert.IsTrue((board.IsGameWon()));
        }

        [Test]
        public void InformsGameHasBeenWonForMiddleRow()
        {
            Board board = new Board("XOX" +
                                    "OOO" +
                                    "XXO");

            Assert.IsTrue((board.IsGameWon()));
        }

        [Test]
        public void InformsGameHasBeenWonForBottomRow()
        {
            Board board = new Board("XOX" +
                                    "XOX" +
                                    "OOO");

            Assert.IsTrue((board.IsGameWon()));
        }

        [Test]
        public void InformsGameHasBeenWonForLeftColumn()
        {
            Board board = new Board("XXO" +
                                    "XOX" +
                                    "XOO");

            Assert.IsTrue((board.IsGameWon()));
        }
    }
}
