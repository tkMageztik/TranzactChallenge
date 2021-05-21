namespace TZ.AtNinjas.App.SearchFight.Services
{
    public class YahooSearchEngine : WebSearchEngine
    {
        private readonly string url;
        private readonly string pattern;
        private const string Yahoo = "Yahoo";

        public YahooSearchEngine(string url, string pattern)
        {
            this.url = url;
            this.pattern = pattern;
        }
        public override string Url()
        {
            return this.url;
        }
        public override string Pattern()
        {
            return this.pattern;
        }
        public override string SearchEngineName()
        {
            return Yahoo;
        }
    }
}
