namespace TicTacToe {
    public interface IGameConsole
    {
        void DisplayBoard(Board board);
        void AskForInputPosition();
        int TakePlayerMove();
    }
}