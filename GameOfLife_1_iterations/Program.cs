using System;

namespace GameOfLife_Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            GameRunner.RunGames().GetAwaiter().GetResult();
        }
    }
}
