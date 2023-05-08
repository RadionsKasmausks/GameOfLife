using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife_Logic
{
    public class Commands
    {
        public void WriteCommands()
        {
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("| Button [S] to Save game!  | \t");
            Console.WriteLine("| Button [L] to Load game!  | \t");
            Console.WriteLine("| Button [D] to Delete game!| \t");
            Console.WriteLine("| Button [ESC] to Exit game!| \t");
            Console.WriteLine("+---------------------------+");
        }
    }
}
