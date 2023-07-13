using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newshore.Viajes.Communications.IServices;
using Newshore.Viajes.Model.DTO;
using Newshore.Viajes.Model.Model;

namespace Newshore.Viajes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly ILogger<FlightsController> _logger;
        private readonly IApiFlights _apiFlights;

        public FlightsController(ILogger<FlightsController> logger, IApiFlights apiFlights)
        {
            _logger = logger;
            _apiFlights = apiFlights;
        }

        [HttpGet(Name = "Getflights")]
        public async Task<IEnumerable<FlightResponseDto>> Get()
        {
            var flights = await _apiFlights.Getflights();
            // var flights = result.AsQueryable().Select(FlightResponseDto.MapFlightResponseDtoToFlight).ToList();
            return flights;
        }
    }
}
