using Newshore.Viajes.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newshore.Viajes.Communications.IServices
{
    public interface IApiFlights
    {
        Task<List<FlightResponseDto>> Getflights();
    }
}
