namespace GameOfLife_1_iterations
{
    public class BoardRenderer
    {
        public void DrawBoard(bool[,] _board)
        {
            int _width = _board.GetLength(0);
            int _height = _board.GetLength(1);
            Console.Clear();
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
    }
}
