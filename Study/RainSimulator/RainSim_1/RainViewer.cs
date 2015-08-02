// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Drawing;

namespace RainSim_1
{
    public class RainViewer : IDropViewer
    {
        private static string DropView = "|";
        private ConsoleColor BackgroundColor = ConsoleColor.Black;

        public RainViewer()
        {
            Console.CursorVisible = false;
        }

        public void OnDropAdded(object sender, DropAddedEventArgs args)
        {
            DrowDrop(((Raindrop)sender).Color, args.Coordinate);
        }

        public void OnDropMoved(object sender, DropMovedEventArgs args)
        {
            EraseDrop(args.From);
            DrowDrop(((Raindrop)sender).Color, args.To);
        }

        private static void DrowDrop(Color color, Coordinate coordinate)
        {
            Console.SetCursorPosition(coordinate.X, coordinate.Y);
            Console.ForegroundColor = FromColor(color);
            Console.Write(DropView);
        }

        private void EraseDrop(Coordinate coordinate)
        {
            Console.SetCursorPosition(coordinate.X, coordinate.Y);
            Console.ForegroundColor = BackgroundColor;
            Console.Write(DropView);
        }

        private static ConsoleColor FromColor(Color c)
        {
            var index = (c.R > 128 | c.G > 128 | c.B > 128) ? 8 : 0; // Bright bit
            index |= (c.R > 64) ? 4 : 0; // Red bit
            index |= (c.G > 64) ? 2 : 0; // Green bit
            index |= (c.B > 64) ? 1 : 0; // Blue bit
            return (ConsoleColor)index;
        }
    }
}