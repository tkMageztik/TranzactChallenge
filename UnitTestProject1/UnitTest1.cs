using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using TZ.AtNinjas.App.SearchFight;
using TZ.AtNinjas.App.SearchFight.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod3()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                string[] args = new string[3];
                args[0] = ".net";
                args[1] = "java";
                args[2] = "java script";

                SearchFight obj = new SearchFight(args);
                obj.Base();

                var result = sw.ToString().Trim();

                StringAssert.Contains(result, ".net");
            }
        }

        [TestMethod]
        public void GoogleSearchEngine()
        {
            string[] words = new string[3];
            words[0] = ".net";
            words[1] = "java";
            words[2] = "java script";

            List<ISearch> searchEngines = new List<ISearch>
            {
                new GoogleSearchEngine("https://www.google.com.pe/search?q=","([0-9,]+) resultados",true)
            };

            List<Result> results = new SearchEngineService().Search(words, searchEngines);

            new ReportService().Report2(results);

            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public void BingSearchEngine()
        {
            string[] words = new string[3];
            words[0] = ".net";
            words[1] = "java";
            words[2] = "java script";

            List<ISearch> searchEngines = new List<ISearch>
            {
                new BingSearchEngine("https://www.bing.com/search?q=","<span class=\"sb_count\">([0-9]+(\\.[0-9]+)+)",true)
            };

            List<Result> results =
            new SearchEngineService().Search(words, searchEngines);

            new ReportService().Report(results, searchEngines);

            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public void YahooSearchEngine()
        {
            string[] words = new string[3];
            words[0] = ".net";
            words[1] = "java";
            words[2] = "java script";

            List<ISearch> searchEngines = new List<ISearch>
            {
                new YahooSearchEngine("https://espanol.search.yahoo.com/search?p=","([0-9,]+) resultado",true)
            };

            List<Result> results =
            new SearchEngineService().Search(words, searchEngines);

            new ReportService().Report2(results);

            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public void AnotherNonWebSearchEngine()
        {
            string[] words = new string[3];
            words[0] = ".net";
            words[1] = "java";
            words[2] = "java script";

            List<ISearch> searchEngines = new List<ISearch>
            {
                new AnotherNonWebSearchEngine("Tengo que encontrar la palabra .net en este texto")
            };

            List<Result> results =
            new SearchEngineService().Search(words, searchEngines);

            new ReportService().Report2(results);

            Assert.IsTrue(results.Count > 0);
        }
    }
}