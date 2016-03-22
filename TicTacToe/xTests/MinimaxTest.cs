using NUnit.Framework;

namespace TicTacToe.xTests
{
    class MinimaxTest
    {
        [Test]
        public void ShouldBlockTheOpponentByPlayingThree()
        {
            var board = new Board("XO-" +
                                  "-XX" +
                                  "OXO");
//            var board = new Board("-X-" +
//                                  "--X" +
//                                  "OOX");
//
            Assert.AreEqual(3, (new Minimax().Move(board)));
//            Assert.AreEqual(2, (new Minimax().Move(board)));
        }

        [Test]
        public void ReturnsOneAsTheWinningMove()
        {
            var board = new Board("--X" +
                                  "XOX" +
                                  "-O-");
            var best_move = new Minimax().Move(board);
            Assert.AreEqual(1, best_move);
        }

        [Test]
        public void ReturnsLostScore()
        {
            var board = new Board("XOX" +
                                  "OXO" +
                                  "X--");
            var minimaxPlayer = "O";

            var score = new Minimax().Score(board, 0, minimaxPlayer);
            Assert.AreEqual(-10, score);
        }

        [Test]
        public void ReturnsDrawnScore()
        {
            var board = new Board("XOX" +
                                  "OXO" +
                                  "OXO");

            var minimaxPlayer = "O";

            var score = new Minimax().Score(board, 0, minimaxPlayer);
            Assert.AreEqual(0, score);
        }

        [Test]
        public void ReturnsWinningScore()
        {
            var board = new Board("-OX" +
                                  "XOX" +
                                  "-O-");

            var minimaxPlayer = "O";

            var score = new Minimax().Score(board, 0, minimaxPlayer);
            Assert.AreEqual(10, score);
        }
    }
}
