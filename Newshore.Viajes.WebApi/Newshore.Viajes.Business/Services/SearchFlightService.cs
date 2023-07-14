using Newshore.Viajes.Business.IServices;
using Newshore.Viajes.Communications.IServices;
using Newshore.Viajes.Model.DTO;
using Newshore.Viajes.Model.Model;
using Newshore.Viajes.Repository.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newshore.Viajes.Business.Services
{
    public class SearchFlightService: ISearchFlightService
    {
        private readonly IApiFlightsService _apiFlights;
        private readonly ISearchHistoryRespository _searchHistoryRespository;
        
        public SearchFlightService(IApiFlightsService apiFlights, ISearchHistoryRespository searchHistoryRespository) {
            _apiFlights = apiFlights;
            _searchHistoryRespository = searchHistoryRespository;
        }

        public async Task<Journey> SearchFlight(SearchDto request)
        {
            var result = await _apiFlights.Getflights();
            var flights = result.AsQueryable().Select(FlightResponseDto.MapFlightResponseDtoToFlight).ToList();
            var foundFlight = GetFlights(flights, request);
            Journey journey = new Journey() { 
                Origin = request.Origin,
                Destination = request.Destination,
                Flights = foundFlight,
                Price = foundFlight.Sum(f => f.Price)
            };

            SaveSearch(request);

            return journey;
        }

        private List<Flight> GetFlights(List<Flight> flights, SearchDto request)
        { 
            var foundFlights = new List<Flight>();
            bool foundRoute = false;
            bool notFoundRoute = false;
            int iteratedFlights = 0;

            var originFlight = flights.FirstOrDefault(f => f.Origin.Equals(request.Origin));
            if (originFlight != null)
            {
                foundFlights.Add(originFlight);
                // Si es un vuelo directo
                if (originFlight.Destination.Equals(request.Destination))
                    return foundFlights;

                // Buscar el o los siguientes vuelos en la ruta
                while (foundRoute || iteratedFlights <= flights.Count)
                {
                    var otherFlight = flights.FirstOrDefault(f => f.Origin.Equals(originFlight.Destination));

                    if (otherFlight == null)
                    {
                        notFoundRoute = true;
                        break;
                    }

                    foundFlights.Add(otherFlight);

                    if (otherFlight.Destination.Equals(request.Destination))
                    {
                        notFoundRoute = false;
                        break;
                    }
                    iteratedFlights++;
                    originFlight = otherFlight;
                    notFoundRoute = true;
                }

            }
            else {
                notFoundRoute = true;
            }

            if (notFoundRoute) foundFlights = new List<Flight>();

            return foundFlights;
        }

        private async Task SaveSearch(SearchDto request)
        {
            SearchHistory searchHistory = new SearchHistory() { 
                Origin = request.Origin,
                Destination = request.Destination,
                SearchDate = DateTime.Now
            };

            await _searchHistoryRespository.Save(searchHistory);
        }

        public async Task<IEnumerable<SearchHistory>> GetHistory()
        {
            return await _searchHistoryRespository.GetAll();
        }
    }
}
