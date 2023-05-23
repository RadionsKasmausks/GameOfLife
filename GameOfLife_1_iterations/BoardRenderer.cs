using GameOfLife_Logic;
using Newtonsoft.Json;

namespace GameOfLife_Interface
{
    public class BoardRenderer
    {
        public void DrawBoard(Game game)
        {
            var height = game.Height;
            var width = game.Width;
            var board = game.Board;
            char _alive = '+';
            char _dead = ' ';
            string grid = string.Empty;

            int _aliveCount = Game.CountAliveCells(board);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (board[x, y])
                    {
                        grid += _alive;
                    }
                    else
                    {
                        grid += _dead;
                    }
                }
                grid += "\n";
            }
            Console.Write(grid);

            Console.WriteLine($"Alive cells: {_aliveCount}");
            Console.WriteLine($"Iteration count: {game.Iterations}");
        }

    }
}
