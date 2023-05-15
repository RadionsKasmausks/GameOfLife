namespace GameOfLife_Logic
{

    public class GameRules
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
