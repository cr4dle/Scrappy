using Scrapper.Models;
using System;
using System.Collections.Generic;

namespace Scrapper.Interfaces
{
    interface IScrapRepository //: IDisposable
    {
        IEnumerable<ScrapResult> GetAll();
        ScrapResult GetByPosition(int position);
        void Insert(string result);
        void Delete(int position);
        void Update(ScrapResult result);
        void Save();
    }
}
