using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesAPI.Utility
{
    internal static class WebResponseHelper
    {
        internal static string GetContent(string url)
        {
            Uri uri = new Uri(url);
            WebRequest webRequest = WebRequest.Create(uri); // TODO: WebRequest is obsolete
            WebResponse webResponse = webRequest.GetResponse();
            var webStream = webResponse.GetResponseStream();

            StreamReader sr = new StreamReader(webStream);
            string content = sr.ReadToEnd();

            return content;
        }
    }
}
