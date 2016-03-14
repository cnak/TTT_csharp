namespace TicTacToe
{
    public class ConsoleHumanPlayer : IPlayer
    {
        private IConsoleGame console;

        public ConsoleHumanPlayer()
        {
        }

        public ConsoleHumanPlayer(IConsoleGame console)
        {
            this.console = console;
        }

        public virtual int GetMove(Board board)
        {
            return GetMappedMoveToBoard();
        }

        private int GetMappedMoveToBoard()
        {
            return console.TakePlayerChoice() - 1;
        }
    }
}