using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    public class GameTest
    {
        private FakeGameConsole console;
        private Game game;

        public GameTest() {
            console = new FakeGameConsole();
            game = new Game(console);
        }

        [Test]
        public void ConsoleDisplaysOnStart() { 
             string empty_grid = "-------\n|1|2|3|\n-------\n|4|5|6|\n-------\n|7|8|9|\n-------\n";
            game.Start();
            Assert.AreEqual(empty_grid, console.LastPrintedMessage());
        }

        [Test]
        public void AskInput()
        {
            game.AskForInputPosition();
            Assert.AreEqual("Please Enter Input", console.LastPrintedMessage());
        }
    }
}
