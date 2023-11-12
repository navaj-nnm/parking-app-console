using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Models.Exceptions
{
    public class ParkingInUseException: Exception
    {
        public ParkingInUseException(): base("Parking in use.")
        {
        }
    }
}
