using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace TicTacToe.xTests
{
    public class Minimax
    {
        private string computerPlayer;
        private int bestMoveChoice;

        public int Move(Board board)
        {
            computerPlayer = board.CurrentPlayer();
            CalcMinimax(board, 0, computerPlayer);

            return bestMoveChoice;
        }

        private int CalcMinimax(Board board, int depth, string player)
        {
            if (board.IsGameOver())
            {
                return Score(board, depth, player);
            }

            var scores = new Dictionary<int, int>();

            FetchPossibleScore(board, player, scores, depth++);

            return MinMaxScore(player, scores);
        }

        private void FetchPossibleScore(Board board, string player, IDictionary scores, int depth)
        {
            var available_spaces = board.GetRemainingMoveSpaces();
            foreach (var space in available_spaces)
            {
                var possibleBoard = new Board(board);
                var intMove = (int)space;
                possibleBoard.MakeMove(intMove, player.ToCharArray()[0]);
                var calculatedMiniMax = CalcMinimax(possibleBoard, depth, OpponentPlayer(board, player));
                scores.Add(intMove, calculatedMiniMax);
            }
        }

        private int MinMaxScore(string player, IDictionary<int, int> scores)
        {
            if (player == computerPlayer)
                bestMoveChoice = scores.FirstOrDefault(x => x.Value == scores.Values.Min()).Key;
                return scores.FirstOrDefault(x => x.Value == scores.Values.Max()).Key;

                return scores.FirstOrDefault(x => x.Value == scores.Values.Max()).Key;
        }

        private string OpponentPlayer(Board board, string player)
        {
            return board.CurrentPlayer() == player ? board.OtherPlayer() : board.CurrentPlayer();
//            return player == "X" ? "O" : "X";
        }

        public int Score(Board board, int depth, string minimaxPlayer)
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