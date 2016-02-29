using System;
using System.Collections.Generic;

namespace TicTacToe {
    internal class SpyGameConsole : IGameConsole
    {
        private readonly string grid;
        public bool wasAskInputCalled = false;

        private Queue<string> data = new Queue<string>();

        public SpyGameConsole()
        { 
           grid = "-------\n|1|2|3|\n-------\n|4|5|6|\n-------\n|7|8|9|\n-------\n";
        }

        public void DisplayBoard()
        {
            Write(grid);
        }

        public void Write(string data)
        {
            this.data.Enqueue(data);
        }

        public void AskForInputPosition()
        {
            wasAskInputCalled = true;
            Write("Please Play Move");
        }

        public string LastPrintedMessage()
        {
            return data.Dequeue();
        }
    }
}