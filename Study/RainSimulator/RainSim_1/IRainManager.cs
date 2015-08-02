// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>
namespace RainSim_1
{
    public interface IRainManager
    {
        void CreateRainDrops(int count);

        void MoveDrops();
    }
}