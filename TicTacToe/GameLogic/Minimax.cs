using System.Runtime.InteropServices;

namespace TicTacToe.xTests
{
    public class Minimax
    {
        public static double Move(Board board)
        {
            return 1;
        }

        public static int Score(Board board, int depth, string minimaxPlayer)
        {
            if (board.IsGameDrawn())
                return 0;
            if (AmITheWinner(board, minimaxPlayer))
                return 10;

            return -10;
        }

        private static bool AmITheWinner(Board board, string player)
        {
            return board.GetWinner() == player;
        }
    }
}