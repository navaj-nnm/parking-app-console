using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class SmallSpot: ParkingSpot
    {
        public SmallSpot()
        {
            Dimentions = new ParkingDimentions(8, 10);
            SpotType = ParkingSpotType.Small;
        }
    }
}
