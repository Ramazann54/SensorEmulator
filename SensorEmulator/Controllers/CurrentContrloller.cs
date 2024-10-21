using Microsoft.AspNetCore.Mvc;
using SensorEmulator.Models;
using SensorEmulator.Services;

namespace SensorEmulator.Controllers
{
    [Route("api/current")]
    [ApiController]
    public class CurrentController : ControllerBase
    {
        private readonly SensorService _sensorService;

        public CurrentController(SensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet]
        public ActionResult<SensorData> GetCurrent()
        {
            return Ok(_sensorService.CurrentSensorData);
        }

        [HttpPost("value/{value}/scaler/{scaler}")]
        public ActionResult<double> SetCurrent(double value, int scaler)
        {
            _sensorService.CurrentSensorData.Value = value;
            _sensorService.CurrentSensorData.Scaler = scaler;
            return Ok(_sensorService.CurrentSensorData.GetCalculatedValue());
        }

        [HttpPut("scaler/{scaler}")]
        public IActionResult UpdateScaler(int scaler)
        {
            _sensorService.CurrentSensorData.Scaler = scaler;
            return Ok(new { n_value = _sensorService.CurrentSensorData.GetCalculatedValue() });
        }

        [HttpPut("value/{value}")]
        public IActionResult UpdateValue(double value)
        {
            _sensorService.CurrentSensorData.Value = value;
            return Ok(new { n_value = _sensorService.CurrentSensorData.GetCalculatedValue() });
        }
    }
}
