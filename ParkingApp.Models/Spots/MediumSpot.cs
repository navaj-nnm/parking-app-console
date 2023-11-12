using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class MediumSpot: ParkingSpot
    {
        public MediumSpot()
        {
            Dimentions = new ParkingDimentions(8, 15);
            SpotType = ParkingSpotType.Medium;
        }
    }
}
