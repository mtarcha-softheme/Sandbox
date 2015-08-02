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
            var viewer = new RainViewer();
            var manager = new RainManager(Console.WindowWidth, Console.WindowHeight, viewer);
            manager.CreateRainDrops(40);

            Task.Run(() => manager.MoveDrops());
            Console.ReadKey();
        }
    }
}
