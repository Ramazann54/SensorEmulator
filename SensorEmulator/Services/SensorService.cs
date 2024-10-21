using SensorEmulator.Models;

namespace SensorEmulator.Services
{
    public class SensorService
    {
        public SensorData VoltageSensorData { get; set; } = new SensorData();
        public SensorData PowerSensorData { get; set; } = new SensorData();
        public SensorData CurrentSensorData { get; set; } = new SensorData();
    }
}
