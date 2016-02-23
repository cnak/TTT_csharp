using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace TicTacToe {

    [TestFixture]
    class BoardTest
    {
        [Test]
        public void ReturnsFalseForGameOverOnANewGame() { 
            Board board = new Board();
            Assert.IsFalse(board.IsGameOver());
        }

        [Test]
        public void ReturnsTrueWhenAllMovesPlayed()
        {
            var boardPositions = new Dictionary<string, string>()
            {
                {"topLeft", "X"},
                {"topCenter", "O"},
                {"topRight", "X"},
                {"middle-left", "O"},
                {"middle-center ", "O"},
                {"middle-right ", "X"},
                {"bottom-left ", "O"},
                {"bottom-center ", "X"},
                {"bottom-right ", "O"}
            };
            
            Board board = new Board(boardPositions);
            Assert.IsTrue(board.IsGameOver());
        }
    }
}
