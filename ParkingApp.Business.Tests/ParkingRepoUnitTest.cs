using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingApp.Business.Repositories;
using ParkingApp.Models;
using ParkingApp.Models.Contracts;
using ParkingApp.Models.Exceptions;
using System;

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
            ParkingConfigurationManager.Instance.ResetParkings();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ParkFourthSedan_ShouldUseSpot9()
        {
            string expected = "Parked at: 9";
            Car car = new Car { Type = CarType.SedanOrCompactSUV };
            for(int i=0; i < 3; i++)
            {
                _parkingRepository.Park(car);
            }
            string result = _parkingRepository.Park(car);
            ParkingConfigurationManager.Instance.ResetParkings();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ParkSixSedan_ShouldThrowFullException()
        {
            Exception exception = new Exception();
            Car car = new Car { Type = CarType.SedanOrCompactSUV };
            for (int i = 0; i < 5; i++)
            {
                _parkingRepository.Park(car);
            }
            try {
                string result = _parkingRepository.Park(car);
            }
            catch(ParkingFullException ex)
            {
                exception = ex;
            }
            finally
            {
                ParkingConfigurationManager.Instance.ResetParkings();
            }

            Assert.IsInstanceOfType(exception, typeof(ParkingFullException));
        }

        [TestMethod()]
        public void ParkCarWhenBusy_ShouldThrowBusyException()
        {
            Exception exception = new Exception();
            Car car = new Car { Type = CarType.HatchBack };
            ParkingStatus.IsBusy = true;
            try
            {
                string result = _parkingRepository.Park(car);
            }
            catch (ParkingInUseException ex)
            {
                exception = ex;
            }
            finally
            {
                ParkingStatus.IsBusy = false;
                ParkingConfigurationManager.Instance.ResetParkings();
            }

            Assert.IsInstanceOfType(exception, typeof(ParkingInUseException));
        }
    }
}