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
            var consoleGame = new ConsoleGame(Console.In, Console.Out);
            var app = new AppGame(consoleGame, new ConsoleGameSetup(consoleGame));
            app.Start();
        }
    }
}
