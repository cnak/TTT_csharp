using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {
    public class Board
    {
        private string grid;

        public Board() : this("")
        {
        }

        public Board(string grid)
        {
            this.grid = grid;
        }

        public bool IsGameOver()
        {
            return AreThereAnyMovesLeft();
        }

        public bool IsGameWon()
        {
            return true;
        }

        private bool AreThereAnyMovesLeft()
        {
            return !AnyMovesLeft();
        }

        private bool AnyMovesLeft()
        {
            IEnumerable<int> rangeOfMoves = Enumerable.Range(0, 9);

            return rangeOfMoves.Contains(grid.Length);
        }
    }
}
