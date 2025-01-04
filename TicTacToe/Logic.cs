using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Logic
    {
        public const char SYMBOL_PLAYER = 'X';
        public const char SYMBOL_AI = 'O';

        /// <summary>
        /// Initializes board with empty cells
        /// </summary>
        /// <param name="board"></param>
        public static void InitializeBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '\0'; // Empty cell
                }
            }
        }

        /// <summary>
        /// Validates user input and parses user's input (row and col) into the grid by splitting into two integers
        /// </summary>
        /// <param name="input"></param>
        /// <param name="gridSize"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>true if input is valid</returns>
        public static bool ValidateUserInput(string input, int gridSize, out int row, out int col)
        {
            row = col = -1; // Default values which would be replaced by valid inputs
            string[] parts = input.Split(' '); // Splits input (e.g. 1 2) into two parts

            // Returns true if the length is 2
            // Returns true if converts into integer 
            // Ensures row and col >= 0
            // Ensures row and col < gridSize
            return parts.Length == 2 && int.TryParse(parts[0], out row) && row >= 0 && row < gridSize && int.TryParse(parts[1], out col) && col >= 0 && col < gridSize;
        }

        /// <summary>
        /// Check if the cell is empty
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>true if cell is empty</returns>
        public static bool isCellEmpty(char[,] board, int row, int col)
        {
            return board[row, col] == '\0';
        }

        /// <summary>
        /// Find all the empty cells and select one randomly
        /// </summary>
        /// <param name="board"></param>
        public static void HandleAIMove(char[,] board)
        {
            Random random = new Random();
            List<(int row, int col)> emptyCells = new List<(int, int)>();

            // Add all the empty cells to the list for selection
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '\0')
                    {
                        emptyCells.Add((i, j));
                    }
                }
            }

            // Choose a random cell if it exists
            if (emptyCells.Count > 0)
            {
                var randomCell = emptyCells[random.Next(emptyCells.Count)];
                board[randomCell.row, randomCell.col] = SYMBOL_AI;
            }
        }

        /// <summary>
        /// Check if a player ('X' or 'O') has won 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="player"></param>
        /// <returns>true if a player has won horizontally, verticall or diagonally</returns>
        public static bool CheckWin(char[,] board, char player)
        {
            int gridSize = board.GetLength(0);

            // check horizontally and vertically
            for (int i = 0; i < gridSize; i++)
            {
                bool rowWin = true;
                bool colWin = true;
                
                for (int j = 0; j < gridSize; j++)
                {
                    if (board[i, j] != player) rowWin = false;
                    if (board[j, i] != player) colWin = false;
                }
                if (rowWin || colWin) return true;
            }

            // Check diagonally
            bool diagonalWin = true;
            bool antiDiagonalWin = true;

            for (int i = 0; i < gridSize; i++)
            {
                if (board[i, i] != player) diagonalWin = false;
                if (board[i,gridSize - i - 1] != player) antiDiagonalWin = false;
            }

            return diagonalWin || antiDiagonalWin;

        }

        /// <summary>
        /// Detects where the game is a tie
        /// </summary>
        /// <param name="board"></param>
        /// <returns>true if no empty cells are found</returns>
        public static bool CheckTie(char[,] board)
        {
            foreach (var cell in board)
            {
                if (cell == '\0') return false;
            }
            return true;
        }
    }
}
