using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MyApi.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        // Fields
        private readonly ILogger<SampleController> _logger;
        private static readonly List<int> _samples = new() { 10 };

        // Constructor
        public SampleController(ILogger<SampleController> logger)
        {
            this._logger = logger;
        }

        // Methods
        [HttpGet("/sample")]
        public ContentResult GetSamples()
        // ASp.NET provides many return types under the IActionResult interface. as a rule of thumb, IActionResults deserialize themselves into an HTTP response.
        // ContentResult is good for when you have something to put in the response body.
        {
            string json = JsonSerializer.Serialize(_samples);
            var result = new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
            // _logger.LogTrace(); //use trace to record everything, all the time, everywhere.
            _logger.LogInformation($"Samples Value: {_samples[0]}"); //useful data, but can still be overwhelming.
            // _logger.LogDebug("logging event from GetSamples");
            // _logger.LogWarning();
            // _l0gger.LogError();
            // _logger_LogCritical();
            return result;
        }

        [HttpPost("/sample")]
        public ContentResult PostSample([FromBody] int value) 
        {
            _samples.Add(value);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = JsonSerializer.Serialize(_samples)
            };
        }

    }
}
