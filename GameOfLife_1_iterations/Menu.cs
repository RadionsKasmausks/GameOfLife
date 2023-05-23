using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace GameOfLife_Logic
{
    public class Menu
    {
        public void WriteCommands()
        {
            Console.WriteLine("+-----------------------------+");
            Console.WriteLine("| Button [S] to Save game!    | \t");
            Console.WriteLine("| Button [L] to Load game!    | \t");
            Console.WriteLine("| Button [D] to Delete game!  | \t");
            Console.WriteLine("| Button [C] to Change game!  | \t");
            Console.WriteLine("| Button [Q] to Quit game!    | \t");
            Console.WriteLine("+-----------------------------+");
        }
    }
}