using Scrapper.Interfaces;
using Scrapper.Services;
using System;

namespace Scrapper.Facade
{
    public class ScrapFacade
    {
        private BuilderService _builderService;

        public ScrapFacade(IScrapperBuilder scrapperBuilder)
        {
            if (scrapperBuilder == null) throw new ArgumentNullException(nameof(scrapperBuilder));

            _builderService = new BuilderService(scrapperBuilder);

            _builderService.ConstructScrapperEngine();
        }

        public string GetResult()
        {
            return _builderService.GetResult();
        }
    }
}