using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsLab.SingletonPattern
{
    public class AppConfig
    {
        public static int LoadCount;

        public string DbConnection { get; set; }
        public string Theme { get; set; }

        private static Lazy<AppConfig> _instance = new Lazy<AppConfig>(() => new AppConfig());

        public static AppConfig Instatnce => _instance.Value;


        private AppConfig()
        {
            LoadCount++;
            Console.WriteLine($"[AppConfig] Loading settings from disk... (load #{LoadCount})");
            Thread.Sleep(300);
            DbConnection = "Server=localhost;Db=School";
            Theme = "Light";
        }
    }

    public class DatabaseService
    {
        public AppConfig Config =>AppConfig.Instatnce;

        public void Connect() => Console.WriteLine($"Connecting to {Config.DbConnection}");
    }

    public class UiService
    {
        public AppConfig Config => AppConfig.Instatnce;

        public void Render() => Console.WriteLine($"UI is using theme: {Config.Theme}");
    }

}
