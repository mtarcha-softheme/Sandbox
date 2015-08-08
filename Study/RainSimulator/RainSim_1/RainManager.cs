// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace RainSim_1
{
    public class RainManager : IRainManager
    {
        private readonly int _maxX;
        private readonly int _maxY;
        private readonly Random _random;
        private readonly IDropViewer _viewer;
        private readonly IDropFactory _dropsFactory;
        private CancellationTokenSource _cancellationTokenSource;

        public RainManager(int windowSizeX, int windowSizeY, IDropViewer viewer, IDropFactory dropsFactory)
        {
            _maxX = windowSizeX;
            _maxY = windowSizeY;
            _random = new Random();
            _viewer = viewer;
            _dropsFactory = dropsFactory;
        }

        public void CreateRainDrops(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var color = Color.FromArgb(_random.Next(int.MaxValue));
                var coordinate = new Coordinate{X = _random.Next(_maxX - 1), Y = _random.Next(_maxY - 1)};

                var drop = _dropsFactory.GetRaindrop(color);
                drop.DropAdded += _viewer.OnDropAdded;
                drop.DropMoved += _viewer.OnDropMoved;
                drop.AddCoordinate(coordinate);
            }
        }

        public void StartDropsMoving()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => MoveDrops(), _cancellationTokenSource.Token);
        }

        public void StopDrops()
        {
            _cancellationTokenSource.Cancel();
        }

        private void MoveDrops()
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                foreach (var drop in _dropsFactory.GetAllDrops)
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

                        var to = new Coordinate { X = coordinate.X, Y = y };

                        drop.Move(coordinate, to);
                    }
                }
            }
        }
    }
}