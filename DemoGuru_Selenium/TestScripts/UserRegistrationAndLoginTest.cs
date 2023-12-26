using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoGuru_Selenium.PageObject;
using DemoGuru_Selenium.Helper;
using DemoGuru_Selenium.Utilities;
using AventStack.ExtentReports.Gherkin.Model;

namespace DemoGuru_Selenium.TestScripts
{
    [TestFixture]
    internal class UserRegistrationAndLoginTest : CoreCodes
    {
        [Test, Order(1)]

        [Category("Regression Testing")]

        [TestCase("273595")] //parameterisation
        public void UserRegistrationLoginTest(string pincode)
        {
            test = extent.CreateTest("User Register Test");
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(50);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(300);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";


            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();


            NewToursHomePage registeration = new(driver);


            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "NewTours";

            List<InputDatas> excelDataList = ExcelUtils.ReadSearchDataExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? firstname = excelData?.Firstname;
                string? lastname = excelData?.Lastname;
                string? phonenumber = excelData?.PhoneNumber;
                string? email = excelData?.Email;
                string? address = excelData?.Address;
                string? city = excelData?.City;
              
                string? state = excelData?.State;
                string? country = excelData?.Country;
                string? username = excelData?.Username;
                string? password = excelData?.Password;
                string? confirmpassword = excelData?.ConfirmPassword;


                try
                {
                    test = extent.CreateTest("User Register and Login Test ");


                    var register = fluentWait.Until(d => registeration.RegisterTabFunction());
                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("register"));
                    Log.Information("Clicked on Registeration Page");


                    var loginPage = fluentWait.Until(d => register.RegisterFunction(firstname, lastname, phonenumber, email, address, city, state, country,
                        pincode, username, password, confirmpassword));

                    Log.Information("Entered the user details");
                    test.Info("Entered the user details");

                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("register_sucess"));
                    Log.Information(" Successfully  Registered");



                    fluentWait.Until(d => loginPage);

                    loginPage.Login(username, password);

                    Log.Information("Successfully Logined");

                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("login_sucess"));
                    Log.Information(" Successfully  Logined");
                    test.Info("Successfully Logined");


                }
                catch (AssertionException ex)
                {

                    LogTestResult("User Register",
                      "User Register", ex.Message);



                }


            }
        }
    }
}
