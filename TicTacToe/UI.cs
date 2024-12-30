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
                    Console.Write(board[i, j] == '\0' ? '.' : board[i, j]); // If the cell is empty display '.' to indicate availability, otherwise display either X or O.
                    if (j < gridSize - 1)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
                if (i < gridSize - 1)
                {
                    Console.WriteLine(new string('-', gridSize * 4 - 3));
                }
            }
        }
    }
}
