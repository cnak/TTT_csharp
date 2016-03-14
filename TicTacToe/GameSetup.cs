using System.Runtime.CompilerServices;
using NUnit.Framework.Constraints;

namespace TicTacToe
{
    internal class GameSetup
    {
        private IGameConsole console;

        public GameSetup(IGameConsole console)
        {
            this.console = console;
        }

        public Game SetupGame()
        {
            switch (console.TakeGameOptionsChoice())
            {
                case 1:
                    return new Game(new Board(), console, new HumanPlayer(console), new ComputerPlayer());
                case 2:
                    return new Game(new Board(), console, new HumanPlayer(console), new HumanPlayer());
                case 3:
                    return new Game(new Board(), console, new ComputerPlayer(), new ComputerPlayer());
            }
            return null;
        }
    }
}