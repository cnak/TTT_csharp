using System.Linq;
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
        public void InformsGameHasNotBeenWonForRowWithEmtpyCells()
        {
            Board board = new Board("---" +
                                    "X-O" +
                                    "--X");

            Assert.IsFalse((board.IsGameWon()));
        }

        [Test]
        public void InformsGameHasBeenWonForLeftColumn()
        {
            Board board = new Board("XXO" +
                                    "XOX" +
                                    "XOO");

            Assert.IsTrue((board.IsGameWon()));
        }

        [Test]
        public void InformsGameHasBeenWonForMiddleColumn()
        {
            Board board = new Board("XXO" +
                                    "OXX" +
                                    "XXO");

            Assert.IsTrue((board.IsGameWon()));
        }

        [Test]
        public void InformsGameHasBeenWonForRightColumn()
        {
            Board board = new Board("OOX" +
                                    "XOX" +
                                    "OXX");

            Assert.IsTrue((board.IsGameWon()));
        }

        [Test]
        public void InformsGameHasNotBeenWonForColumnWithEmtpyCells()
        {
            Board board = new Board("--X" +
                                    "--O" +
                                    "--X");

            Assert.IsFalse((board.IsGameWon()));
        }

        [Test]
        public void InformsGameHasNotBeenWonForDiagonalLeft()
        {
            Board board = new Board("X--" +
                                    "-XO" +
                                    "X-X");

            Assert.IsTrue((board.IsGameWon()));
        }

        [Test]
        public void InformsGameHasNotBeenWonForDiagonalRight()
        {
            Board board = new Board("--X" +
                                    "-XO" +
                                    "X-X");

            Assert.IsTrue((board.IsGameWon()));
        }
    }
}
