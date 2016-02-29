using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    public class GameTest
    {
        private Game game;
        private FakeGameConsole console;

        [SetUp]
        public void SetupGame()
        {
            game = new Game(console);
        }

//        [Test]
//        public void ConsoleDisplaysOnStart() { 
//            game.Start();
//        }
//
//        [Test]
//        public void AskInput()
//        {
//            game.AskForInputPosition();
//        }

        [Test]
        public void PlaysMoveOnBoardAsXPlayer()
        {
            game.PlayMove(1);
            var mark = game.PositionAt(1);
            Assert.AreEqual("X", mark);
        }

        [Test]
        public void SwitchesCurrentPlayerMark()
        {
            game.PlayMove(1);
            game.PlayMove(4);
            Assert.AreEqual("O", game.PositionAt(4));
        }
    }
}
