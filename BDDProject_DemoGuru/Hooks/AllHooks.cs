using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Serilog;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Edge;
using BDDProject_DemoGuru.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace BDDProject_DemoGuru.Hooks
{
    [Binding]
    public sealed class AllHooks : CoreCodes
    {
        public static IWebDriver? driver;
        public static ExtentReports extent;
        public static ExtentSparkReporter sparkReporter;
        public static ExtentTest test;

        [BeforeFeature(Order = 1)]
        public static void ReadConfigSettings()

        {
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            properties = new Dictionary<string, string>();
            string fileName = currentDirectory + "/ConfigSettings/config.properties";
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }

        }
        [BeforeFeature(Order = 2)]
        public static void InitializeBrowsers()
        {
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currentDirectory + "/ExtentReports/extent-report"
                + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");

            extent.AttachReporter(sparkReporter);
            ReadConfigSettings();
            if (properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();

            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();

            }
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }

        [BeforeFeature(Order = 3)]
        public static void LogFileCreation()
        {
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy.mm.dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        [AfterFeature]
        public static void CleanUp()
        {
            driver?.Quit();
            extent.Flush();
            Log.CloseAndFlush();


        }


    }
}