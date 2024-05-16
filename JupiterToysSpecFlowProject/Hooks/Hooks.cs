using JupiterToysSpecFlowProject.DataContainer;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using BoDi;
using JupiterToysSpecFlowProject.Support;

namespace JupiterToysSpecFlowProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private CommonObjects commonObjects;
        public IWebDriver driver;
        private IObjectContainer container;
        private Config config;

        public Hooks(CommonObjects commonObjects, IObjectContainer container, Config config)
        {
            this.commonObjects = commonObjects;
            this.container = container;
            this.config = config;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            if(config.readFromPropertiesFile("browser").Equals("chrome")) {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--disable-notifications");
                chromeOptions.AddArgument("--ignore-ssl-errors=yes");
                chromeOptions.AddArgument("--ignore-certificate-errors");
                driver = new ChromeDriver(chromeOptions);
                driver.Manage().Window.Maximize();
            }
            commonObjects.Driver = driver;
            container.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Quit();
        }
    }
}