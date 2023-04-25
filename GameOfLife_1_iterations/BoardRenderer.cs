namespace GameOfLife_1_iterations
{
    public class BoardRenderer
    {
        public void DrawBoard(int width,int height,bool[,] _board)
        {
            Console.Clear();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    string _alive = "+";
                    string _dead = " ";

                    Console.Write(_board[x, y] ? _alive : _dead);
                }
                Console.WriteLine();
            }
        }
    }
}
