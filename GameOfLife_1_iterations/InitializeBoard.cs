namespace GameOfLife_1_iteration.Initialize
{
    public class BoardInitializer
    {
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
    }

    public class Game
    {
        private int _width;
        private int _height;
        private bool[,] _board;

        public Game(int _width, int _height, bool[,] _board)
        {
            this._width = _width;
            this._height = _height;
            this._board = _board;
        }

        public void Run()
        {


            while (true)
            {
                Console.Clear();

                DrawBoard();

                UpdateBoard();

                Thread.Sleep(1000);
            }
        }

        private void UpdateBoard()
        {
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
        }

        private void DrawBoard()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    string _survivor = "+";
                    string _dead = " ";
                    Console.Write(_board[x, y] ? _survivor : _dead);
                }
                Console.WriteLine();
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
