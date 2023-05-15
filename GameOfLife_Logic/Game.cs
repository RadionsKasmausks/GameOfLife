using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace GameOfLife_Logic
{
    public class Game
    {
        private bool noCells = true;
        private bool[,] _board;
        private int _width;
        private int _height;
        private static int iterations;
        private Commands _commands = new Commands();
        private BoardRenderer _boardrenderer = new BoardRenderer();
        public int Height => _height;

        public Game(int width, int height, bool[,] _board)
        {
            this._width = width;
            this._height = height;
            this._board = _board;
        }

        public void Run()
        {
            GameRules gamerules = new GameRules();

            while (noCells)
            {
                Console.SetCursorPosition(0, 0);

                _boardrenderer.DrawBoard(_width, _height, _board, iterations);

                _board = gamerules.UpdateBoard(_width, _height, _board);

                Thread.Sleep(100);

                _commands.WriteCommands();

                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey(true);

                    switch (input.KeyChar)
                    {
                        case 's':
                            Console.Write("Enter filename to save game: ");
                            string fileName = Console.ReadLine();
                            if (string.IsNullOrEmpty(fileName))
                            {
                                Console.WriteLine("File name cannot be empty.");
                                continue;
                            }
                            Save($"C:\\Users\\radions.kasmausks\\source\\repos\\GameOfLife\\{fileName}.json");
                            break;

                        case 'l':
                            Console.Write("Enter filename to load game: ");
                            string fileNameLoad = Console.ReadLine();
                            if (string.IsNullOrEmpty(fileNameLoad))
                            {
                                Console.WriteLine("File name cannot be empty.");
                                continue;
                            }

                            Console.Clear();
                            Game loadedGame = Load($"C:\\Users\\radions.kasmausks\\source\\repos\\GameOfLife\\{fileNameLoad}.json");
                            this._board = loadedGame._board;
                            this._height = loadedGame._height;
                            this._width = loadedGame._width;
                            break;

                        case 'd':
                            Console.Clear();

                            string directoryPath = @"C:\Users\radions.kasmausks\source\repos\GameOfLife\";

                            Console.WriteLine("Files in directory: ");
                            foreach (string file in Directory.GetFiles(directoryPath))
                            {
                                string filename = Path.GetFileName(file);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($" {filename} ");
                                Console.ResetColor();
                            }

                            Console.Write("Enter filename to delete game: ");
                            string fileNameDelete = Console.ReadLine();
                            if (string.IsNullOrEmpty(fileNameDelete))
                            {
                                Console.WriteLine("File name cannot be empty. ");
                                continue;
                            }
                            string filePath = $"C:\\Users\\radions.kasmausks\\source\\repos\\GameOfLife\\{fileNameDelete}.json";
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                                Console.WriteLine($"{fileNameDelete}.json was deleted.");
                            }
                            else
                            {
                                Console.WriteLine($"{fileNameDelete}.json does not exist.");
                            }
                            Console.Clear();
                            break;

                        case (char)27:
                            return;
                    }
                }

                iterations++;
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

        public void Save(string fileName)
        {
            var gameState = new Dictionary<string, object>()
            {
                { "width", _width },
                { "height", _height },
                { "board", _board },
                { "AliveCount", _boardrenderer.AliveCount },
                { "Iterations", iterations}
            };

            var json = JsonConvert.SerializeObject(gameState);

            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(json);
            }
        }

        public static Game Load(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                var json = reader.ReadToEnd();
                var gameState = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

                var width = Convert.ToInt32(gameState["width"]);
                var height = Convert.ToInt32(gameState["height"]);
                var aliveCount = Convert.ToInt32(gameState["AliveCount"]);
                var boardData = (JArray)gameState["board"];
                var board = new bool[width, height];

                iterations = Convert.ToInt32(gameState["Iterations"]);

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        board[i, j] = (bool)boardData[i][j];
                    }
                }

                return new Game(width, height, board);
            }
        }

    }
}