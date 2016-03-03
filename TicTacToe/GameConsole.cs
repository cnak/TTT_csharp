using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameConsole : IGameConsole
    {
        private readonly TextWriter writer;
        private readonly TextReader reader;

        public GameConsole(TextReader reader, TextWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void DisplayBoard()
        {
            var emptyBoard = "-------\n|-|-|-|\n-------\n|-|-|-|\n-------\n|-|-|-|\n-------\n";
            writer.Write(emptyBoard);
            writer.Flush();
        }

        public void DisplayBoard(Board board)
        {
            writer.Write(FormatBoard(board));
            writer.Flush();
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

        public void AskForInputPosition()
        {
            writer.Write("\nPlease Play a Move\n");
            writer.Flush();
        }

        public int TakePlayerMove()
        {
            var value = int.Parse(reader.ReadLine());

            if (value < 1)
                throw new IndexOutOfRangeException();

            return value;
        }

        private string NewLine()
        {
            return "\n-------\n";
        }

        public void DisplayGameDrawnResult()
        {
            writer.Write("\nIt was a Draw\n");
            writer.Flush();
        }

        public void DisplayGameWonResult(string playerName)
        {
            writer.Write("\nPlayer " + playerName + " won\n");
            writer.Flush();
        }
    }
}
