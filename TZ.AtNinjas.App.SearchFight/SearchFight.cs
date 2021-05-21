using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Reflection;
using TZ.AtNinjas.App.SearchFight.Services;

namespace TZ.AtNinjas.App.SearchFight
{
    public class SearchFight
    {
        JsonValue ConfigDics;
        private string[] Words { get; set; }

        public SearchFight(string[] args)
        {
            Words = args;
        }

        private void Init()
        {
            using (var reader = new StreamReader(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
               "appsettings.json")))
            {
                ConfigDics = JsonValue.Load(reader);
            }
        }

        public void Base()
        {
            Init();
            Fight();
        }
        public void Fight()
        {
            var searchEnginesConfig = ConfigDics["searchEngines"];
            var useProxy = ConfigDics["useProxy"];
            var google = searchEnginesConfig["Google"];
            var bing = searchEnginesConfig["Bing"];
            var yahoo = searchEnginesConfig["Yahoo"];
            var msnSearch = searchEnginesConfig["MSN Search"];

            List<ISearch> searchEngines = new List<ISearch>
            {
                new GoogleSearchEngine(google["url"],google["pattern"],useProxy),
                new BingSearchEngine(bing["url"],bing["pattern"],useProxy),
                new YahooSearchEngine(yahoo["url"],yahoo["pattern"],useProxy),
                new AnotherNonWebSearchEngine("Tengo que encontrar la palabra .net en este texto"),
            };

            List<Result> results =
            new SearchEngineService().Search(this.Words, searchEngines);

            new ReportService().Report2(results);
        }

    }
}
