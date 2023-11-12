using ParkingApp.Models;

namespace ParkingApp.Business
{
    internal class ConfigureParkingSpots
    {
        public static ParkingSpot[] GetAllParkingSlots(ParkingConfig parkingConfig)
        {
            int i = 1;
            int s = parkingConfig.SmallSpots;
            int m = parkingConfig.MediumSpots;
            int l = parkingConfig.LargeSpots;
            List<ParkingSpot> result = new List<ParkingSpot>();
            if (s > 0)
                for (; i <= s; i++)
                    result.Add(new SmallSpot { ParkingId = i });
            if (m > 0)
                for (; i <= (s+m); i++)
                    result.Add(new MediumSpot { ParkingId = i });
            if (l > 0)
                for (; i <= (s+m+l); i++)
                    result.Add(new LargeSpot { ParkingId = i });

            return result.ToArray();
        }
    }
}
