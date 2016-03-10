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
        private IGameConsole gameConsole;

        [Test]
        public void DisplayGameOptions()
        {
            var boardOptions = "\n-------\n" +
                               "---Game Options---" +
                               "1. Human Vs Computer" +
                               "2. Human vs Human" +
                               "3. Computer vs Computer" +
                               "\n";

            MemoryStream stream = new MemoryStream();
            gameConsole = new GameConsole(null, new StreamWriter(stream));

            gameConsole.DisplayGameOptions();

            StreamReader sr = new StreamReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual(boardOptions, sr.ReadToEnd());
        }

        [Test]
        public void DisplaysEmptyTheBoard()
        {
            var emptyBoard = "\n-------\n|-|-|-|\n-------\n|-|-|-|\n-------\n|-|-|-|\n-------\n";
            MemoryStream stream = new MemoryStream();
            gameConsole = new GameConsole(null, new StreamWriter(stream));

            gameConsole.DisplayBoard(new Board());

            StreamReader sr = new StreamReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual(emptyBoard, sr.ReadToEnd());
        }

        [Test]
        public void DisplaysBoardWithOneMove()
        {
            MemoryStream stream = new MemoryStream();
            gameConsole = new GameConsole(null, new StreamWriter(stream));
            var playedBoard = "\n-------\n|-|-|-|\n-------\n|X|-|-|\n-------\n|-|-|-|\n-------\n";

            gameConsole.DisplayBoard(new Board("---X-----"));

            StreamReader sr = new StreamReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual(playedBoard, sr.ReadToEnd());
        }

        [Test]
        public void AskForInputPosition()
        {
            MemoryStream stream = new MemoryStream();
            gameConsole = new GameConsole(null, new StreamWriter(stream));

            gameConsole.AskForInputPosition();

            StreamReader sr = new StreamReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual("\nPlease Play a Move\n", sr.ReadToEnd());
        }

        [Test]
        public void TakePlayerMove()
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("1"));

            gameConsole = new GameConsole(new StreamReader(stream), null);

            Assert.AreEqual(1, gameConsole.TakePlayerChoice());
        }

        [Test]
        public void DisplayGameWonResult()
        {
            MemoryStream stream = new MemoryStream();
            gameConsole = new GameConsole(null, new StreamWriter(stream));

            gameConsole.DisplayGameWonResult("X");

            StreamReader sr = new StreamReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual("\nPlayer X won\n", sr.ReadToEnd());
        }

        [Test]
        public void DisplayGameDrawnResult()
        {
            MemoryStream stream = new MemoryStream();
            gameConsole = new GameConsole(null, new StreamWriter(stream));

            gameConsole.DisplayGameDrawnResult();

            StreamReader sr = new StreamReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual("\nIt was a Draw\n", sr.ReadToEnd());
        }
    }
}
