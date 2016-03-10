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
    }
}
