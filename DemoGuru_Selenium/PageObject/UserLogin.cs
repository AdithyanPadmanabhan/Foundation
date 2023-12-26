using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGuru_Selenium.PageObject
{
    internal class UserLogin
    {
        IWebDriver driver;
        public UserLogin(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }

      

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='sign-in']")]
        private IWebElement? Sigin { get; set; }



        [FindsBy(How = How.XPath, Using = "//input[@name='userName']")]
        private IWebElement? UserName { get; set; }


        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement? PasswordInput { get; set; }

        [FindsBy(How = How.Name, Using = "submit")]
        private IWebElement? Submit { get; set; }


        public void Login(string username, string password)
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";

            fluentWait.Until(d => Sigin);
            Sigin?.Click();
            
           

            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(),'User')]")));
          
            UserName?.SendKeys(username);
            fluentWait.Until(d => PasswordInput);
            PasswordInput?.SendKeys(password);
            Submit?.Click();


        }

    }
}
