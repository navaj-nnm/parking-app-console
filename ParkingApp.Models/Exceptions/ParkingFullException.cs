using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Models.Exceptions
{
    public class ParkingFullException: Exception
    {
        public ParkingFullException(): base("Parking area is full.")
        {
        }
    }
}
