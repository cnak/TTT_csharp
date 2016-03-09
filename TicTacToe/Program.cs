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

//            Game app = new Game(gameConsole);
  HumanPlayer human = new HumanPlayer(); 
  ComputerPlayer computer = new ComputerPlayer(); 
            Game app = new Game(new Board(), gameConsole, human, computer);
            app.Start();
        }
    }
}
