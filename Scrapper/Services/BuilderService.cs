using Scrapper.Interfaces;
using System;

namespace Scrapper.Services
{
    public class BuilderService
    {
        private IScrapperBuilder _scrapperBuilder;

        public BuilderService(IScrapperBuilder scrapperBuilder)
        {
            if ((_scrapperBuilder = scrapperBuilder) == null) throw new ArgumentNullException(nameof(scrapperBuilder));
        }

        public void ConstructScrapperEngine()
        {
            _scrapperBuilder.Initialice();
            var rawData = _scrapperBuilder.PingURL();
            _scrapperBuilder.ProcessData(rawData);
        }

        public string GetResult()
        {
            return _scrapperBuilder.GetResult();
        }
    }
}