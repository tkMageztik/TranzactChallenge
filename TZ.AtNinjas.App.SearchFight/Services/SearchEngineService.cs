using System;
using System.Collections.Generic;

namespace TZ.AtNinjas.App.SearchFight.Services
{
    public class SearchEngineService
    {
        public List<Result> Search(string[] searchWords, List<ISearch> searcheEngines)
        {
            List<Result> results = new List<Result>();

            foreach (string word in searchWords)
            {
                string searchWordResults = "";
                foreach (var searchEngine in searcheEngines)
                {
                    try
                    {
                        if (searchEngine is WebSearchEngine webSearchEngine)
                        {
                            if (IsNotValid(webSearchEngine))
                                continue;
                        }

                        decimal? result = searchEngine.GetFormatedResult(word);

                        results.Add(new Result { SearchEngine = searchEngine.SearchEngineName(), Word = word, TotalResults = result });

                        searchWordResults += searchEngine.SearchEngineName() + ": " + result + " ";
                    }
                    catch
                    {
                        searchWordResults += searchEngine.SearchEngineName() + ": " + "ERROR ";
                    }

                }
                Console.WriteLine("{0}: {1}", word, searchWordResults);

            }

            return results;
        }

        private bool IsNotValid(WebSearchEngine webSearchEngine)
        {
            return string.IsNullOrEmpty(webSearchEngine.Url()) || string.IsNullOrEmpty(webSearchEngine.Pattern());
        }
    }
}
