using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    public class ComputerPlayerTest
    {
        [Test]
        public void GetMoveOnAnEmptySpace()
        {
            var board = new Board("XOX-OOXXX");
            ComputerPlayer computer = new ComputerPlayer();

            var position = computer.GetMove(board);

            Assert.AreEqual(3,  position);
        }
    }
}
