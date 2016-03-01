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

        private readonly string emptyBoard = "-------\n|1|2|3|\n-------\n|4|5|6|\n-------\n|7|8|9|\n-------\n";

        [Test]
        public void DisplaysEmptyTheBoard()
        {
            MemoryStream stream = new MemoryStream();
            gameConsole = new GameConsole(new StreamWriter(stream));

            gameConsole.DisplayBoard();

            StreamReader sr = new StreamReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual(emptyBoard, sr.ReadToEnd());
        }
    }
}
