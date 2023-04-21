using System;
using System.Collections.Generic;
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

        private string UserEnteredNumber() => Console.ReadLine();

        private int ParseNumber(string text)
        {
            return int.Parse(text);
        }

        public void GetSize()
        {
            Console.WriteLine($"Enter the height of the game board(minimum {_minHeight} and maximum {_maxHeight}): ");
            _height = ParseNumber(UserEnteredNumber());

            while (_height < _minHeight || _height > _maxHeight)
            {
                Console.WriteLine("Enter valid number: ");
                _height = ParseNumber(UserEnteredNumber());
            }

            Console.WriteLine($"Enter the width of the game board(minimum {_minWidth} and maximum {_maxWidth}): ");
            _width = ParseNumber(UserEnteredNumber());

            while (_width < _minWidth || _width > _maxWidth)
            {
                Console.WriteLine("Enter valid number: ");
                _width = ParseNumber(UserEnteredNumber());

            }
            _height = Height;
            _width = Width;
        }
    }
}

