using GameOfLife_1_iterations;
using GameOfLife_1_iterations.Game;
using System.Security.Cryptography.X509Certificates;
//using GameOfLife_1_iterations.Initialize;

namespace GameOfLife_1_iteration
{
    class Program
    {
        static void Main(string[] args)
        {
            var areasize = new InputData();
            areasize.GetSize();

            var boardSize = new BoardSizeInput(areasize.Width, areasize.Height);
            int width = boardSize.Width;
            int height = boardSize.Height;

            bool[,] board = Game.Initialize(boardSize.Width, boardSize.Height);

            var gameRunner = new Game(boardSize.Width, boardSize.Height, board);
            gameRunner.Run();
        }
    }
}

