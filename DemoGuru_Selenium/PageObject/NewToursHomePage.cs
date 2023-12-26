using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGuru_Selenium.PageObject
{
    internal class NewToursHomePage
    {

        IWebDriver driver;
        public NewToursHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }



        [FindsBy(How = How.PartialLinkText, Using = "REGISTER")]
        private IWebElement? ResigsterTab { get; set; }

        public RegisterPage RegisterTabFunction()
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";

            fluentWait.Until(d=> ResigsterTab);
            ResigsterTab?.Click();
            return new RegisterPage(driver);

        }


    }
}
