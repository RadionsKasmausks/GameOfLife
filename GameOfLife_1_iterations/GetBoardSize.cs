public class BoardSize
{
    private const int _minWidth = 10;
    private const int _minHeight = 10;
    private const int _maxWidth = 80;
    private const int _maxHeight = 50;

    private int width;
    private int height;

    public int Width => width;
    public int Height => height;

    private string UserEnteredNumber()
    {
        return Console.ReadLine();
    }

    private int ParseNumber(string text)
    {
        return int.Parse(text);
    }

    public void PromptForSize()
    {
        Console.WriteLine($"Enter the width of the game board (minimum {_minWidth}):");
        width = ParseNumber(UserEnteredNumber());

        while (width < _minWidth || width > _maxWidth)
        {
            Console.Write($"Width must be minimum {_minWidth} and maximum {_maxWidth}! Enter the valid number: ");
            width = ParseNumber(UserEnteredNumber());
        }

        Console.WriteLine($"Enter the height of the game board (minimum {_minHeight}): ");
        height = ParseNumber(UserEnteredNumber());

        while (height < _minHeight || height > _maxHeight)
        {
            Console.Write($"Height must be minimu {_minHeight} and maximum {_maxHeight}! Enter valid number: ");
            height = ParseNumber(UserEnteredNumber());
        }
    }
}
