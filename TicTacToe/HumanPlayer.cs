namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        private IGameConsole console;

        public HumanPlayer()
        {
        }

        public HumanPlayer(IGameConsole console)
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