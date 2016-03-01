using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    public class GameTest
    {
        private Game game;
        private SpyGameConsole console;

        [SetUp]
        public void SetupGame()
        {
            console = new SpyGameConsole();
            game = new Game(console);
        }

        [Test]
        public void GameForZeroTurns()
        {
            Board board = new BoardStub(0);
            game = new Game(board, console);

            game.Start();

            Assert.IsFalse(console.wasDisplayedBoardCalled);
        }

        [Test]
        public void GameForOneTurn()
        {
            Board board = new BoardStub(1);
            game = new Game(board, console);

            game.Start();
            Assert.IsTrue(console.wasDisplayedBoardCalled);
        }

        [Test]
        public void GameForTwoTurns()
        {
            Board board = new BoardStub(2);
            game = new Game(board, console);

            game.Start();
            Assert.AreEqual(2, console.numberOftTimesDisplayedCalled);
        }

        [Test]
        public void AskInput()
        {
            game.AskForInputPosition();
            Assert.IsTrue(console.wasAskInputCalled);
        }

        [Test]
        public void TakePlayerMove()
        {
            game.TakePlayerMove();
            Assert.IsTrue(console.wasTakePlayerMoveCalled);
        }

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

        private class BoardStub: Board
        {
            private int numberOfTurns;

            public BoardStub(int numberOfTurns)
            {
                NumberOfTurns = numberOfTurns;
            }

            public int NumberOfTurns
            {
                get {
                    return numberOfTurns;
                }
                set {
                    numberOfTurns = value;
                }
            }

            public override bool IsGameOver()
            {
                if (NumberOfTurns <= 0) return true;
                NumberOfTurns -= 1;
                return false;
            }
        }
    }
}
