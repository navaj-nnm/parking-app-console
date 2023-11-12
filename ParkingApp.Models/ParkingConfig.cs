using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class ParkingConfig
    {
        public int SmallSpots { get; set; }
        public int MediumSpots { get; set; }
        public int LargeSpots { get; set; }
    }

    public static class ParkingStatus
    {
        public static bool IsBusy { get; set; }
    }
}
