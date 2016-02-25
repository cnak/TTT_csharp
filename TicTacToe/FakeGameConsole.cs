using System.Collections.Generic;

namespace TicTacToe {
    internal class FakeGameConsole : IGameConsole
    {
        private readonly string grid;

        private Queue<string> data = new Queue<string>();

        public FakeGameConsole()
        { 
           grid = "-------\n|1|2|3|\n-------\n|4|5|6|\n-------\n|7|8|9|\n-------\n";
        }

        public void DisplayBoard()
        {
            write(grid);
        }

        public void Write(string data)
        {
            this.data.Enqueue(data);
        }

        public string LastPrintedMessage()
        {
            return data.Dequeue();
        }
    }
}