//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GameOfLife_Logic
//{
//    public class SimulateGames
//    {
//        private bool[,] _board;
//        private int _width;
//        private int _height;
//        private static int iterations;
//        private readonly int numGames;
//        private BoardRenderer _boardrenderer = new BoardRenderer();
//        public void Simulate()
//        {
//            Task[] tasks = new Task[numGames];

//            for(int i = 0;i < numGames;i++)
//            {
//                tasks[i] = Task.Factory.StartNew(() => _boardrenderer.DrawBoard(_width, _height, _board, iterations);
//            }
//        } 
//    }
//}
