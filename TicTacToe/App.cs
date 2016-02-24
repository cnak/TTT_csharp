using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class App
    {
        private IGameConsole console;

        public App(IGameConsole console)
        {
            this.console = console;
        }

        public void Start() {
            console.DisplayBoard();
        }
    }
}
