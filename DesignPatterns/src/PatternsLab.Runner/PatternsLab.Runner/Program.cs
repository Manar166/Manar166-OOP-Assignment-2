using PatternsLab.Builder;
using PatternsLab.SingletonPattern;

namespace PatternsLab.Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== SINGLETON: AFTER ===\n");

                var db = new DatabaseService();
                var ui = new UiService();

                Console.WriteLine();

                db.Config.Theme = "Dark";
                Console.WriteLine("Admin changed theme to Dark.");

                ui.Render();

                Console.WriteLine($"\nSame config object? {ReferenceEquals(db.Config, ui.Config)}");
                Console.WriteLine($"Times config was loaded from disk: {AppConfig.LoadCount}");


                Console.WriteLine("\n=== BUILDER: AFTER ===\n");
                Console.WriteLine(RegistrationCallSites.CreateLiveStudent());
                Console.WriteLine(RegistrationCallSites.CreateVideosOnly());



            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
