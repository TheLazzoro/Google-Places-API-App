using GooglePlacesAPI.API;
using GooglePlacesAPI.DTOS;
using GooglePlacesAPI.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlaces.API
{
    public class PlaceDetails
    {
        private static string placeIdURL
        {
            get
            {
                return $"https://maps.googleapis.com/maps/api/place/findplacefromtext/json?parameters&key={API_Info.Key}&inputtype=textquery&input=";
            }
        }
        private static string placeDetailsURL
        {
            get
            {
                return $"https://maps.googleapis.com/maps/api/place/details/json?parameters&key={API_Info.Key}&place_id=";
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">Search input, e.g. from a text field.</param>
        public static PlaceDetailsDTO GetPlaceDetails(string query)
        {
            string placeId = GetPlaceId(query);
            string url = placeDetailsURL + placeId;
            string json = WebResponseHelper.GetContent(url);
            var placeDetailsDTO = JsonConvert.DeserializeObject<PlaceDetailsDTO>(json);

            return placeDetailsDTO;
        }

        private static string GetPlaceId(string query)
        {
            string placeId = string.Empty;
            string url = placeIdURL + query;
            string json = WebResponseHelper.GetContent(url);
            var placeIdDTO = JsonConvert.DeserializeObject<PlaceIdDTO>(json);

            if (placeIdDTO.candidates != null && placeIdDTO.candidates.Count > 0)
            {
                // TODO: What if there are multiple candidates for placeIds?
                placeId = placeIdDTO.candidates[0].place_id;
            }

            return placeId;
        }
    }
}
