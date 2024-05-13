using JupiterToysSpecFlowProject.DataContainer;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace JupiterToysSpecFlowProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private CommonObjects commonObjects;
        private IWebDriver driver;

        public Hooks(CommonObjects commonObjects)
        {
            this.commonObjects = commonObjects;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");
            chromeOptions.AddArgument("--ignore-ssl-errors=yes");
            chromeOptions.AddArgument("--ignore-certificate-errors");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            commonObjects.Driver = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Quit();
        }
    }
}