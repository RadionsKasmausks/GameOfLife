using System;
using System.Threading;

class GameOfLife
{
    private const int MinWidth = 10;
    private const int MinHeight = 10;

    private int width;
    private int height;
    private bool[,] board;

    public void Start()
    {
        GetBoardSize();
        InitializeBoard();
        RunGame();
    }

    private void GetBoardSize()
    {
        Console.WriteLine("Enter the width of the game board: ");
        int width = int.Parse(Console.ReadLine());

        while (width < MinWidth)
        {
            Console.WriteLine($"Width must be at least {MinWidth}. Enter valid number: ");
            width = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter the height of the game board: ");
        int height = int.Parse(Console.ReadLine());

        while (height < MinHeight)
        {
            Console.WriteLine($"Height must be at least {MinHeight}. Enter valid number: ");
            height = int.Parse(Console.ReadLine());
        }
    }
    private void InitializeBoard()
    {
        board = new bool[width, height];
        
        Random random = new Random();
        for(int x = 0;x < width; x++)
        {
            for(int y = 0;y < height; y++)
            {
                board[x,y] = random.Next(2) == 1;
            }
        }
    }

   private void RunGame()
    {
        while(true)
        {
            Console.Clear();

            for(int y = 0;y < height;y++)
            {
                for(int x = 0;x< width;x++)
                {
                    Console.Write(board[x,y]?"+" : " "); 
                }
                Console.WriteLine();
            }

            bool[,]newBoard = new bool[width,height];

            for(int x = 0;x<width;x++)
            {
                for(int y = 0;y<height;y++)
                {
                    int neighbors = CountNeighbors(x,y);

                    if (board[x,y])
                    {
                        if (neighbors < 2 || neighbors > 3)
                        {
                            newBoard[x,y] = false;
                        }
                        else
                        {
                            newBoard[x,y] = true;
                        }
                    }
                    else
                    {
                        if(neighbors == 3)
                        {
                            newBoard[x,y] = true;
                        }
                        else
                        {
                            newBoard[x, y] = false;
                        }
                    }
                }
            }

            board = newBoard;
            Thread.Sleep(1000);
        }
    }

    private int CountNeighbors(int x,int y)
    {
        int count = 0;

        if (x > 0 && y > 0 && board[x - 1, y - 1]) count++;
        if(y > 0 && board[x,y-1])count++;
        if(x < width - 1 && y >0 && board[x+1,y-1])count++;
        if(x > 0 && board[x-1,y])count++;
        if (x < width - 1 && board[x + 1, y]) count++;
        if(x > 0 && y<height - 1 && board[x-1,y+1])count++; 
        if(y<height - 1 && board[x,y+1])count++;
        if(x < width -1 && y < height - 1 && board[x+1,y+1])count++;

        return count;
    }
}
