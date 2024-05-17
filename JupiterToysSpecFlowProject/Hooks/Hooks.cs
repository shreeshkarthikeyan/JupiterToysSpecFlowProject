using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using BoDi;
using JupiterToysSpecFlowProject.Support;
using JupiterToysSpecFlowProject.DataModel;

namespace JupiterToysSpecFlowProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        public IWebDriver driver;
        public Dictionary<string, Toy> cartItems;
        private IObjectContainer container;
        private Config config;

        public Hooks(IObjectContainer container, Config config)
        {
            this.container = container;
            this.config = config;
            cartItems = new Dictionary<string, Toy>();
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
            container.RegisterInstanceAs<IWebDriver>(driver);
            container.RegisterInstanceAs<Dictionary<string, Toy>>(cartItems);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Quit();
        }
    }
}