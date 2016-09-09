using Scrapper.Interfaces;
using Scrapper.Models;
using System.Collections.Generic;
using System;

namespace Scrapper.Repositories
{
    public class ScrapRepository : IScrapRepository
    {
        private List<ScrapResult> _rawData;        

        public ScrapRepository()
        {
            _rawData = new List<ScrapResult>();
        }

        private int GetNextPositionIndex()
        {
            return _rawData.Count + 1;
        }

        private bool ValidPosition(int position)
        {
            return 0 < position && position < _rawData.Count;
        }

        private int GetZeroBasedIndex(int position)
        {
            return position - 1;
        }

        public IEnumerable<ScrapResult> GetAll()
        {
            return _rawData;
        }

        public ScrapResult GetByPosition(int position)
        {
            var result = new ScrapResult(0,string.Empty);

            if(ValidPosition(position))
            {
                result = _rawData[GetZeroBasedIndex(position)];
            }

            return result;
        }

        public void Insert(string result)
        {
            if (!string.IsNullOrEmpty(result))
            {
                _rawData.Add(new ScrapResult(GetNextPositionIndex(), result));
            }
        }

        public void Delete(int position)
        {
            if (ValidPosition(position))
            {
                _rawData.RemoveAt(GetZeroBasedIndex(position));
            }
        }

        public void Update(ScrapResult result)
        {
            int position = Convert.ToInt32(result.Position());

            if (ValidPosition(position))
            {
                _rawData[GetZeroBasedIndex(position)] = result;
            }
        }

        public void Save()
        {
            // Here usually goes something like context.SaveChanges();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\ScrappyLog.txt", true))
            {
                foreach (var data in _rawData)
                {
                    file.WriteLine(data.RawData);
                }
            }
        }
    }
}