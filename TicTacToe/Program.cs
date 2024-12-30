namespace TicTacToe
{
    internal class Program
    {
        const int DEFAULT_GRIDSIZE = 3;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!");

            int gridSize = DEFAULT_GRIDSIZE;
            Console.WriteLine("Enter a grid size (e.g. 3 for 3x3)");
            while (!int.TryParse(Console.ReadLine(), out gridSize) || gridSize <= 0)
            {
                Console.WriteLine("Invalid Output. Please enter a positive number");
            }

            char[,] board = new char[gridSize, gridSize];
            Logic.InitializeBoard(board);

            bool gameOngoing = true;
            bool userTurn = true;

            while(gameOngoing)
            {
                UI.DisplayBoard(board);

                if (userTurn)
                {
                    Console.WriteLine("Your turn. Enter the row and column (e.g. 1 2 for (1, 2)");
                    int row, col;

                    while(true)
                    {
                        string input = Console.ReadLine();
                        if (Logic.TryParseInput(input, gridSize, out row, out col) && Logic.isCellEmpty(board, row, col))
                        {
                            board[row, col] = 'X';
                            break;
                        }
                        Console.WriteLine("Invalid input or cell not available. Please try again");
                    }
                }
                else
                {
                    Console.WriteLine("AI's turn...");
                    Logic.AIMove(board);
                }

                if (Logic.CheckWin(board, userTurn ?  'X' : 'O'))
                {
                    UI.DisplayBoard(board);
                    Console.WriteLine(userTurn ? "You win!" : "AI wins!");
                    gameOngoing = false;
                }
                else if (Logic.CheckTie(board))
                {
                    UI.DisplayBoard(board);
                    Console.WriteLine("It's a tie!");
                    gameOngoing = false;
                }

                userTurn = !userTurn; // Switch turns
            }

            Console.WriteLine("Game Over!");
        }
    }
}
