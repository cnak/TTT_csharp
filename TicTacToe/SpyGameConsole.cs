using System;
using System.Collections.Generic;

namespace TicTacToe {
    internal class SpyGameConsole : IGameConsole
    {
        private readonly string grid;
        public bool wasAskInputCalled = false;

        private Queue<string> data = new Queue<string>();
        public bool wasDisplayedBoardCalled = false;
        public bool wasTakePlayerMoveCalled;
        public int numberOftTimesDisplayedCalled;

        public SpyGameConsole()
        { 
           grid = "-------\n|1|2|3|\n-------\n|4|5|6|\n-------\n|7|8|9|\n-------\n";
        }

        public void DisplayBoard(Board board)
        {
            wasDisplayedBoardCalled = true;
            numberOftTimesDisplayedCalled += 1;
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

        public int TakePlayerMove()
        {
            wasTakePlayerMoveCalled = true;
            return 0;
        }

        public void DisplayGameDrawnResult()
        {
            throw new NotImplementedException();
        }

        public void DisplayGameWonResult(string playerName)
        {
            throw new NotImplementedException();
        }

        public string LastPrintedMessage()
        {
            return data.Dequeue();
        }
    }
}