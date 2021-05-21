using System;

namespace TZ.AtNinjas.App.SearchFight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            args = new string[3];
            args[0] = ".net";
            args[1] = "java";
            args[2] = "java script";

            if (args.Length == 0)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("No se ingresaron valores... .");
                Console.WriteLine("Presione una tecla para finalizar... .");
                Console.ReadKey();
            }
            else
            {
                SearchFight obj = new SearchFight(args);
                obj.Base();
                Console.WriteLine(string.Empty);
                Console.WriteLine("Presione una tecla para finalizar... .");
                Console.ReadKey();
            }
        }
    }
}
