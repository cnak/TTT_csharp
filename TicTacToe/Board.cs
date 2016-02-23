using System;
using System.Collections.Generic;

namespace TicTacToe {
    class Board {
        private readonly Dictionary<string, string> boardPositions;

        public Board() {
            this.boardPositions = new Dictionary<string, string>();
        }

        public Board(Dictionary<string, string> boardPositions) {
            this.boardPositions = boardPositions;
        }

        public bool IsGameOver()
        {
            if (boardPositions.Count == 9)
            {
                return true;
            }
            return false;
        }

    }
}
