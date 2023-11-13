using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Models.Contracts
{
    public interface IParkingRepository
    {
        string Park(Car car);
        void UnPark(int id);
        string GetAvailableSlots();
    }
}
