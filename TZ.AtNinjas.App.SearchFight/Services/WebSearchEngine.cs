using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TZ.AtNinjas.App.SearchFight.Services
{
    public abstract class WebSearchEngine : ISearch
    {
        private readonly FileService fileService;
        public WebSearchEngine()
        {
            this.fileService = new FileService();

        }
        public abstract string Url();
        public abstract string Pattern();
        public abstract string SearchEngineName();

        public virtual async Task<string> GetResults(string searchWord)
        {

#if DEBUG
            var proxy = new WebProxy
            {
                Address = new Uri(""),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,

                Credentials = new NetworkCredential(
                    userName: "",
                    password: "")
            };

            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
            };

            httpClientHandler.PreAuthenticate = true;
            httpClientHandler.UseDefaultCredentials = false;

            using (var client = new HttpClient(httpClientHandler, false))
#else
            using (var client = new HttpClient())
#endif

            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36");

                var result = client.GetAsync(this.Url() + searchWord);


                return await result.Result.Content.ReadAsStringAsync();
            }
        }
        public virtual decimal? GetFormatedResult(string searchWord)
        {
            this.fileService.WriteAllText(GetResults(searchWord).Result, SearchEngineName());

            MatchCollection match = Regex.Matches(GetResults(searchWord).Result, Pattern());

            if (match.Count > 0)
            {
                return DecimalTryParse(Regex.Replace(match[0].Groups[1].Value, @"[^\d]", string.Empty));
            }

            return 0;
        }

        private static decimal? DecimalTryParse(string value)
        {
            decimal result;
            if (!decimal.TryParse(value, out result))
                return null;
            return result;
        }
    }
}
