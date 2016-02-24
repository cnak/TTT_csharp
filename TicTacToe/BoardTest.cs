using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    class BoardTest
    {
        [Test]
        public void informsTheGameIsNotOver()
        {
            Board board = new Board();

            Assert.IsFalse(board.IsGameOver());
        }

        [Test]
        public void informsTheGameIsOverWithNoMoreMoves()
        {
            Board board = new Board("XOXOXOXOX");

            Assert.IsTrue(board.IsGameOver());
        }

        [Test]
        public void informsGameIsNotOverWithMovesLeft()
        {
            Board board = new Board("XOXO");

            Assert.IsFalse(board.IsGameOver());
        }
   }
}
