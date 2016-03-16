using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class ConsoleGame : IConsoleGame
    {
        private readonly TextWriter writer;
        private readonly TextReader reader;

        public ConsoleGame(TextReader reader, TextWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void DisplayBoard()
        {
            var emptyBoard = NewLine() + "|-|-|-|" + NewLine() + "|-|-|-|" + NewLine() + "|-|-|-|" + NewLine();
            Write(emptyBoard);
        }

        public void DisplayBoard(Board board)
        {
            Write(FormatBoard(board));
        }

        public void AskForInputPosition()
        {
            Write("\nPlease Play a Move\n");
        }

        public int TakePlayerChoice()
        {
             return int.Parse(reader.ReadLine());
        }

        public void DisplayGameDrawnResult()
        {
            Write("\nIt was a Draw\n");
        }

        public void DisplayGameWonResult(string playerName)
        {
            Write("\nPlayer " + playerName + " won\n");
        }

        public void DisplayGameOptions()
        {
            var boardOptions = NewLine() +
                               "---Game Options---" +
                               "1. Human Vs Computer" +
                               "2. Human vs Human" +
                               "3. Computer vs Computer" +
                               "\n";
            
            Write(boardOptions);
        }

        public int TakeGameOptionsChoice()
        {
            return TakePlayerChoice();
        }

        private string FormatBoard(Board board)
        {
            return NewLine()
                       + "|" + board.PositionAt(0) +
                         "|" + board.PositionAt(1) + "|" +
                               board.PositionAt(2) + "|" + NewLine() +
                         "|" + board.PositionAt(3) +
                         "|" + board.PositionAt(4) + "|" +
                               board.PositionAt(5) + "|" + NewLine() +
                         "|" + board.PositionAt(6) +
                         "|" + board.PositionAt(7) +
                         "|" + board.PositionAt(8) + "|" + NewLine();
        }

        private void Write(object obj)
        {
            writer.Write(obj);
            writer.Flush();
        }

        private string NewLine()
        {
            return "\n-------\n";
        }
    }
}
