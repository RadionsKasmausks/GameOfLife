using Newtonsoft.Json;

namespace GameOfLife_Logic
{

    public class BoardRenderer
    {
        private int _aliveCount = 0;

        public int AliveCount => _aliveCount;   
        public int CountAliveCells(int width,int height, bool[,] _board)
        {
            int aliveCount = 0;
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if (_board[x,y])
                    {
                        aliveCount++;
                    }
                }
            }
            return aliveCount;
        }
        public void DrawBoard(int width, int height, bool[,] _board, int iterations)
        {
            _aliveCount = CountAliveCells(width, height, _board);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    string _alive = "+";
                    string _dead = " ";

                    if (_board[x, y])
                    {
                        Console.Write(_alive);
                        
                    }
                    else
                    {
                        Console.Write(_dead);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Alive cells: {_aliveCount}");
            Console.WriteLine($"Iteration count: {iterations}");
        }
    }
}
