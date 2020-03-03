using System;
using System.IO;
using Core.Selenium;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public static class ConfigManager
    {
        public static IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public static string StartUrl => Configuration["StartUrl"];

        public static double Wait => Convert.ToDouble(Configuration["Wait"]);

        public static BrowserType Browser => (BrowserType)Enum.Parse(typeof(BrowserType), Configuration["Browser"]);
        public static bool IsDriverRemote => Convert.ToBoolean(Configuration["IsDriverRemote"]);
    }
}
