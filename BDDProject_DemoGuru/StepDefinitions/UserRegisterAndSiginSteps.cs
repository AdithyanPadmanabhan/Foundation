using BDDProject_DemoGuru.Hooks;
using BDDProject_DemoGuru.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BDDProject_DemoGuru.StepDefinitions
{
    [Binding]
    public class UserRegisterAndSiginSteps : CoreCodes


    {

        IWebDriver? driver = AllHooks.driver;
        [When(@"User will click on the Register tab")]
        public void WhenUserWillClickOnTheRegisterTab()
        {


            IWebElement register = driver.FindElement(By.PartialLinkText("REGISTER"));
            register?.Click();
            Log.Information("Clicked on register tab");
        }

        [Then(@"User will be on register page")]
        public void ThenUserWillBeOnRegisterPage()
        {
            AllHooks.test = AllHooks.extent.CreateTest("User Register and Sigin  Test ");

            try
            {
                TakeScreenShot(driver);


                Assert.That(driver.Url.Contains("register"));
                Log.Information("User in Registeration Page");
                AllHooks.test.Info("User in Registeration Page");
            }
            catch (AssertionException ex)
            {

                LogTestResult("Registeration Test",
                  "Registeration failed", ex.Message);

            }
        }

        [When(@"user will enter first name '([^']*)'")]
        public void WhenUserWillEnterFirstName(string firstname)
        {
            var fluentWait = Waits(driver);
            IWebElement firstnameInput = fluentWait.Until(d => d.FindElement(By.Name("firstName")));
            firstnameInput?.SendKeys(firstname);
            AllHooks.test.Info("First name Details  entered");
            Log.Information("First name Details  entered");
        }

        [When(@"user will enter last name '([^']*)'")]
        public void WhenUserWillEnterLastName(string lastname)
        {
            var fluentWait = Waits(driver);
            IWebElement lastnameInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@name='lastName']")));
            lastnameInput?.SendKeys(lastname);
            AllHooks.test.Info("last name Details  entered");
            Log.Information("last name Details  entered");
        }

        [When(@"user will enter  phone number'([^']*)'")]
        public void WhenUserWillEnterPhoneNumber(string phonenumber)
        {
            var fluentWait = Waits(driver);

            IWebElement phonenumberInput = fluentWait.Until(d => d.FindElement(By.CssSelector("input[name='phone']")));
            phonenumberInput?.SendKeys(phonenumber);
        }

        [When(@"user will enter  email'([^']*)'")]
        public void WhenUserWillEnterEmail(string email)
        {
            var fluentWait = Waits(driver);

            IWebElement phonenumberInput = fluentWait.Until(d => d.FindElement(By.Id("userName")));
            phonenumberInput?.SendKeys(email);
        }

        [When(@"user will enter  address'([^']*)'")]
        public void WhenUserWillEnterAddress(string address)
        {
            var fluentWait = Waits(driver);

            IWebElement addressInput = fluentWait.Until(d => d.FindElement(By.Name("address1")));
            addressInput?.SendKeys(address);
        }

        [When(@"user will enter  city'([^']*)'")]
        public void WhenUserWillEnterCity(string city)
        {
            var fluentWait = Waits(driver);

            IWebElement cityInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@name='city']")));
            cityInput?.SendKeys(city);
        }

        [When(@"user will enter  state'([^']*)'")]
        public void WhenUserWillEnterState(string state)
        {
            var fluentWait = Waits(driver);

            IWebElement stateInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@name='state']")));
            stateInput?.SendKeys(state);
        }

        [When(@"user will enter  country'([^']*)'")]
        public void WhenUserWillEnterCountry(string country)
        {
            var fluentWait = Waits(driver);

            IWebElement countryInput = fluentWait.Until(d => d.FindElement(By.XPath("//select[@name='country']")));
            countryInput?.SendKeys(country);
        }

        [When(@"user will enter  pincode'([^']*)'")]
        public void WhenUserWillEnterPincode(string pincode)
        {
            var fluentWait = Waits(driver);

            IWebElement pincodeInput = fluentWait.Until(d => d.FindElement(By.Name("postalCode")));
            pincodeInput?.SendKeys(pincode);
        }

        [When(@"user will enter  username  '([^']*)'")]
        public void WhenUserWillEnterUsername(string username)
        {
            var fluentWait = Waits(driver);

            IWebElement usernameInput = fluentWait.Until(d => d.FindElement(By.Id("email")));
            usernameInput?.SendKeys(username);
        }

        [When(@"user will enter  password  '([^']*)'")]
        public void WhenUserWillEnterPassword(string password)
        {
            var fluentWait = Waits(driver);

            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Name("password")));
            passwordInput?.SendKeys(password);
        }

        [When(@"user will enter Confirm password  '([^']*)'")]
        public void WhenUserWillEnterConfirmPassword(string confirmpassword)
        {
            var fluentWait = Waits(driver);

            IWebElement confirmpasswordInput = fluentWait.Until(d => d.FindElement(By.Name("confirmPassword")));
            confirmpasswordInput?.SendKeys(confirmpassword);
        }

        [When(@"user click on submit")]
        public void WhenUserClickOnSubmit()
        {
            var fluentWait = Waits(driver);

            IWebElement submitButton = fluentWait.Until(d => d.FindElement(By.Name("submit")));
            submitButton?.Click();
        }

        [Then(@"user will be on sigin page")]
        public void ThenUserWillBeOnSiginPage()
        {
            try
            {
                TakeScreenShot(driver);


                Assert.That(driver.Url.Contains("register_sucess"));
                Log.Information(" Successfully  Registered");
            }
            catch (AssertionException ex)
            {

                LogTestResult("Registeration Test",
                  "Registeration failed", ex.Message);

            }


        }

        [When(@"User will click on sigin")]
        public void WhenUserWillClickOnSigin()
        {
            var fluentWait = Waits(driver);

            IWebElement sigin = fluentWait.Until(d => d.FindElement(By.XPath("//a[normalize-space()='sign-in']")));
            sigin?.Click();
        }

        [When(@"user will enter  usernames  '([^']*)'")]
        public void WhenUserWillEnterUsernames(string username)
        {
            var fluentWait = Waits(driver);

            IWebElement usernameInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@name='userName']")));
            usernameInput?.SendKeys(username);
        }



        [Then(@"user will successfully login into the page")]
        public void ThenUserWillSuccessfullyLoginIntoThePage()
        {
            try
            {
                TakeScreenShot(driver);
                Assert.That(driver.Url.Contains("login_sucess"));
                Log.Information(" Successfully  Logined");
                AllHooks.test.Info("Successfully Logined");

            }

            catch (AssertionException ex)
            {

                LogTestResult("User Register",
                  "User Register", ex.Message);


            }
        }
    }



}
    

