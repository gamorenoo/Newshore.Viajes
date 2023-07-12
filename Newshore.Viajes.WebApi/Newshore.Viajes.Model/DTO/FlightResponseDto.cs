using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newshore.Viajes.Model.DTO
{
    public class FlightResponseDto
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public double Price { get; set; }

        public string FlightCarrier { get; set; }

        public string FlightNumber { get; set; }
    }
}
