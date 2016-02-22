using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class App
    {
        private GameConsole console;

        public App(GameConsole console)
        {
            this.console = console;
        }

        public void Start() {
            console.DisplayBoard();
        }
    }
}
