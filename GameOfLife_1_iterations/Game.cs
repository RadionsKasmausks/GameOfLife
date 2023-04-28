using GameOfLife_1_iterations;

namespace GameOfLife_1_iterations.Game
{
    public class Game
    {
        private bool[,] _board;
        private int _width;
        private int _height;

        public Game(int width, int height, bool[,] _board)
        {
            this._width = width;
            this._height = height;
            this._board = _board;
        }    

        public void Run()
        {
            BoardRenderer boardrenderer = new BoardRenderer();
            GameRules gamerules = new GameRules();

            while (true)
            {
                boardrenderer.DrawBoard(_width,_height,_board);

                _board = gamerules.UpdateBoard(_width, _height, _board);

                Thread.Sleep(1000);
            }
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
    }
}
