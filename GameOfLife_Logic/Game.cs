using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GameOfLife_Logic
{
    public class Game
    {
        private bool[,] _board;
        private int _width;
        private int _height;
        private int _aliveCount;

        public bool[,] Board { get; set; }
        public int Width => _width;
        public int Height => _height;
        public int Iterations { get; set; }

        public int AliveCount
        {
            get { return _aliveCount; }
            set { _aliveCount = value; }
        }

        public Game(int width, int height, bool[,] board)
        {
            _width = width;
            _height = height;
            _board = board;

            Board = _board;

            Iterations = 0;
        }

        public static bool[,] Initialize(int width, int height)
        {
            bool[,] board = new bool[width, height];

            Random random = new Random();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    board[x, y] = random.Next(2) == 1;
                }
            }

            return board;
        }

        public static int CountAliveCells(bool[,] board)
        {
            int width = board.GetLength(0);
            int height = board.GetLength(1);
            int aliveCount = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (board[x, y])
                    {
                        aliveCount++;
                    }
                }
            }

            return aliveCount;
        }
    }
}
