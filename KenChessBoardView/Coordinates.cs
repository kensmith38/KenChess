using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessBoardView
{
    /// <summary>
    /// Pair of int numbers representing coordinates,
    /// </summary>
    public class Coordinates
    {
        public int Xcoord { get; set; }
        public int Ycoord { get; set; }
        public Coordinates(int xCoord, int yCoord)
        {
            Xcoord = xCoord;
            Ycoord = yCoord;
        }
        public override string ToString()
        {
            return $"({Xcoord},{Ycoord})";
        }
    }
}
