using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    public class GameConsoleTest
    {
        private GameConsole gameConsole;

        [Test]
        public void DisplaysEmptyTheBoard()
        {
            var emptyBoard = "-------\n|-|-|-|\n-------\n|-|-|-|\n-------\n|-|-|-|\n-------\n";
            MemoryStream stream = new MemoryStream();
            gameConsole = new GameConsole(new StreamWriter(stream));

            gameConsole.DisplayBoard();

            StreamReader sr = new StreamReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual(emptyBoard, sr.ReadToEnd());
        }

        [Test]
        public void DisplaysBoardWithOneMove()
        {
            MemoryStream stream = new MemoryStream();
            gameConsole = new GameConsole(new StreamWriter(stream));
            var playedBoard = "\n-------\n|-|-|-|\n-------\n|X|-|-|\n-------\n|-|-|-|\n-------\n";

            gameConsole.DisplayBoard(new Board("---X-----"));

            StreamReader sr = new StreamReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual(playedBoard, sr.ReadToEnd());
        }
    }
}
