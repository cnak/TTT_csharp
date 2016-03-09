using NUnit.Framework;

namespace TicTacToe
{
    class HumanPlayerTest
    {
        [Test]
        public void ReturnsAnInvalidMove()
        {
            HumanPlayer player = new HumanPlayer();
            Assert.AreEqual(-1, player.GetMove(new Board()));
        }

    }
}
