using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TicTacToe
{
    class GameOptionsTest
    {
        [Test]
        public void DisplayGameOptions()
        {
        }

        [Test]
        public void DisplayGameOptionsOnStart()
        {
            var console = new SpyGameConsole();
            GameOptions options = new GameOptions(console);

            options.Start();
            
            Assert.IsTrue(console.wasDisplayGameOptionsCalled);
        }

        [Test]
        public void AskForGameOptionsChoiceOnStart()
        {
            var console = new SpyGameConsole();
            var options = new GameOptions(console);

            options.Start();
            
            Assert.IsTrue(console.wasTakeGameOptionsChoiceCalled);
        }
    }
}
