using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameConsole
    {
        private readonly TextWriter writer;

        private string board = "-------\n|1|2|3|\n-------\n|4|5|6|\n-------\n|7|8|9|\n-------\n";

        public GameConsole(TextWriter writer)
        {
            this.writer = writer;
        }

        public void DisplayBoard()
        {
            writer.Write(board);
            writer.Flush();
        }
    }
}
