using System;
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
            BoardStub board = new BoardStub(0);
            game = new Game(board, console);

            game.Start();

            Assert.AreEqual(0, board.GetTimesPlayed());
        }

        [Test]
        public void GameForOneTurn()
        {
            BoardStub board = new BoardStub(1);
            game = new Game(board, console);

            game.Start();
            Assert.AreEqual(1, board.GetTimesPlayed());
        }

        [Test]
        public void GameForTwoTurns()
        {
            BoardStub board = new BoardStub(2);
            game = new Game(board, console);

            game.Start();
            Assert.AreEqual(2, board.GetTimesPlayed());
        }

        [Test]
        public void PlaysAUsersMoveWhenUserTurn()
        {
            BoardStub board = new BoardStub(1);
            game = new Game(board, console);

            game.Start();
            Assert.IsTrue(board.GetWasMoveMade());
        }

        [Test]
        public void TakesAUserMovewWhenUserTurn()
        {
            BoardStub board = new BoardStub(1);
            game = new Game(board, console);

            game.Start();
            Assert.IsTrue(console.wasTakePlayerMoveCalled);
        }

        [Test]
        public void DoesNotSwitchUserFOrMovesBelowZero()
        {
            game.PlayMove(-1);
            game.PlayMove(1);

            Assert.AreEqual("X", game.PositionAt(1));
        }

        [Test]
        public void AskUserForInputWhenUserTurn()
        {
            BoardStub board = new BoardStub(1);
            game = new Game(board, console);

            game.Start();
            Assert.IsTrue(console.wasAskInputCalled);
        }

        [Test]
        public void DisplaysBoardOnUsersTurn()
        {
            BoardStub board = new BoardStub(2);
            game = new Game(board, console);

            game.Start();
            Assert.IsTrue(console.wasDisplayedBoardCalled);
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
        public void TakePlayerMoveMappingItToCorrectPositionOnBoard()
        {
            console.SetPlayerMove(5);
            game.PlayMove(game.TakePlayerMove());

            Assert.AreEqual("X", game.PositionAt(4));
        }

        [Test]
        public void PlaysMoveOnBoardAsXPlayer()
        {
            game.PlayMove(1);
            var mark = game.PositionAt(1);
            Assert.AreEqual("X", mark);
        }

        [Test]
        public void DisplayDrawnResultOnGameOver()
        {
            var board = new BoardStub(0);
            game = new Game(board, console);

            game.Start();
            Assert.IsTrue(console.wasDrawnResultDisplayed);
        }


        [Test]
        public void DisplayWinningResultOnGameOver()
        {
            BoardStub board = new BoardStub(0);
            board.SetGameWon(true);
            game = new Game(board, console);

            game.Start();

            Assert.IsTrue(console.wasWinningResultDisplayed);
        }

        [Test]
        public void ShouldNotSwitchPlayerIfPositionOccupied()
        {
            game.PlayMove(1);
            game.PlayMove(1);
            Assert.AreEqual("X", game.PositionAt(1));
        }

        [Test]
        public void SwitchesCurrentPlayerMark()
        {
            game.PlayMove(1);
            game.PlayMove(4);
            Assert.AreEqual("O", game.PositionAt(4));
        }

        [Test]
        public void DisplayCurrentPlayerAsComputerPlayer()
        {
            var board = new BoardStub(0);
            ComputerPlayer computer = new ComputerPlayer();
            HumanPlayer human = new HumanPlayer();

            game = new Game(board, console, human, computer);

            Assert.AreEqual(game.CurrentPlayer(), human);
        }

        [Test]
        public void SwitchToComputerPlayerForSecondMove()
        {
            var board = new BoardStub(0);
            ComputerPlayer computer = new ComputerPlayer();
            HumanPlayer human = new HumanPlayer();

            game = new Game(board, console, human, computer);

            game.PlayMove(1);
            game.PlayMove(2);

            Assert.AreEqual(computer, game.CurrentPlayer());
        }

        private class BoardStub: Board
        {
            private int numberOfTurns;
            private int timesPlayed;
            private bool wasMoveMade = false;
            private bool gameWon;

            public BoardStub(int numberOfTurns)
            {
                this.numberOfTurns = numberOfTurns;
            }

            public override void MakeMove(int position, char currentPlayerMark)
            {
                wasMoveMade = true;
            }

            public bool GetWasMoveMade()
            {
                return wasMoveMade;
            }

            public int GetTimesPlayed()
            {
                return timesPlayed;
            }

            public void SetGameWon(bool isGameWon)
            {
                gameWon = isGameWon;
            }

            public override bool IsGameOver()
            {
                if (numberOfTurns > 0)
                {
                    timesPlayed += 1;
                    numberOfTurns -= 1;
                    return false;
                }
                return true;
            }

            public override bool IsGameWon()
            {
                return gameWon;
            }
        }
    }
}
