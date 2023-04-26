using GooglePlacesAPI.DTOS.PlaceId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesAPI.DTOS
{
    public class PlaceIdDTO
    {
        public List<CandidatesDTO> candidates;
        public string status;
    }
}
