using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    public class AppTest
    {
        private FakeGameConsole console;
        private App app;

        public AppTest() {
            console = new FakeGameConsole();
            app = new App(console);
        }

        [Test]
        public void ConsoleDisplaysOnStart() { 
             string empty_grid = "-------\n|1|2|3|\n-------\n|4|5|6|\n-------\n|7|8|9|\n-------\n";
            app.Start();
            Assert.AreEqual(empty_grid, console.LastPrintedMessage());
        }
    }
}
