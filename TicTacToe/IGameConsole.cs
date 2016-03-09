namespace TicTacToe {
    public interface IGameConsole
    {
        void DisplayBoard(Board board);
        void AskForInputPosition();
        int TakePlayerMove();
        void DisplayGameDrawnResult();
        void DisplayGameWonResult(string playerName);
    }
}