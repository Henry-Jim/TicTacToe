namespace TicTacToe
{
    internal class Program
    {
        const int DEFAULT_GRIDSIZE = 3;
        static void Main(string[] args)
        {
            UI.DisplayMessage("Welcome to Tic-Tac-Toe!");

            int gridSize = UI.GetGridSize(Constants.DEFAULT_GRIDSIZE);

            char[,] board = new char[gridSize, gridSize];
            Logic.InitializeBoard(board);

            bool gameOngoing = true;
            bool userTurn = true;

            while(gameOngoing)
            {
                UI.DisplayBoard(board);

                if (userTurn)
                {
                    var (row, col) = UI.GetPlayerMove(gridSize);

                    while(!Logic.isCellEmpty(board, row, col))
                    {
                        UI.DisplayMessage("Cell is not available. Please choose a different cell.");
                        (row, col) = UI.GetPlayerMove(gridSize);
                    }
                    board[row, col] = Constants.SYMBOL_PLAYER; // changed to const
                }
                else
                {
                    UI.DisplayMessage("AI's turn...");
                    Logic.HandleAIMove(board);
                }

                if (Logic.CheckWin(board, userTurn ?  Constants.SYMBOL_PLAYER : Constants.SYMBOL_AI))
                {
                    UI.DisplayBoard(board);
                    UI.DisplayMessage(userTurn ? "You win!" : "AI wins!");
                    gameOngoing = false;
                }
                else if (Logic.CheckTie(board))
                {
                    UI.DisplayBoard(board);
                    UI.DisplayMessage("It's a tie!");
                    gameOngoing = false;
                }

                userTurn = !userTurn; // Switch turns
            }

            UI.DisplayMessage("Game Over!");
        }
    }
}
