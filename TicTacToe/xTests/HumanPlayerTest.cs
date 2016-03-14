using NUnit.Framework;

namespace TicTacToe
{
    class HumanPlayerTest
    {
        [Test]
        public void GetsPlayersMoveFromTheConsole()
        {
            var console = new SpyGameConsole();
            var player = new ConsoleHumanPlayer(console);

            console.SetPlayerMove(2);

            Assert.AreEqual(1, player.GetMove(new Board()));
        }

    }
}
