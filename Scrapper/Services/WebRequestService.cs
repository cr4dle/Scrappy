using System.IO;
using System.Net;
using System.Text;

namespace Scrapper.Services
{
    public class WebRequestService
    {
        private HttpWebRequest _request;

        public void Create(string url)
        {
            _request = (HttpWebRequest) WebRequest.Create(url);
        }

        public string GetResponse()
        {
            HttpWebResponse response = _request.GetResponse() as HttpWebResponse;

            Stream receiveStream = response.GetResponseStream();

            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            return readStream.ReadToEnd();
        }
    }
}