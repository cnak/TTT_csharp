using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        private IGameConsole console;

        public Game(IGameConsole console)
        {
            this.console = console;
        }

        public void Start() {
            console.DisplayBoard();
        }

        public void AskForInputPosition()
        {
            console.Write("Please Enter Input");
        }
    }
}
