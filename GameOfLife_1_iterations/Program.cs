using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Conway's Game of Life");

        GameOfLife game = new GameOfLife();
        game.Start();
    }
}