namespace TZ.AtNinjas.App.SearchFight.Services
{
    public class BingSearchEngine : WebSearchEngine
    {
        private readonly string url;
        private readonly string pattern;
        private const string Bing = "Bing";

        public BingSearchEngine(string url, string pattern)
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
            return Bing;
        }
    }
}
