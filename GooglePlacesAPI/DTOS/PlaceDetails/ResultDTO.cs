using GooglePlacesAPI.DTOS.PlaceDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesAPI.DTOS
{
    public class ResultDTO
    {
        public string name;
        public string formatted_address;
        public OpeningHoursDTO opening_hours;
        public uint rating;
    }
}
