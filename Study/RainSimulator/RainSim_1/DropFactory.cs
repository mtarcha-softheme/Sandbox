// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;

namespace RainSim_1
{
    public static class DropFactory
    {
        private static readonly ConcurrentDictionary<Color, Raindrop> RainDropsStorage = new ConcurrentDictionary<Color, Raindrop>();

        public static Raindrop GetRaindrop(Color color)
        {
            return RainDropsStorage.GetOrAdd(color, color1 => new Raindrop(color1));
        }

        public static IEnumerable<Raindrop> GetAll 
        {
            get { return new List<Raindrop>(RainDropsStorage.Values); }
        }
    }
}