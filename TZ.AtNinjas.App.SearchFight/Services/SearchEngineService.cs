using System;
using System.Collections.Generic;

namespace TZ.AtNinjas.App.SearchFight.Services
{
    public class SearchEngineService
    {
        public List<Result> Search(string[] searchWords, List<ISearch> searcheEngines)
        {
            List<Result> results = null;

            foreach (string word in searchWords)
            {
                string searchWordResults = "";
                foreach (var searcheEngine in searcheEngines)
                {
                    try
                    {
                        results = new List<Result>();

                        decimal? result = searcheEngine.GetFormatedResult(word);

                        results.Add(new Result { SearchEngine = searcheEngine.SearchEngineName(), Word = word, TotalResults = result });

                        searchWordResults += searcheEngine.SearchEngineName() + ": " + result + " ";
                    }
                    catch
                    {
                        searchWordResults += searcheEngine.SearchEngineName() + ": " + "ERROR ";
                    }

                }
                Console.WriteLine("{0}: {1}", word, searchWordResults);

            }

            return results;
        }
    }
}
