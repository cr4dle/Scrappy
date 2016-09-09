namespace Scrapper.Interfaces
{
    public interface IScrapperBuilder
    {
        void Initialice();
        string PingURL();
        void ProcessData(string googleData);
        string GetResult();
    }
}
