namespace TZ.AtNinjas.App.SearchFight.Services
{
    public class AnotherNonWebSearchEngine : ISearch
    {
        private readonly string source;
        private const string Other = "Other";
        public AnotherNonWebSearchEngine(string source)
        {
            this.source = source;
        }

        public decimal? GetFormatedResult(string searchWord)
        {
            int count = 0, minIndex = (this.source.IndexOf(searchWord, 0));
            while (minIndex != -1)
            {
                minIndex = this.source.IndexOf(searchWord, minIndex + searchWord.Length);
                count++;
            }
            return count;
        }

        public int CountSubstring(string text, string value)
        {
            int count = 0, minIndex = text.IndexOf(value, 0);
            while (minIndex != -1)
            {
                minIndex = text.IndexOf(value, minIndex + value.Length);
                count++;
            }
            return count;
        }

        public string SearchEngineName()
        {
            return Other;
        }
    }
}
