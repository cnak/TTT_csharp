using System.Runtime.CompilerServices;
using NUnit.Framework.Constraints;

namespace TicTacToe
{
    internal class ConsoleGameSetup
    {
        private IGameConsole console;

        public ConsoleGameSetup(IGameConsole console)
        {
            this.console = console;
        }

        public Game SetupGame()
        {
            switch (console.TakeGameOptionsChoice())
            {
                case 1:
                    return new Game(new Board(), console, new ConsoleHumanPlayer(console), new ComputerPlayer());
                case 2:
                    return new Game(new Board(), console, new ConsoleHumanPlayer(console), new ConsoleHumanPlayer());
                case 3:
                    return new Game(new Board(), console, new ComputerPlayer(), new ComputerPlayer());
            }
            return null;
        }
    }
}