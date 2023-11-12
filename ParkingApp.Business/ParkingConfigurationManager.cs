using Microsoft.Extensions.Configuration;
using ParkingApp.Models;

namespace ParkingApp.Business
{
    public sealed class ParkingConfigurationManager
    {

        private static readonly object obj = new object();
        
        private static ParkingConfigurationManager instance;
        public static ParkingConfigurationManager Instance {
            get 
            {
                if (instance == null)
                {
                    lock (obj)
                        {
                            if (instance == null)
                            {
                                instance = new ParkingConfigurationManager();
                            }
                        }
                }
                return instance;
            } 
        }

        public ParkingSpot[] ParkingSpots { get; private set; }

        private ParkingConfigurationManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            var parkingConfig = config.GetSection("ParkingConfig").Get<ParkingConfig>();
            ParkingSpots = ConfigureParkingSpots.GetAllParkingSlots(parkingConfig);
        }

    }
}