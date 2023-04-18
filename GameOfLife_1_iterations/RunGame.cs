namespace GameOfLife_1_iteration.run
{
    public class RunGame
    {
        private int _width;
        private int _height;
        private bool[,] _board;

        public RunGame(int _width, int _height, bool[,] _board)
        {
            this._width = _width;
            this._height = _height;
            this._board = _board;
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();

                for (int y = 0; y < _height; y++)
                {
                    for (int x = 0; x < _width; x++)
                    {
                        Console.Write(_board[x, y] ? "+" : " ");
                    }
                    Console.WriteLine();
                }

                bool[,] newBoard = new bool[_width, _height];

                for (int x = 0; x < _width; x++)
                {
                    for (int y = 0; y < _height; y++)
                    {
                        int neighbors = CountNeighbors(x, y);

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

                _board = newBoard;

                Thread.Sleep(1000);
            }
        }

        private int CountNeighbors(int x, int y)
        {
            int count = 0;

            if (x > 0 && y > 0 && _board[x - 1, y - 1]) count++; // top-left
            if (y > 0 && _board[x, y - 1]) count++;//top
            if (x < _width - 1 && y > 0 && _board[x + 1, y - 1]) count++;//top-right
            if (x > 0 && _board[x - 1, y]) count++;//left
            if (x < _width - 1 && _board[x + 1, y]) count++;//right
            if (x > 0 && y < _height - 1 && _board[x - 1, y + 1]) count++;//bottom-left
            if (y < _height - 1 && _board[x, y + 1]) count++;//bottom
            if (x < _width - 1 && y < _height - 1 && _board[x + 1, y + 1]) count++;//bottom-right

            return count;
        }
    }
}
