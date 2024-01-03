using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MyOtherRepository _otherRepository;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyOtherRepository otherRepository)
        {
            _logger = logger;
            _otherRepository = otherRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult> Get([FromBody] MyEntity entity)
        {
            await _otherRepository.AddMyEntity(entity);
            return Ok();
        }
    }
}
