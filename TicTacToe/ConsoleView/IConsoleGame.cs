namespace TicTacToe {
    public interface IConsoleGame
    {
        void DisplayBoard(Board board);
        void AskForInputPosition();
        int TakePlayerChoice();
        void DisplayGameDrawnResult();
        void DisplayGameWonResult(string playerName);
        void DisplayGameOptions();
        int TakeGameOptionsChoice();
    }
}