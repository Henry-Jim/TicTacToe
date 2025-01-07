using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class UI
    {
        /// <summary>
        /// Displays the board. '.' represents empty cells. 'X' or 'O' means the cells is occupied.
        /// </summary>
        /// <param name="board"></param>
        public static void DisplayBoard(char[,] board)
        {
            Console.Clear();
            int gridSize = board.GetLength(0);

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Console.Write(board[i, j] == Constants.EMPTY_CELL ? '.' : board[i, j]); // If the cell is empty display '.' to indicate availability, otherwise display either X or O.
                    if (j < gridSize - 1)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
                if (i < gridSize - 1)
                {
                    Console.WriteLine(new string('-', gridSize * Constants.CELL_WIDTH_WITH_SEPARATOR - Constants.FINAL_COLUMN_ADJUSTMENT));
                }
            }
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string ReadInput()
        {
            return Console.ReadLine();
        }

        public static int GetGridSize(int defaultSize)
        {
            DisplayMessage($"Enter grid size (e.g {defaultSize} for {defaultSize} x {defaultSize}): ");
            while (true)
            {
                if (int.TryParse(ReadInput(), out int gridSize) && gridSize > 0)
                {
                    return gridSize;
                }

                DisplayMessage("Invalid input. Please enter a positive number.");
            }
        }

        public static (int row, int col) GetPlayerMove(int gridSize)
        {
            DisplayMessage("Your turn. Enter row and columm (e.g. 1 2 for (1, 2)):");

            while (true)
            {
                string input = ReadInput();
                if (Logic.ValidateUserInput(input, gridSize, out int row, out int col))
                {
                    return (row, col);
                }
                DisplayMessage("Invalid input. Please enter a valid row and column.");
            }
        }
    }
}
