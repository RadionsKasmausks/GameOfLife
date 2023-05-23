namespace GameOfLife_Logic
{
    public static class GameRules
    {
        public static bool[,] UpdateBoard(Game game)
        {
            var height = game.Height;
            var width = game.Width;
            var board = game.Board;

            bool[,] newBoard = new bool[width, height];


            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int neighbors = CountNeighbors(x, y, width,height,board);
                    if (board[x, y])
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
            game.Iterations++;
            return newBoard;
        }

        private static int CountNeighbors(int x, int y, int _width, int _height, bool[,] _board)
        {
            int count = 0;
            for (int rowOffSet = -1; rowOffSet <= 1; rowOffSet++)
            {
                for (int colOffSet = -1; colOffSet <= 1; colOffSet++)
                {
                    if (rowOffSet == 0 && colOffSet == 0) continue;

                    int neighborsX = x + rowOffSet;
                    int neighborsY = y + colOffSet;

                    if (neighborsX < 0)
                        neighborsX = _width - 1;
                    else if (neighborsX >= _width)
                        neighborsX = 0;

                    if (neighborsY < 0)
                        neighborsY = _height - 1;
                    else if (neighborsY >= _height)
                        neighborsY = 0;

                    if (_board[neighborsX, neighborsY])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

    }
}
