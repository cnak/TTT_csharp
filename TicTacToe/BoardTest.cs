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
        public void InformsTheGameIsNotOver()
        {
            Board board = new Board();

            Assert.IsFalse(board.IsGameOver());
        }

        [Test]
        public void InformsTheGameIsOverWithNoMoreMoves()
        {
            Board board = new Board("XOXOXOXOX");

            Assert.IsTrue(board.IsGameOver());
        }

        [Test]
        public void InformsGameIsNotOverWithMovesLeft()
        {
            Board board = new Board("XOXO");

            Assert.IsFalse(board.IsGameOver());
        }

        [Test]
        public void InformsGameHasBeenWon()
        {
            Board board = new Board("XOX" +
                                    "OXO" +
                                    "XOX");

            Assert.IsTrue((board.IsGameWon()));
        }
   }
}
