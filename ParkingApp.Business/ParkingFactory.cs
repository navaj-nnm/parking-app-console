using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Business
{
    internal class ParkingFactory
    {
        internal static ParkingSpot GetAvailableParkingSpot(Car car)
        {
            ParkingSpot result = null;
            switch (car.Type)
            {
                case CarType.HatchBack:
                    result = GetHatchbackParkingSlot();
                    break;
                case CarType.SedanOrCompactSUV:
                    result = GetSedanParkingSlot();
                    break;
                case CarType.LargeSUV:
                    result =  GetLargeParking();
                    break;
                case 0:
                    break;
            }
            return result;
        }

        private static ParkingSpot GetHatchbackParkingSlot()
        {
            try 
            {
                return GetSmallParking();
            }
            catch
            {
                try
                {
                    return GetMediumParking();
                }
                catch
                {
                    return GetLargeParking();
                }
            }
        }

        private static ParkingSpot GetSedanParkingSlot()
        {
            try
            {
                return GetMediumParking();
            }
            catch
            {
                return GetLargeParking();
            }
        }

        private static ParkingSpot GetSmallParking()
        {
            var allParkings = ParkingConfigurationManager.Instance.ParkingSpots;
            return allParkings.Where(x => x.IsOccupied == false && x.SpotType == ParkingSpotType.Small).OrderBy(x => x.ParkingId).First();
        }
        private static ParkingSpot GetMediumParking()
        {
            var allParkings = ParkingConfigurationManager.Instance.ParkingSpots;
            return allParkings.Where(x => x.IsOccupied == false && x.SpotType == ParkingSpotType.Medium).OrderBy(x => x.ParkingId).First();
        }
        private static ParkingSpot GetLargeParking()
        {
            var allParkings = ParkingConfigurationManager.Instance.ParkingSpots;
            return allParkings.Where(x => x.IsOccupied == false && x.SpotType == ParkingSpotType.Large).OrderBy(x => x.ParkingId).First();
        }
    }
}
