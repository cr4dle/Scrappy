namespace Scrapper.Models
{
    public class ScrapResult
    {
        private int _position;
        public string RawData { get; set; }

        public ScrapResult(int position, string data)
        {
            _position = position;

            RawData = data;
        }

        public bool ContainsURL(string URL)
        {
            return RawData.Contains(URL);
        }

        public int Position()
        {
            return _position;
        }
    }
}