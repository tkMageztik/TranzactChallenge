namespace TZ.AtNinjas.App.SearchFight.Services
{
    public class GoogleSearchEngine : WebSearchEngine
    {
        private readonly string url;
        private readonly string pattern;
        private readonly bool useProxy;
        private const string Google = "Google";

        public GoogleSearchEngine(string url, string pattern, bool useProxy)
        {
            this.url = url;
            this.pattern = pattern;
            this.useProxy = useProxy;
        }
        public override string Url()
        {
            return this.url;
        }
        public override string Pattern()
        {
            return this.pattern;
        }
        public override bool UseProxy()
        {
            return this.useProxy;
        }
        public override string SearchEngineName()
        {
            return Google;
        }
    }
}
