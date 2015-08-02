// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;

namespace RainSim_1
{
    public class DropMovedEventArgs : EventArgs
    {
        private readonly Coordinate _from;
        private readonly Coordinate _to;

        public DropMovedEventArgs(Coordinate from, Coordinate to)
        {
            _from = from;
            _to = to;
        }

        public Coordinate From { get { return _from; } }

        public Coordinate To { get { return _to; } }
    }
}