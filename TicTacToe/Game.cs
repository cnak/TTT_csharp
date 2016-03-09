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
        private HumanPlayer humanPlayer;
        private IPlayer computerPlayer;
        private IPlayer currentPlayer;

        public Game(IGameConsole console)
        {
            this.console = console;
            board = new Board();
        }

        public Game(Board board, IGameConsole console)
        {
            this.board = board;
            this.console = console;
        }

        public Game(Board board, IGameConsole console, HumanPlayer human, ComputerPlayer computer) : this(board, console)
        {
            currentPlayer = human;
            computerPlayer = computer;
            humanPlayer = human;
        }

//        public Game(GameSetup setup)
//        {
//            board = setup.Board();
//            console = setup.Console();
//            players = setup.Players();
//        }

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

        private void SwitchCurrentPlayer()
        {
            if (currentPlayer == humanPlayer)
                currentPlayer = computerPlayer;
            else
                computerPlayer = humanPlayer;
        }

        public string PositionAt(int position)
        {
            return board.PositionAt(position);
        }

        public int TakePlayerMove()
        {
            return console.TakePlayerMove() -1;
        }

        private void ToggleCurrentPlayerMark()
        {
            currentPlayerMark = currentPlayerMark == 'X' ? 'O' : 'X';
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
