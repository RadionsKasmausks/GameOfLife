using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace GameOfLife_1_iterations.Game
{
    internal class GameRules
    {
        public bool[,] UpdateBoard(int _width, int _height, bool[,] _board)
        {

            bool[,] newBoard = new bool[_width, _height];
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    int neighbors = CountNeighbors(x, y, _width, _height, _board);
                    if (_board[x, y])
                    {
                        if (neighbors < 2 || neighbors > 3)
                        {
                            newBoard[x, y] = false;
                        }
                        else
                        {
                            newBoard[x, y] = true;
                        }
                    }
                    else
                    {
                        if (neighbors == 3)
                        {
                            newBoard[x, y] = true;
                        }
                        else
                        {
                            newBoard[x, y] = false;
                        }
                    }
                }
            }
            return newBoard;
        }

        private int CountNeighbors(int x, int y, int _width, int _height, bool[,] _board)
        {

            int count = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    int neighborsX = x + i;
                    int neighborsY = y + j;

                    if (neighborsX >= 0 && neighborsX < _width && neighborsY >= 0 && neighborsY < _height)
                    {
                        if (_board[neighborsX, neighborsY])
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }
    }
}
