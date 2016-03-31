using NUnit.Framework;

namespace TicTacToe.xTests
{
    [TestFixture]
    public class AppGameTest
    {
        [Test]
        public void DisplayGameOptionsOnStart()
        {
            var console = new SpyConsoleGame();
            var fakeGameSetup = new FakeConsoleGameSetup(console);
            var app = new AppGame(console, fakeGameSetup);

            app.Start();

            Assert.IsTrue(console.wasDisplayGameOptionsCalled);
        }

        [Test]
        public void SetupAConsoleGame()
        {
            var console = new SpyConsoleGame();
            var fakeGameSetup = new FakeConsoleGameSetup(console);
            var app = new AppGame(console, fakeGameSetup);

            console.setGameOptionsChoice(1);
            app.Start();

            Assert.IsNotNull(app.GetGame());
        }

        [Test]
        public void StartupGame()
        {
            var console = new SpyConsoleGame();
            var fakeGameSetup = new FakeConsoleGameSetup(console);
            var app = new AppGame(console, fakeGameSetup);

            console.setGameOptionsChoice(1);
            app.Start();

            Assert.IsTrue(fakeGameSetup.GetGame().wasGameStarted);
        }

        class FakeConsoleGameSetup : ConsoleGameSetup
        {
            private SpyConsoleGame console;
            public FakeGame game;

            public FakeConsoleGameSetup(SpyConsoleGame console) : base(console)
            {
                this.console = console;
            }

            public override Game SetupGame()
            {
                game = new FakeGame(console);
                return game;
            }

            public FakeGame GetGame()
            {
                return game;
            }
        }

        class FakeGame: Game
        {

            public bool wasGameStarted;

            public FakeGame(IConsoleGame console) : base(console)
            {
            }

            public override void Start()
            {
                wasGameStarted = true;
            }
        }
    }
}