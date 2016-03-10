using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        private readonly IGameConsole console;
        private readonly Board board;
        private char currentPlayerMark = 'X';

        private IPlayer currentPlayer;
        private IPlayer otherPlayer;

        public Game(IGameConsole console)
        {
            this.console = console;
            board = new Board();
            currentPlayer = new HumanPlayer(console);
            otherPlayer = new HumanPlayer(console);
        }

        public Game(Board board, IGameConsole console)
        {
            this.board = board;
            this.console = console;

            currentPlayer = new HumanPlayer(console);
            otherPlayer = new HumanPlayer(console);
        }

        public Game(Board board, IGameConsole console, HumanPlayer human, ComputerPlayer computer) : this(board, console)
        {
            currentPlayer = human;
            otherPlayer = computer;
        }

        public Game(Board board, IGameConsole console, ComputerPlayer computer1, ComputerPlayer computer2) : this(board, console)
        {
            currentPlayer = computer1;
            otherPlayer = computer2;
        }

        public Game(Board board, IGameConsole console, HumanPlayer human1, HumanPlayer human2) : this(board, console)
        {
            currentPlayer = human1;
            otherPlayer = human2;
        }

        public void Start()
        {
            PlayGame();
            DisplayResult();
        }

        public void AskForInputPosition()
        {
            console.AskForInputPosition();
        }

        public void DisplayResult()
        {
            if (board.IsGameWon())
                console.DisplayGameWonResult(board.GetWinner());
            else
                console.DisplayGameDrawnResult();
        }

        public void PlayMove(int position)
        {
            try
            {
                board.MakeMove(position, currentPlayerMark);
                ToggleCurrentPlayerMark();
                SwitchCurrentPlayer();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is IndexOutOfRangeException)
            {
            }
        }

        public string PositionAt(int position)
        {
            return board.PositionAt(position);
        }

        public int TakePlayerMove()
        {
            return currentPlayer.GetMove(board);
        }

        private void ToggleCurrentPlayerMark()
        {
            currentPlayerMark = currentPlayerMark == 'X' ? 'O' : 'X';
        }

        private void SwitchCurrentPlayer()
        {
            var tempPlayer = currentPlayer;
            currentPlayer = otherPlayer;
            otherPlayer = tempPlayer;
        }


        private void PlayTurn()
        {
            DisplayBoard();
            AskForInputPosition();
            PlayMove(TakePlayerMove());
        }

        private void DisplayBoard()
        {
            console.DisplayBoard(board);
        }

        private void PlayGame()
        {
            while (IsGameNotOver())
                PlayTurn();
        }

        private bool IsGameNotOver()
        {
            return !board.IsGameOver();
        }

        public object CurrentPlayer()
        {
            return currentPlayer;
        }
    }
}