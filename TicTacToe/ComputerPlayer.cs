namespace TicTacToe
{
    public class ComputerPlayer : IPlayer
    {
        public int GetMove(Board board)
        {
            var bestMove = -1;
            var isFoundMove = false;

            for (var index = 0; index < 9 && !isFoundMove; index++)
            {
                bestMove = FindMoveOnEmptyPosition(board, index, bestMove, ref isFoundMove);
            }
            return bestMove;
        }

        private int FindMoveOnEmptyPosition(Board board, int index, int bestMove, ref bool isFoundMove)
        {
            if (!board.IsEmptyPosition(index)) return bestMove;
            bestMove = index;
            isFoundMove = true;
            return bestMove;
        }
    }
}