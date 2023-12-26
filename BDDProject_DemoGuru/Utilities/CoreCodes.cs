
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.DevTools.V117.Page;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using OpenQA.Selenium.Support.UI;

using AventStack.ExtentReports.Model;
using AventStack.ExtentReports;
using Log = Serilog.Log;
using BDDProject_DemoGuru.Hooks;



namespace BDDProject_DemoGuru.Utilities
{
    public class CoreCodes //corecodes
    {
        public static Dictionary<string, string>? properties;

        public IWebDriver? driver;


        protected void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot its = (ITakesScreenshot)driver;
            Screenshot ss = its.GetScreenshot();
            string currentDirectory = Directory.GetParent(@"../../../").FullName;

            string filePath = currentDirectory + "/Screenshot/ss_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".png";
            ss.SaveAsFile(filePath);
            AllHooks.test?.AddScreenCaptureFromPath(filePath);

        }

        protected void LogTestResult(string testName, string result, string errorMessage = null)
        {


            Log.Information(result);

            if (errorMessage == null)
            {
                Log.Information(testName + "Passed");
                AllHooks.test.Pass(result);


            }
            else
            {
                Log.Error($"Test failed for{testName}.\n Exception: \n{errorMessage}");
                AllHooks.test.Fail(result);

            }
        }
        public static DefaultWait<IWebDriver> Waits(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(40);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(300);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";

            return fluentWait;
        }
        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", element);
        }

    }
}
