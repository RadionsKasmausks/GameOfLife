namespace GameOfLife_1_iteration.Initialize
{
    public class InitializeBoard
    {
        private int _width;
        private int _height;
        private bool[,] _board;

        public bool[,] Board { get { return _board; } }

        public InitializeBoard(int width, int height)
        {
            this._width = width;
            this._height = height;
            _board = new bool[width, height];

            PopulateBoardRandomly();
        }

        private void PopulateBoardRandomly()
        {
            Random random = new Random();

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Board[x, y] = random.Next(2) == 1;
                }
            }
        }
    }
}
