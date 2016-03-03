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

        public Game(IGameConsole console)
        {
            this.console = console;
            this.board = new Board();
        }

        public Game(Board board, IGameConsole console)
        {
            this.board = board;
            this.console = console;
        }

        public void Start()
        {
            while (!board.IsGameOver())
            {
                PlayTurn();
            }
            DisplayResult();
        }

        private void PlayTurn()
        {
            console.DisplayBoard(board);
            AskForInputPosition();
            PlayMove(TakePlayerMove());
        }
        public void AskForInputPosition()
        {
            console.AskForInputPosition();
        }

        public void DisplayResult()
        {
            if (board.IsGameWon())
            {
                console.DisplayGameWonResult(board.GetWinner());
            }
            else
            {
                console.DisplayGameDrawnResult();
            }
        }

        public void PlayMove(int position)
        {
            try
            {
                board.MakeMove(position, currentPlayerMark);
                ToggleCurrentPlayerMark();
            }
            catch (ArgumentException)
            {
            }
        }

        private void ToggleCurrentPlayerMark()
        {
            currentPlayerMark = currentPlayerMark == 'X' ? 'O' : 'X';
        }

        public object PositionAt(int position)
        {
            return board.PositionAt(position);
        }

        public int TakePlayerMove()
        {
            return console.TakePlayerMove();
        }
    }
}
