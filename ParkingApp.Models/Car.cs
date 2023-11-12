using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class Car
    {
        public CarType Type { get; set; }
        public string RegNumber { get; set; }
    }

    public enum CarType
    {
        HatchBack = 1,
        SedanOrCompactSUV = 2,
        LargeSUV = 3
    }
}
