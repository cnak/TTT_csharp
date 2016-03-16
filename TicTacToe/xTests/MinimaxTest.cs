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
            var best_move = Minimax.move(board);
            Assert.AreEqual(1, best_move);
        }
    }
}
