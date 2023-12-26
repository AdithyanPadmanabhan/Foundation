using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGuru_Selenium.PageObject
{
    internal class RegisterPage
    {


        IWebDriver driver;
        public RegisterPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }

        //used different types of locators

        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement? FirstNameInput { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
        private IWebElement? LastNameInput { get; set; }


        [FindsBy(How = How.CssSelector, Using = "input[name='phone']")]
        private IWebElement? PhoneNumberInput { get; set; }


        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement? EmailInput { get; set; }


        [FindsBy(How = How.Name, Using = "address1")]
        private IWebElement? AddressInput { get; set; }



        [FindsBy(How = How.XPath, Using = "//input[@name='city']")]
        private IWebElement? CityInput { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name='state']")]
        private IWebElement? StateInput { get; set; }



        [FindsBy(How = How.Name, Using = "postalCode")]
        private IWebElement? PincodeInput { get; set; }


        [FindsBy(How = How.XPath, Using = "//select[@name='country']")]
        private IWebElement? CountrySelection { get; set; }



        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement? UserName { get; set; }



        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement? PasswordInput { get; set; }

        [FindsBy(How = How.Name, Using = "confirmPassword")]
        private IWebElement? ConfirmPassword { get; set; }

        [FindsBy(How = How.Name, Using = "submit")]
        private IWebElement? Submit { get; set; }



       public UserLogin RegisterFunction(string firstname,string lastname,
           string phonenumber,string email,string address,
           string city, string state, string country,  string pincode,string username, 
           string password, string confirmpassword)
        {


            FirstNameInput?.SendKeys(firstname);
            LastNameInput?.SendKeys(lastname);
            PhoneNumberInput?.SendKeys(phonenumber);
            EmailInput?.SendKeys(email);
            AddressInput?.SendKeys(address);
            CityInput?.SendKeys(city);
            StateInput?.SendKeys(state);
            CountrySelection?.SendKeys(country);

            PincodeInput?.SendKeys(pincode);
            UserName?.SendKeys(username);
            PasswordInput?.SendKeys(password);
            ConfirmPassword?.SendKeys(confirmpassword);

            Submit?.Click();
            

            return new UserLogin(driver);
        }





    }
}
