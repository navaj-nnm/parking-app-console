using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingApp.Models;

namespace ParkingApp.Business.Tests
{
    [TestClass]
    public class ParkingSpotsUnitTests
    {
        private readonly ParkingSpot[] _parkingSpots;

        public ParkingSpotsUnitTests()
        {
            _parkingSpots = ParkingConfigurationManager.Instance.ParkingSpots;
        }
        [TestMethod]
        public void TotalCountOfParkingSlots_10()
        {
            int totalCountFromConfig = 10;
            var countFromReader = _parkingSpots.Length;
            Assert.AreEqual(totalCountFromConfig, countFromReader);
        }
        [TestMethod]
        public void TotalCountOfSmallParkingSlots_5()
        {
            int totalCountFromConfig = 5;
            var countFromReader = 0;
            foreach (var a in _parkingSpots)
                if (a.SpotType == ParkingSpotType.Small)
                    countFromReader++;
            Assert.AreEqual(totalCountFromConfig, countFromReader);
        }
        [TestMethod]
        public void TotalCountOfMediumParkingSlots_3()
        {
            int totalCountFromConfig = 3;
            var countFromReader = 0;
            foreach (var a in _parkingSpots)
                if (a.SpotType == ParkingSpotType.Medium)
                    countFromReader++;
            Assert.AreEqual(totalCountFromConfig, countFromReader);
        }
        [TestMethod]
        public void TotalCountOfLargeParkingSlots_2()
        {
            int totalCountFromConfig = 2;
            var countFromReader = 0;
            foreach (var a in _parkingSpots)
                if (a.SpotType == ParkingSpotType.Large)
                    countFromReader++;
            Assert.AreEqual(totalCountFromConfig, countFromReader);
        }
    }
}
