using Microsoft.AspNetCore.Mvc;
using SensorEmulator.Models;
using SensorEmulator.Services;

namespace SensorEmulator.Controllers
{
    [Route("api/voltage")]
    [ApiController]
    public class VoltageController : ControllerBase
    {
        private readonly SensorService _sensorService;

        public VoltageController(SensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet]
        public ActionResult<SensorData> GetVoltage()
        {
            return Ok(_sensorService.VoltageSensorData);
        }

        [HttpPost("value/{value}/scaler/{scaler}")]
        public ActionResult<double> SetVoltage(double value, int scaler)
        {
            _sensorService.VoltageSensorData.Value = value;
            _sensorService.VoltageSensorData.Scaler = scaler;
            return Ok(_sensorService.VoltageSensorData.GetCalculatedValue());
        }

        [HttpPut("scaler/{scaler}")]
        public IActionResult UpdateScaler(int scaler)
        {
            _sensorService.VoltageSensorData.Scaler = scaler;
            return Ok(new { n_value = _sensorService.VoltageSensorData.GetCalculatedValue() });
        }

        [HttpPut("value/{value}")]
        public IActionResult UpdateValue(double value)
        {
            _sensorService.VoltageSensorData.Value = value;
            return Ok(new { n_value = _sensorService.VoltageSensorData.GetCalculatedValue() });
        }
    }
}
