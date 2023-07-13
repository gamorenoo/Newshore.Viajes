using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newshore.Viajes.Application.IApplicationService;
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
        private readonly ISearchFlightApplicationService _searchFlightApplicationService;

        public FlightsController(ILogger<FlightsController> logger, ISearchFlightApplicationService searchFlightApplicationService)
        {
            _logger = logger;
            _searchFlightApplicationService = searchFlightApplicationService;
        }

        //[HttpGet(Name = "Getflights")]
        //public async Task<IEnumerable<FlightResponseDto>> Get()
        //{
        //    var flights = await _apiFlights.Getflights();
        //    // var flights = result.AsQueryable().Select(FlightResponseDto.MapFlightResponseDtoToFlight).ToList();
        //    return flights;
        //}

        [HttpPost(Name = "SearchRoute")]
        public async Task<Journey> Search(SearchDto request)
        {
            return await _searchFlightApplicationService.SearchFlight(request);
        }
    }
}
