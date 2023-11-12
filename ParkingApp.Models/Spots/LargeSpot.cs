using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class LargeSpot: ParkingSpot
    {
        public LargeSpot()
        {
            Dimentions = new ParkingDimentions(10, 18);
            SpotType = ParkingSpotType.Large;
        }
    }
}
