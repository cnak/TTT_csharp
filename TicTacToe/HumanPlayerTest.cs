using NUnit.Framework;

namespace TicTacToe
{
    class HumanPlayerTest
    {
        [Test]
        public void GetsPlayersMoveFromTheConsole()
        {
            var console = new SpyGameConsole();
            var player = new HumanPlayer(console);

            console.SetPlayerMove(1);

            Assert.AreEqual(1, player.GetMove(new Board()));
        }

    }
}
