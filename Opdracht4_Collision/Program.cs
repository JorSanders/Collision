using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht4_Collision
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new SimPhyGameWorld())
                game.Run();
        }
    }
}
