namespace TicTacToe {
    public interface IGameConsole
    {
        void DisplayBoard(Board board);
        void AskForInputPosition();
        int TakePlayerChoice();
        void DisplayGameDrawnResult();
        void DisplayGameWonResult(string playerName);
        void DisplayGameOptions();
        void TakeGameOptionsChoice();
    }
}