using Newshore.Viajes.Application.IApplicationService;
using Newshore.Viajes.Business.IServices;
using Newshore.Viajes.Model.DTO;
using Newshore.Viajes.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newshore.Viajes.Application.ApplicationService
{
    public class SearchFlightApplicationService: ISearchFlightApplicationService
    {
        private readonly ISearchFlightService _searchFlightService;
        public SearchFlightApplicationService(ISearchFlightService searchFlightService) { 
            _searchFlightService = searchFlightService;
        }

        public async Task<Journey> SearchFlight(SearchDto request)
        {
            try
            {
                return await _searchFlightService.SearchFlight(request);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
