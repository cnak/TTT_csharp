namespace TicTacToe
{
    public class GameOptions
    {
        private IGameConsole console;

        public GameOptions(IGameConsole console)
        {
            this.console = console;
        }

        public void Start()
        {
            console.DisplayGameOptions();
        }
    }
}
