using System.IO;
using System.Reflection;
using System.Text;

namespace TZ.AtNinjas.App.SearchFight.Services
{
    public class FileService
    {
        public void WriteAllText(string htmlSearchEnginePage, string searchEngineName)
        {
            File.WriteAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                searchEngineName + ".html"), htmlSearchEnginePage, Encoding.GetEncoding("Windows-1252"));

        }
    }
}
