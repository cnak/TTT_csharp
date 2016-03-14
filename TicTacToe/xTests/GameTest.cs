using System;
using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    public class GameTest
    {
        private Game game;
        private SpyConsoleGame console;
        private SpyComputerPlayer computerPlayer;

        [SetUp]
        public void SetupGame()
        {
            console = new SpyConsoleGame();
            game = new Game(console);
        }

        [Test]
        public void ReturnTheOtherPlayer()
        {
            var player1 = new ConsoleHumanPlayer(console);
            var player2 = new ConsoleHumanPlayer(console);
            game = new Game(new BoardStub(0), console, player1, player2);

            Assert.AreEqual(player1, game.CurrentPlayer());
            Assert.AreEqual(player2, game.OtherPlayer());
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
            console = new SpyConsoleGame();
            game = new Game(console);

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
            ConsoleHumanPlayer consoleHuman = new ConsoleHumanPlayer();

            game = new Game(board, console, consoleHuman, computer);

            Assert.AreEqual(game.CurrentPlayer(), consoleHuman);
        }

        [Test]
        public void SwitchToComputerPlayerForSecondMove()
        {
            var board = new BoardStub(0);
            ComputerPlayer computer = new ComputerPlayer();
            ConsoleHumanPlayer consoleHuman = new ConsoleHumanPlayer();

            game = new Game(board, console, consoleHuman, computer);

            game.PlayMove(1);

            Assert.AreEqual(computer, game.CurrentPlayer());
        }

        [Test]
        public void SwitchToHumanPlayerForThirdMove()
        {
            var board = new BoardStub(0);
            ComputerPlayer computer = new ComputerPlayer();
            ConsoleHumanPlayer consoleHuman = new ConsoleHumanPlayer();

            game = new Game(board, console, consoleHuman, computer);

            game.PlayMove(1);
            game.PlayMove(2);

            Assert.AreEqual(consoleHuman, game.CurrentPlayer());
        }

        [Test]
        public void StartAHumanVsHumanGameWithHuman1()
        {
            var board = new BoardStub(0);
            var human1 = new ConsoleHumanPlayer();
            var human2 = new ConsoleHumanPlayer();

            game = new Game(board, console, human1, human2);

            Assert.AreEqual(human1, game.CurrentPlayer());
        }

        [Test]
        public void SwitchToHumanPlayerForHumanVsHumanGame()
        {
            var board = new BoardStub(0);
            var human1 = new ConsoleHumanPlayer();
            var human2 = new ConsoleHumanPlayer();

            game = new Game(board, console, human1, human2);

            game.PlayMove(0);

            Assert.AreEqual(human2, game.CurrentPlayer());
        }

        [Test]
        public void TakeHumanPlayersMove()
        {
            var humanPlayer = new SpyConsoleHumanPlayer();

            game = new Game(new Board(), console, humanPlayer, new ComputerPlayer());
            game.TakePlayerMove();

            Assert.IsTrue(humanPlayer.wasGetMoveCalled);
        }

        private class SpyConsoleHumanPlayer : ConsoleHumanPlayer
        {
            public bool wasGetMoveCalled;

            public override int GetMove(Board board)
            {
                wasGetMoveCalled = true;
                return 0;
            }
        }

        [Test]
        public void TakeComputerPlayersMove()
        {
            var computerPlayer = new SpyComputerPlayer();

            game = new Game(new Board(), console, new ConsoleHumanPlayer(), computerPlayer);
            game.PlayMove(0);
            game.TakePlayerMove();

            Assert.IsTrue(computerPlayer.wasGetMoveCalled);
        }

        [Test]
        public void SwitchesToComputerPlayer1AfterTurnForComputerVsComputer()
        {
            var board = new BoardStub(0);
            ComputerPlayer computer1 = new ComputerPlayer();
            ComputerPlayer computer2 = new ComputerPlayer();

            game = new Game(board, console, computer1, computer2);

            game.PlayMove(1);
            game.PlayMove(2);
            Assert.AreEqual(computer1, game.CurrentPlayer());
        }

        [Test]
        public void SwitchesToComputerPlayer2AfterTurn()
        {
            var board = new BoardStub(0);
            ComputerPlayer computer1 = new ComputerPlayer();
            ComputerPlayer computer2 = new ComputerPlayer();

            game = new Game(board, console, computer1, computer2);

            game.PlayMove(1);
            Assert.AreEqual(computer2, game.CurrentPlayer());
        }

        [Test]
        public void TakeComputerPlayersMoveInComputerVsComputer()
        {
            var computerPlayer = new SpyComputerPlayer();

            game = new Game(new Board(), console, new ComputerPlayer(), computerPlayer);
            game.PlayMove(0);
            game.TakePlayerMove();

            Assert.IsTrue(computerPlayer.wasGetMoveCalled);
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

        private class SpyComputerPlayer : ComputerPlayer
        {
            public bool wasGetMoveCalled;

            public override int GetMove(Board board)
            {
                wasGetMoveCalled = true;
                return 0;
            } 
        }
    }
}
