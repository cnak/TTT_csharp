using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {
    public class Board
    {
        private readonly string grid;

        public Board() : this(EmptyGrid())
        {
        }

        public Board(string grid)
        {
            this.grid = grid;
        }

        public bool IsGameOver()
        {
            return AreThereAnyMovesLeft() || IsGameWon();
        }

        public bool IsGameWon()
        {
            return AnyRowColumnsTheSame();
        }

        private bool AnyRowColumnsTheSame()
        {
            return AreAnyRowAllTheSame() || AreAnyColumnTheSame() || IsDiagonalRightTheSame() || IsDiagonalLeftTheSame();
        }

        private bool IsTheSameMarker(int firstPosition, int secondPosition, int thirdPosition)
        {
            if (!IsValidMarker(grid[firstPosition]))
                return false;

            return (new[] {
                grid[firstPosition], grid[secondPosition],grid[thirdPosition]
            }.Distinct().Count() == 1);

        }

        private bool AreAnyRowAllTheSame()
        {
            return TopRowIsSame() || MiddleRowTheSame() || BottomRowTheSame();
        }

        private bool AreAnyColumnTheSame()
        {
            return IsLeftColumnTheSame() || IsRightColumnTheSame() || IsMiddleColumnTheSame();
        }

        private bool IsDiagonalLeftTheSame()
        {
            return IsTheSameMarker(2, 4, 8);
        }

        private bool IsDiagonalRightTheSame()
        {
            return IsTheSameMarker(0, 4, 8);
        }

        private bool IsRightColumnTheSame()
        {
            return IsTheSameMarker(2, 5, 8);
        }

        private bool IsMiddleColumnTheSame()
        {
            return IsTheSameMarker(1, 4, 7);
        }

        private bool IsLeftColumnTheSame()
        {
            return IsTheSameMarker(0, 3, 6);
        }

        private bool IsValidMarker(char marker)
        {
            return marker == 'X' || marker == 'O';
        }

        private bool BottomRowTheSame()
        {
            return IsTheSameMarker(6,7,8);
        }

        private bool MiddleRowTheSame()
        {
            return IsTheSameMarker(3,4,5);
        }

        private bool TopRowIsSame()
        {
            return IsTheSameMarker(0, 1, 2);
        }

        private bool AreThereAnyMovesLeft()
        {
            return !AnyMovesLeft();
        }

        private bool AnyMovesLeft()
        {
            IEnumerable<int> rangeOfMoves = Enumerable.Range(1, 9);

            return rangeOfMoves.Contains(CalculateRemainingMoves());
        }

        private int CalculateRemainingMoves()
        {
            var markers = grid.ToCharArray();

            return (grid.Length - markers.Count(IsValidMarker));
        }

        private static string EmptyGrid()
        {
            return "---------";
        }
    }
}