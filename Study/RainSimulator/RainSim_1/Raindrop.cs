// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Collections.Generic;
using System.Drawing;


namespace RainSim_1
{
    public class Raindrop
    {
        private readonly Color _color;
        private readonly IList<Coordinate> _dropCoordinates;

        public Raindrop(Color color)
        {
            _color = color;
            _dropCoordinates = new List<Coordinate>();
        }

        public event EventHandler<DropMovedEventArgs> DropMoved;
        public event EventHandler<DropAddedEventArgs> DropAdded;

        public Color Color { get { return _color; } }

        public IEnumerable<Coordinate> DropCoordinates
        {
            get { return new List<Coordinate>(_dropCoordinates); }
        }

        public void Move(Coordinate from, Coordinate to)
        {
            if (_dropCoordinates.Contains(from))
            {
                _dropCoordinates.Remove(from);
                _dropCoordinates.Add(to);

                OnDropMoved(new DropMovedEventArgs(from, to));
            }
        }

        public void AddCoordinate(Coordinate dropCoordinate)
        {
            if (!_dropCoordinates.Contains(dropCoordinate))
            {
                _dropCoordinates.Add(dropCoordinate);
                OnDropAdded(new DropAddedEventArgs(dropCoordinate));
            }
        }

        private void OnDropMoved(DropMovedEventArgs dropMovedArgs)
        {
            var temp = DropMoved;

            if (temp != null) temp(this, dropMovedArgs);
        }

        private void OnDropAdded(DropAddedEventArgs dropAddedArgs)
        {
            var temp = DropAdded;

            if (temp != null) temp(this, dropAddedArgs);
        }
    }
}