using GameOfLife_1_iteration.Initialize;
using GameOfLife_1_iteration.run;

namespace GameOfLife_1_iteration
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardSize = new GetBoardSize();
            boardSize.PromptForSize();

            var boardInitializer = new InitializeBoard(boardSize.Width, boardSize.Height);

            var gameRunner = new RunGame(boardSize.Width, boardSize.Height, boardInitializer.Board);
            gameRunner.Start();
        }
    }
}

