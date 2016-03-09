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
            GameConsole gameConsole = new GameConsole(Console.In, Console.Out);

            Game app = new Game(gameConsole);
            app.Start();
        }
    }
}
