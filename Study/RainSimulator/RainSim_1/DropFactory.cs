// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System.Collections.Generic;
using System.Drawing;

namespace RainSim_1
{
    public sealed class DropFactory : IDropFactory
    {
        private static readonly Dictionary<Color, Raindrop> RainDropsStorage = new Dictionary<Color, Raindrop>();

        public IEnumerable<Raindrop> GetAllDrops
        {
            get { return new List<Raindrop>(RainDropsStorage.Values); }
        }

        public  Raindrop GetRaindrop(Color color)
        {
            if (RainDropsStorage.ContainsKey(color))
            {
                return RainDropsStorage[color];
            }

            var newDrop = new Raindrop(color);
            RainDropsStorage.Add(color, newDrop);

            return newDrop;
        }
    }
}