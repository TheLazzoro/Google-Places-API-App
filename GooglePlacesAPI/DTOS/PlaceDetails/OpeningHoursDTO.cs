using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesAPI.DTOS.PlaceDetails
{
    public class OpeningHoursDTO
    {
        public bool open_now;
        public List<string> weekday_text;
    }
}
