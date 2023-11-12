using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingApp.Business.Repositories;
using ParkingApp.Models;
using ParkingApp.Models.Contracts;

namespace ParkingApp.Business.Tests
{
    [TestClass]
    public class ParkingRepositoryUnitTest
    {
        private readonly IParkingRepository _parkingRepository;

        public ParkingRepositoryUnitTest()
        {
            _parkingRepository = new ParkingRepository();
        }
        [TestMethod]
        public void ParkSedan_ShouldUseSpot6()
        {
            string expected = "Parked at: 6";
            Car car = new Car { Type = CarType.SedanOrCompactSUV };
            string result = _parkingRepository.Park(car);
            Assert.AreEqual(expected, result);
        }
    }
}