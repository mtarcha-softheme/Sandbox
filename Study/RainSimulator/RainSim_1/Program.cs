using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RainSim_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var manager = new RainManager(Console.WindowWidth, Console.WindowHeight, new RainViewer(), new DropFactory());

            manager.CreateRainDrops(40);
            manager.StartDropsMoving();

            Console.ReadKey();
            manager.StopDrops();
        }
    }
}
