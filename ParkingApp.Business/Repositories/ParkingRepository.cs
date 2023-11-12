using ParkingApp.Models;
using ParkingApp.Models.Contracts;
using ParkingApp.Models.Exceptions;
using System.Text;

namespace ParkingApp.Business.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        public void Park(Car car)
        {
            if (ParkingStatus.IsBusy)
                throw new ParkingInUseException();
            else
            {
                ParkingStatus.IsBusy = true;
                try
                {
                    var parkingSpot = ParkingFactory.GetAvailableParkingSpot(car);
                    UpdateParkingSlot(parkingSpot.ParkingId, true);
                }
                catch
                {
                    throw new ParkingFullException();
                }
                finally
                {
                    ParkingStatus.IsBusy = false;
                }
            }
        }

        public void UnPark(int parkingId)
        {
            if (ParkingStatus.IsBusy)
                throw new ParkingInUseException();
            else
            {
                ParkingStatus.IsBusy = true;
                UpdateParkingSlot(parkingId, false);
                ParkingStatus.IsBusy = false;
            }
        }

        public string GetAvailableSlots() { 
                StringBuilder builder = new StringBuilder("Total Available Parkings are => \n");
                var groups = ParkingConfigurationManager.Instance.ParkingSpots
                    .Where(x => x.IsOccupied == false)
                    .GroupBy(x => x.SpotType);
                foreach (var group in groups)
                {
                    builder.AppendLine(group.Key.ToString() + " : " + group.Count());
                }
                builder.AppendLine("----------------------------------");
                return builder.ToString();
        }

        private void UpdateParkingSlot(int parkingId, bool isParking)
        {
            for(int i=0; i< ParkingConfigurationManager.Instance.ParkingSpots.Length; i++)
            {
                if (ParkingConfigurationManager.Instance.ParkingSpots[i].ParkingId == parkingId)
                {
                    ParkingConfigurationManager.Instance.ParkingSpots[i].IsOccupied = isParking;
                    break;
                }
            }
        }
    }
}
