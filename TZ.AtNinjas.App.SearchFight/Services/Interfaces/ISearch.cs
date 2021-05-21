namespace TZ.AtNinjas.App.SearchFight.Services
{
    public interface ISearch
    {
        /// <summary>
        /// Main method!
        /// </summary>
        /// <param name="source">bla1</param>
        /// <param name="searchWord">bla2</param>
        /// <returns></returns>

        decimal? GetFormatedResult(string searchWord);

        string SearchEngineName();

    }
}
