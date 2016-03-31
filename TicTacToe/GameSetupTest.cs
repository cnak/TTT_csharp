using System;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TicTacToe
{
    internal class GameSetupTest
    {
        [Test]
        public void CreateAHumanVsComputerGame()
        {
            var console = new SpyGameConsole();
            var gameSetup = new GameSetup(console);

            console.setGameOptionsChoice(1);
            var game = gameSetup.SetupGame();
            var IsHumanVsComputer = (game.CurrentPlayer() is HumanPlayer) && (game.OtherPlayer() is ComputerPlayer);

            Assert.IsTrue(IsHumanVsComputer);
        }

        [Test]
        public void CreateAHumanVsHumanGame()
        {
            var console = new SpyGameConsole();

            console.setGameOptionsChoice(2);
            var gameSetup = new GameSetup(console);

            var game = gameSetup.SetupGame();
            var IsHumanVsHuman = (game.CurrentPlayer() is HumanPlayer) && (game.OtherPlayer() is HumanPlayer);

            Assert.IsTrue(IsHumanVsHuman);
        }

        [Test]
        public void CreateAComputerVsComputerGame()
        {
            var console = new SpyGameConsole();

            console.setGameOptionsChoice(3);
            var gameSetup = new GameSetup(console);

            var game = gameSetup.SetupGame();
            var IsComputerVsComputer = (game.CurrentPlayer() is ComputerPlayer) && (game.OtherPlayer() is ComputerPlayer);

            Assert.IsTrue(IsComputerVsComputer);
        }
    }
}