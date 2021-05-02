using System;

namespace NQueensBacktracking
{
    public class Program
    {
        private readonly int N = 4;
        static void Main()
        {
            int[,] board = {{ 0, 0, 0, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 }};

            Program program = new Program();
            program.SolveNQueens(board);
        }


        public void PrintBoard(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine("");
            }
        }
        public bool SolveNQueens(int[,] board)
        {
            SolveQueens(board, 0);
            PrintBoard(board);
            return true;
        }

        private bool SolveQueens(int[,] board, int column)
        {
            if (column == N)
            {
                return true;
            }

            for (int i = 0; i < N; i++)
            {
                if (board[i, column] == 0)
                {
                    board[i, column] = 1;
                    if (IsValidConfig(board, column, i))
                    {
                        if (SolveQueens(board, column + 1))
                            return true;
                    }
                    board[i, column] = 0;
                }
            }

            return false;
        }

        private bool IsValidConfig(int[,] board, int column, int row)
        {
            //check column for other queens
            for (int i = 0; i < N; i++)
            {
                if (board[i, column] == 1 && i != row)
                {
                    return false;
                }
            }
            //check row for other queens
            for (int i = 0; i < N; i++)
            {
                if (board[row, i] == 1 && i != column)
                {
                    return false;
                }
            }
            //check diagonal (up and to the left)
            for (int i = row, j = column; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1 && (i != row && j != column))
                {
                    return false;
                }
            }
            //check diagonal (down and to the left)
            for (int i = row, j = column; i < N && j >= 0; i++, j--)
            {
                if (board[i, j] == 1 && (i != row && j != column))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
