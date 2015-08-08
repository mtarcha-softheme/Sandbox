// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System.Collections.Generic;
using System.Drawing;

namespace RainSim_1
{
    public interface IDropFactory
    {
        IEnumerable<Raindrop> GetAllDrops { get; } 

        Raindrop GetRaindrop(Color color);
    }
}