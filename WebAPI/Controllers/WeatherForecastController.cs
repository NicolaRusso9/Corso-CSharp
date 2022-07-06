using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]                                                 // specifico per le chiamate REST
    [Route("[controller]")]                                         // mappa il path della richiesta -->  questo stile reindirizza su /weatherforecast
    //[Route("/api/forecast")]                                      // mappa il path su /api/forecast
    public class WeatherForecastController : ControllerBase         // eredita da controllerbase e non da controller in quanto non ha bisogno di metodi come View per reindirizzare la risposta sull'html
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Get(5);
        }

        [HttpGet("{days:int}")]         // {days:int} = vincola il valoredi days ad un intero
        public IEnumerable<WeatherForecast> Get(int days)
        {
            return Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}