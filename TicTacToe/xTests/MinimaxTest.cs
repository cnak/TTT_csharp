using NUnit.Framework;

namespace TicTacToe.xTests
{
    class MinimaxTest
    {
        [Test]
        public void ReturnsOneAsTheWinningMove()
        {
            var board = new Board("--X" +
                                  "XOX" +
                                  "-O-");
            var best_move = Minimax.Move(board);
            Assert.AreEqual(1, best_move);
        }

        [Test]
        public void ReturnsLostScore()
        {
            var board = new Board("XOX" +
                                  "OXO" +
                                  "X--");
            var minimaxPlayer = "O";

            var score = Minimax.Score(board, 0, minimaxPlayer);
            Assert.AreEqual(-10, score);
        }

        [Test]
        public void ReturnsDrawnScore()
        {
            var board = new Board("XOX" +
                                  "OXO" +
                                  "OXO");

            var minimaxPlayer = "O";

            var score = Minimax.Score(board, 0, minimaxPlayer);
            Assert.AreEqual(0, score);
        }

        [Test]
        public void ReturnsWinningScore()
        {
            var board = new Board("-OX" +
                                  "XOX" +
                                  "-O-");

            var minimaxPlayer = "O";

            var score = Minimax.Score(board, 0, minimaxPlayer);
            Assert.AreEqual(10, score);
        }
    }
}
