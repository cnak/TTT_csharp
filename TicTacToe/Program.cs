using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.xTests;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleGame consoleGame = new ConsoleGame(Console.In, Console.Out);
//            Game app = new Game(new Board(), consoleGame, new ComputerPlayer(), new ComputerPlayer());
AppGame app = new AppGame(consoleGame, new ConsoleGameSetup(consoleGame));
            app.Start();
        }
    }
}
