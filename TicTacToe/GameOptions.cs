namespace TicTacToe
{
    public class GameOptions
    {
        private IGameConsole console;
        private Game game;
        private GameType gameType;

        public enum GameType { HumanVsHuman,
            HumanVsComputer
        };

        public GameOptions(IGameConsole console)
        {
            this.console = console;
        }

        public void Start()
        {
            console.DisplayGameOptions();
            var choice = console.TakeGameOptionsChoice();
            if (choice == 1)
            {
//                game = new Game(new Board(), console, new HumanPlayer(), new ComputerPlayer());
                gameType = GameType.HumanVsHuman;
            }

            if (choice == 2)
            {
//                game = new Game(new Board(), console, new HumanPlayer(), new ComputerPlayer());
                gameType = GameType.HumanVsComputer;
            }
        }

        public GameType GetGameType()
        {
            return gameType;
        }
    }
}
