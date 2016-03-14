namespace TicTacToe
{
    public class ConsoleHumanPlayer : IPlayer
    {
        private IGameConsole console;

        public ConsoleHumanPlayer()
        {
        }

        public ConsoleHumanPlayer(IGameConsole console)
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