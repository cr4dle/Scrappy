using Scrapper.Interfaces;
using Scrapper.Models;
using Scrapper.Repositories;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Scrapper.Services
{
    public class GoogleService : IScrapperBuilder
    {
        private const string _URL = @"https://www.google.co.uk/search?num=%%MAX_RESULTS%%&q=%%KEYWORDS%%";
        private static string _maxResults;
        private static string _keywords;
        private static string _url;

        private WebRequestService _webRequestService;
        private ScrapRepository _scrapRepository;

        public GoogleService(EngineInput engineInput)
        {
            _keywords = engineInput.Keywords;
            _url = engineInput.URL;
            _maxResults = Properties.Settings.Default.maxResults;
        }

        private string JoinStats(string separator, IEnumerable<string> stats)
        {
            return string.Join(separator, stats);
        }

        private bool HasData()
        {
            var results = (List<ScrapResult>)_scrapRepository.GetAll();

            return results != null && results.Count > 0;
        }

        private string GetURL()
        {
            return _URL.Replace("%%MAX_RESULTS%%", _maxResults).Replace("%%KEYWORDS%%", JoinKeywords());
        }

        private string JoinKeywords()
        {
            return string.Join("+", _keywords.Split(' ')).Trim();
        }

        public void Initialice()
        {
            _webRequestService = new WebRequestService();
            _scrapRepository = new ScrapRepository();
        }

        public string PingURL()
        {
            _webRequestService.Create(GetURL());

            return _webRequestService.GetResponse();
        }

        public void ProcessData(string googleData)
        {
            var regex = new Regex(@"(?<result><h3 class=""r"">.*</h3>)");

            foreach (Match ItemMatch in regex.Matches(googleData))
            {
                var aa = ItemMatch.Groups["result"].ToString();
                _scrapRepository.Insert(aa);
            }
        }

        public string GetResult()
        {
            var statistics = new List<string>();
            var rawData = (List<ScrapResult>)_scrapRepository.GetAll();

            if (HasData())
            {
                foreach (var data in rawData)
                {
                    if (data.ContainsURL(_url))
                    {
                        var position = data.Position().ToString();
                        statistics.Add(position);
                    }
                }
            }

            if (statistics.Count == 0)
            {
                statistics.Add("0");
            }

            return JoinStats(",", statistics);
        }
    }
}