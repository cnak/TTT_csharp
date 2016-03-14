using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleGame consoleGame = new ConsoleGame(Console.In, Console.Out);

            //            Game app = new Game(ConsoleGame);
//            ConsoleHumanPlayer human = new ConsoleHumanPlayer();
//            ComputerPlayer computer = new ComputerPlayer();
//            Game app = new Game(new Board(), ConsoleGame, human, computer);
            Game app = new Game(new Board(), consoleGame, new ComputerPlayer(), new ComputerPlayer());
            app.Start();
        }
    }
}
