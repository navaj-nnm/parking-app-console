using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public abstract class ParkingSpot
    {
        public int ParkingId { get; set; }
        public ParkingDimentions Dimentions { get; set; }
        public ParkingSpotType SpotType { get; set; }
        public bool IsOccupied { get; set; }
    }

    public class ParkingDimentions
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public ParkingDimentions(int h, int w)
        {
            Height = h;
            Width = w;
        }
    }

    public enum ParkingSpotType
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }
}
