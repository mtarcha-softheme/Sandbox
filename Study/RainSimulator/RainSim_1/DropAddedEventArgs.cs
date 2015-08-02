// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;

namespace RainSim_1
{
    public class DropAddedEventArgs : EventArgs
    {
        private readonly Coordinate _coordinate;

        public DropAddedEventArgs(Coordinate coordinate)
        {
            _coordinate = coordinate;
        }

        public Coordinate Coordinate { get { return _coordinate; } }  
    }
}