using GameOfLife_1_iterations;
using GameOfLife_1_iterations.Game;

namespace GameOfLife_1_iteration
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataCollector = new InputData();
            dataCollector.GetSize();

            bool[,] board = Game.Initialize(dataCollector.Width, dataCollector.Height);

            var gameRunner = new Game(dataCollector.Width, dataCollector.Height, board);
            gameRunner.Run();
        }
    }
}

