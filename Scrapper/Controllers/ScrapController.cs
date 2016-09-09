using Scrapper.Facade;
using Scrapper.Models;
using Scrapper.Services;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Scrapper.Controllers
{
    [EnableCors(origins: "http://localhost:1062", headers: "*", methods: "POST")]
    public class ScrapController : ApiController
    {
        private static ScrapFacade _scrapFacade;
        private GoogleService _googleScrapper;
        //private YahooService _yahooScrapper;

        // POST: api/Scrap/Google2016
        [HttpPost]
        public string Google2016(EngineInput engineInput)
        {
            _googleScrapper = new GoogleService(engineInput);
            _scrapFacade = new ScrapFacade(_googleScrapper);

            return _scrapFacade.GetResult();
        }

        // POST: api/Scrap/Yahoo2016
        [HttpPost]
        public string Yahoo2016(EngineInput engineInput)
        {
            //_yahooScrapper = new GoogleService(engineInput);
            //_scrapFacade = new ScrapFacade(_yahooScrapper);

            //return _scrapFacade.GetResult();

            return "1, 10, 33";
        }

        // Todo: other search engines
    }
}
