using System.Numerics;
using System.Threading.Tasks;

namespace GameOfLife_Logic
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dataCollector = new InputData();
            dataCollector.GetSize();

            List<Task<(bool[,], Game)>> tasks = new List<Task<(bool[,], Game)>>();


            for (int i = 0; i < 1000; i++)
            {
                Task<(bool[,], Game)> task = Task.Run(() =>
                {
                    bool[,] board = Game.Initialize(dataCollector.Width, dataCollector.Height);
                    Game game = new Game(dataCollector.Width, dataCollector.Height, board);
                    return (board, game);
                });

                tasks.Add(task);
            }

            (bool[,], Game)[] results = await Task.WhenAll(tasks);

            List<Game> games = new List<Game>();
            foreach ((bool[,] board, Game game) result in results)
            {
                games.Add(result.game);
            }

            while (true)
            {


                Console.WriteLine("Select games to display (comma-separated):");

                var selectedGames = Console.ReadLine()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(index => int.Parse(index.Trim()) - 1)
                    .Take(8)
                    .ToArray();

                Console.Clear();

                int sectionWidth = Console.WindowWidth / 2;
                int sectionHeight = Console.WindowHeight / 4;

                for (int i = 0; i < selectedGames.Length; i++)
                {
                    int gameIndex = selectedGames[i];
                    Game game = games[gameIndex];


                    int x = (i % 2) * sectionWidth;
                    int y = (i / 2) * sectionHeight;


                    Console.SetCursorPosition(x, y);
                    Console.WriteLine($"Game {gameIndex + 1}:");
                    Console.SetCursorPosition(x, y + 1);

                    game.Run();
                }

                Console.ReadKey(true);
            }
        }

        //for (int i = 0; i < 8; i++)
        //{
        //    Console.WriteLine($"Game {i + 1}");
        //    games[i].Run();
        //    Console.WriteLine();
        //}

    }
    
}
