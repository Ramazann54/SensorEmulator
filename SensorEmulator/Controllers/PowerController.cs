using Microsoft.AspNetCore.Mvc;
using SensorEmulator.Models;
using SensorEmulator.Services;

namespace SensorEmulator.Controllers
{
    [Route("api/power")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private readonly SensorService _sensorService;

        public PowerController(SensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet]
        public ActionResult<SensorData> GetPower()
        {
            return Ok(_sensorService.PowerSensorData);
        }

        [HttpPost("value/{value}/scaler/{scaler}")]
        public ActionResult<double> SetPower(double value, int scaler)
        {
            _sensorService.PowerSensorData.Value = value;
            _sensorService.PowerSensorData.Scaler = scaler;
            return Ok(_sensorService.PowerSensorData.GetCalculatedValue());
        }

        [HttpPut("scaler/{scaler}")]
        public IActionResult UpdateScaler(int scaler)
        {
            _sensorService.PowerSensorData.Scaler = scaler;
            return Ok(new { n_value = _sensorService.PowerSensorData.GetCalculatedValue() });
        }

        [HttpPut("value/{value}")]
        public IActionResult UpdateValue(double value)
        {
            _sensorService.PowerSensorData.Value = value;
            return Ok(new { n_value = _sensorService.PowerSensorData.GetCalculatedValue() });
        }
    }
}
