using GameOfLife_Logic;

namespace GameOfLife_Interface
{
    public class InputData
    {
        GameRunner gamerunner = new GameRunner();

        private const int _minWidth = 40;
        private const int _minHeight = 20;
        private const int _maxWidth = 80;
        private const int _maxHeight = 40;

        private int _width;
        private int _height;

        public int Height => _height;
        public int Width => _width;

        private int GetIntegerInput(string prompt, int _minValue, int _maxValue)
        {
            int input;
            bool isValidInput;

            do
            {
                Console.WriteLine($"{prompt}\n (minimum {_minValue} and maximum {_maxValue}): ");
                string userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out input) && input >= _minValue && input <= _maxValue;

                if (!isValidInput)
                {
                    Console.WriteLine($"Invalid input. Please enter a valid integer.");
                }

            } while (!isValidInput);

            return input;
        }

        public void GetSize()
        {
            _height = GetIntegerInput("Enter the height of the game board", _minHeight, _maxHeight);
            _width = GetIntegerInput("Enter the width of the game board", _minWidth, _maxWidth);
        }

        private BoardRenderer _boardRenderer = new BoardRenderer();

        public static bool FileFunctional(int width, int height, bool[,] board, List<Game> games)
        {
            while (true)
            {
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

                            }
                            OutputFile.SaveGames($"C:\\Users\\radions.kasmausks\\source\\repos\\GameOfLife\\{fileName}.json", games);
                            break;

                        case 'l':
                            Console.Write("Enter filename to load game: ");
                            string fileNameLoad = Console.ReadLine();
                            if (string.IsNullOrEmpty(fileNameLoad))
                            {
                                Console.WriteLine("File name cannot be empty.");

                            }

                            Console.Clear();
                            OutputFile.LoadGames($"C:\\Users\\radions.kasmausks\\source\\repos\\GameOfLife\\{fileNameLoad}.json");
                            if (games.Count > 0)
                            {
                                Game firstGame = games[0];
                                width = firstGame.Width;
                                height = firstGame.Height;
                                board = firstGame.Board;
                            }
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

                        case 'q':
                            return false;
                    }
                }
                return true;
            }
        }
    }
}

