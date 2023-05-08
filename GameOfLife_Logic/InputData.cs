namespace GameOfLife_Logic
{
    public class InputData
    {
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
    }
}

