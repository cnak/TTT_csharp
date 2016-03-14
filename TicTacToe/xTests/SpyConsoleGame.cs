using System;
using System.Collections.Generic;

namespace TicTacToe {
    internal class SpyConsoleGame : IConsoleGame
    {
        private readonly string grid;
        private int playerMove = -1;
        public bool wasAskInputCalled = false;

        private Queue<string> data = new Queue<string>();

        public bool wasWinningResultDisplayed;
        public bool wasDisplayedBoardCalled = false;
        public bool wasTakePlayerMoveCalled;
        public int numberOftTimesDisplayedCalled;
        public bool wasDrawnResultDisplayed;
        public bool wasDisplayGameOptionsCalled;
        public bool wasTakeGameOptionsChoiceCalled;
        private int gameOptionsChoice;

        public SpyConsoleGame()
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

        public int TakePlayerChoice()
        {
            wasTakePlayerMoveCalled = true;
            return playerMove;
        }

        public void DisplayGameDrawnResult()
        {
            wasDrawnResultDisplayed = true;
        }

        public void DisplayGameWonResult(string playerName)
        {
            wasWinningResultDisplayed = true;
        }

        public void DisplayGameOptions()
        {
            wasDisplayGameOptionsCalled = true;
        }

        public string LastPrintedMessage()
        {
            return data.Dequeue();
        }

        public void SetPlayerMove(int playerMove)
        {
            this.playerMove = playerMove;
        }

        public int TakeGameOptionsChoice()
        {
            wasTakeGameOptionsChoiceCalled = true;
            return gameOptionsChoice;
        }

        public void setGameOptionsChoice(int choice)
        {
            this.gameOptionsChoice = choice;
        }
    }
}