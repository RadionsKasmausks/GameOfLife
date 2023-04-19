using GameOfLife_1_iteration.Initialize;
using GameOfLife_1_iteration.run;
using System.Diagnostics.CodeAnalysis;

namespace GameOfLife_1_iteration
{
    class Program
    {
        static void Main(string[] args)
        {
            var getBoardSize = new BoardSize();
            getBoardSize.PromptForSize();

            bool[,] board = BoardInitializer.Initialize(getBoardSize.Width, getBoardSize.Height);

            var gameRunner = new Game(getBoardSize.Width, getBoardSize.Height, board);
            gameRunner.Run();
        }   
    }

    

}

