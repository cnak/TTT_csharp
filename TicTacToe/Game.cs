using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        private IGameConsole console;
        private Board board;
        private char currentPlayerMark = 'X';

        public Game(IGameConsole console)
        {
            this.console = console;
            this.board = new Board();
        }

        public void Start()
        {
            console.DisplayBoard();
        }

        public void AskForInputPosition()
        {
            console.Write("Please play a move");
        }

        public void PlayMove(int position)
        {
            board.MakeMove(position, currentPlayerMark);
            ToggleCurrentPlayerMark();
        }

        private void ToggleCurrentPlayerMark()
        {
            currentPlayerMark = currentPlayerMark == 'X' ? 'O' : 'X';
        }

        public object PositionAt(int position)
        {
            return board.PositionAt(position);
        }
    }
}
