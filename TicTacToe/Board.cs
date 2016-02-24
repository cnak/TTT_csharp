using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {
    public class Board
    {
        private readonly string grid;

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
            return RowIsAllTheSame() || IsLeftColumnTheSame();
        }

        private bool RowIsAllTheSame()
        {
            return TopRowIsSame() || MiddleRowTheSame() || BottomRowTheSame();
        }
        private bool IsLeftColumnTheSame()
        {
            return (IsColumnMarksTheSame(0, 3, 6));
        }

        private bool IsColumnMarksTheSame(int top, int middle, int bottom)
        {
            return (grid[top] == grid[middle]) && (grid[middle] == grid[bottom]);
        }

        private bool IsRowTheSame(int begining)
        {
            char[] markers = grid.Substring(begining,3).ToArray();
            return Array.TrueForAll(markers, marker => markers.Length > 0 && marker == markers[0] );
        }

        private bool BottomRowTheSame()
        {
            return IsRowTheSame(6);
        }

        private bool MiddleRowTheSame()
        {
            return IsRowTheSame(3);
        }

        private bool TopRowIsSame()
        {
            return IsRowTheSame(0);
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
