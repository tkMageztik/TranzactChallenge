using System;
using System.Collections.Generic;
using System.Linq;

namespace TZ.AtNinjas.App.SearchFight.Services
{
    public class ReportService
    {
        public void Report(List<Result> results, List<ISearch> searcheEngines)
        {
            Console.WriteLine(string.Empty);

            foreach (ISearch searchEngine in searcheEngines)
            {
                var founded = results.Where(y => y.SearchEngine == searchEngine.SearchEngineName() && y.TotalResults.HasValue);

                if (founded.Count() > 0)
                {
                    Console.WriteLine("{0} winner: {1}", searchEngine.SearchEngineName(),
                    results.Where(x => x.TotalResults == founded.Max(y => y.TotalResults)).First().Word);
                }
            }

            List<Result> results2 = results.Where(x => x.TotalResults.HasValue).GroupBy(x => x.Word).
                  Select(y => new Result { Word = y.First().Word, TotalResults = y.Sum(z => z.TotalResults) }).ToList();

            if (results2.Count > 0)
            {
                Console.WriteLine("Total winner: {0}",
                    results2.Where(x => x.TotalResults == results2.Max(y => y.TotalResults)).First().Word);
            }
            else
            {
                Console.WriteLine("Total winner: Indeterminate");
            }
        }
        public void Report2(List<Result> results)
        {

            Console.WriteLine(string.Empty);

            foreach (string searchEngine in results.Select(x => x.SearchEngine).Distinct().ToList())
            {
                var founded = results.Where(y => y.SearchEngine == searchEngine && y.TotalResults.HasValue);

                if (founded.Count() > 0)
                {
                    Console.WriteLine("{0} winner: {1}", searchEngine,
                    results.Where(x => x.TotalResults == founded.Max(y => y.TotalResults)).First().Word);
                }
            }

            List<Result> results2 = results.Where(x => x.TotalResults.HasValue).GroupBy(x => x.Word).
                  Select(y => new Result { Word = y.First().Word, TotalResults = y.Sum(z => z.TotalResults) }).ToList();

            if (results2.Count > 0)
            {
                Console.WriteLine("Total winner: {0}",
                    results2.Where(x => x.TotalResults == results2.Max(y => y.TotalResults)).First().Word);
            }
            else
            {
                Console.WriteLine("Total winner: Indeterminate");
            }
        }
    }
}
