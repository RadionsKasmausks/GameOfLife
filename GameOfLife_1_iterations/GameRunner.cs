//using GameOfLife_Interface;
//using System.Threading.Tasks;

//namespace GameOfLife_Logic
//{
//    class GameRunner
//    {
//        private static bool noCells = false;
//        private static BoardRenderer _boardrenderer = new BoardRenderer();
//        private static Menu _menu = new Menu();
//        private static OutputFile _files = new OutputFile();

//       public static async Task RunGames()
//        {
//            GameRunner program = new GameRunner();

//            var dataCollector = new InputData();
//            dataCollector.GetSize();

//            List<Task<(bool[,], Game)>> tasks = new List<Task<(bool[,], Game)>>();

//            for (int i = 0; i < 1000; i++)
//            {
//                Task<(bool[,], Game)> task = Task.Run(() =>
//                {
//                    bool[,] board = Game.Initialize(dataCollector.Width, dataCollector.Height);
//                    Game game = new Game(dataCollector.Width, dataCollector.Height, board);
//                    return (board, game);
//                });

//                tasks.Add(task);
//            }

//            (bool[,], Game)[] results = await Task.WhenAll(tasks);

//            List<Game> games = new List<Game>();
//            foreach ((bool[,] board, Game game) result in results)
//            {
//                games.Add(result.game);
//            }

//            Console.WriteLine("Select games to display (comma-separated):");

//            var selectedGames = Console.ReadLine()
//                   .Split(',', StringSplitOptions.RemoveEmptyEntries)
//                   .Select(index => int.Parse(index.Trim()) - 1)
//                   .Where(index => index >= 0 && index < games.Count)
//                   .Take(8)
//                   .ToArray();

//            bool isRunning = true;
//            while (isRunning)
//            {
//                Thread.Sleep(100);

//                Console.SetCursorPosition(0, 0);

//                Parallel.ForEach(selectedGames, gameIndex =>
//                {
//                    Game game = games[gameIndex];
//                    Run(0, gameIndex * (game.Height + 5), game);
//                    Console.WriteLine($"Game number: {gameIndex + 1}");
//                });

//                _menu.WriteCommands();

//                isRunning = InputData.FileFunctional(dataCollector.Width, dataCollector.Height, games[0].Board, games);
//            }
//        }

//        public static void Run(int xAxis, int yAxis, Game game)
//        {
//            if (!noCells)
//            {
//                Console.SetCursorPosition(xAxis, yAxis);
//                _boardrenderer.DrawBoard(game);
//                game.Board = GameRules.UpdateBoard(game);
//            }
//        }
//    }
//}


using GameOfLife_Interface;

namespace GameOfLife_Logic
{
    class GameRunner
    {
        private static bool noCells = false;
        private static BoardRenderer _boardrenderer = new BoardRenderer();
        private static Menu _menu = new Menu();
        private static List<Game> games;
        private static List<int> selectedGames;

        public static async Task RunGames()
        {
            GameRunner program = new GameRunner();

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

            games = new List<Game>();
            foreach ((bool[,] board, Game game) result in results)
            {
                games.Add(result.game);
            }

            SelectGames();

            bool isRunning = true;
            while (isRunning)
            {
                Thread.Sleep(100);

                Console.SetCursorPosition(0, 0);

                Parallel.ForEach(selectedGames, gameIndex =>
                {
                    Game game = games[gameIndex];
                    Run(0, gameIndex * (game.Height + 5), game);
                    Console.WriteLine($"Game number: {gameIndex + 1}");
                });

                _menu.WriteCommands();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.C)
                    {
                        SelectGames();
                    }
                }

                isRunning = InputData.FileFunctional(dataCollector.Width, dataCollector.Height, games[0].Board, games);
            }
        }

        public static void SelectGames()
        {
            Console.WriteLine("Select games to display (comma-separated):");

            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                selectedGames = new List<int>();
            }
            else
            {
                var gameIndices = input
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(index => int.Parse(index.Trim()) - 1)
                    .Where(index => index >= 0 && index < games.Count)
                    .Distinct()
                    .ToList();
                selectedGames = gameIndices;
            }
        }

        public static void Run(int xAxis, int yAxis, Game game)
        {
            if (!noCells)
            {
                Console.SetCursorPosition(xAxis, yAxis);
                _boardrenderer.DrawBoard(game);
                game.Board = GameRules.UpdateBoard(game);
            }
        }
    }
}
