// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Drawing;

namespace RainSim_1
{
    public class RainManager : IRainManager
    {
        private readonly int _maxX;
        private readonly int _maxY;
        private readonly Random _random;
        private readonly IDropViewer _viewer;

        public RainManager(int windowSizeX, int windowSizeY, IDropViewer viewer)
        {
            _maxX = windowSizeX;
            _maxY = windowSizeY;
            _random = new Random();
            _viewer = viewer;
        }

        public void CreateRainDrops(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var color = Color.FromArgb(_random.Next(int.MaxValue));
                var coordinate = new Coordinate{X = _random.Next(_maxX - 1), Y = _random.Next(_maxY - 1)};

                var drop = DropFactory.GetRaindrop(color);
                drop.DropAdded += _viewer.OnDropAdded;
                drop.DropMoved += _viewer.OnDropMoved;
                drop.AddCoordinate(coordinate);
            }
        }

        public void MoveDrops()
        {
            while (true)
            {
                foreach (var drop in DropFactory.GetAll)
                {
                    foreach (var coordinate in drop.DropCoordinates)
                    {
                        int y;
                        if (coordinate.Y + 3 >= _maxY)
                        {
                            y = _maxY - coordinate.Y - 1;
                        }
                        else
                        {
                            y = coordinate.Y + 3;
                        }

                        var to = new Coordinate {X = coordinate.X, Y = y};

                        drop.Move(coordinate, to);
                    }
                }
            }
        }
    }
}