namespace TicTacToe.xTests
{
    internal class AppGame
    {
        private readonly IConsoleGame console;
        private readonly ConsoleGameSetup setup;
        private Game game;

        public AppGame(IConsoleGame consoleGame, ConsoleGameSetup gameSetup)
        {
            console = consoleGame;
            setup = gameSetup;
        }

        public void Start()
        {
            DisplayGameOptions();
            SetupGame();
            game.Start();
        }

        public Game GetGame()
        {
            return game;
        }

        private void SetupGame()
        {
            game = setup.SetupGame();
        }

        private void DisplayGameOptions()
        {
            console.DisplayGameOptions();
        }
    }
}