using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife_1_iterations
{
    public class InputData
    {
        private const int _minWidth = 10;
        private const int _minHeight = 10;
        private const int _maxWidth = 80;
        private const int _maxHeight = 25;

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
                Console.WriteLine($"{prompt} (minimum {_minValue} and maximum {_maxValue}): ");
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

