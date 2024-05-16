using JupiterToysSpecFlowProject.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace JupiterToysSpecFlowProject.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        private IWebElement homeMenuBar;
        private IWebElement shopMenuBar;
        private IWebElement cartMenuBar;
        private IWebElement menuBarExpander;
        private IWebElement menuBarContainer;
        private IWebElement contactMenuBar;
        private IWebElement loginMenuBar;

        public BasePage(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));            
        }

        public IWebElement ToolBarContainer()
        {
            return driver.FindElement(By.XPath("//mat-toolbar"));
        }
        public void ClickShopButton()
        {
            shopMenuBar = ToolBarContainer().FindElement(By.XPath(".//button[.//text()='Shop']"));
            if (ExplicitWait(shopMenuBar)) {
                shopMenuBar.Click();
            }
        }
        public void ClickHomeButton()
        {
            homeMenuBar = ToolBarContainer().FindElement(By.XPath(".//button[.//text()='Home']"));
            if (ExplicitWait(homeMenuBar)) {
                homeMenuBar.Click();
            }
        }

        public void ClickCartButton()
        {
            cartMenuBar = ToolBarContainer().FindElement(By.XPath(".//button[.//text()='Cart']"));
            if (ExplicitWait(cartMenuBar)) {
                cartMenuBar.Click();
            }
        }

        public void ClickContactButton()
        {
            menuBarExpander = ToolBarContainer().FindElement(By.XPath(".//button[contains(@class,'mat-menu-trigger mat-icon-button')]"));
            if (ExplicitWait(menuBarExpander)) {
                menuBarExpander.Click();
                menuBarContainer = driver.FindElement(By.XPath(".//div[contains(@class, 'mat-menu-panel')]"));
                contactMenuBar = menuBarContainer.FindElement(By.XPath(".//button[.//text()='Contact']"));
                if (ExplicitWait(contactMenuBar)){
                    contactMenuBar.Click();
                }
            }
        }

        public void ClickLoginButton()
        {
            menuBarExpander = ToolBarContainer().FindElement(By.XPath(".//button[contains(@class,'mat-menu-trigger mat-icon-button')]"));
            if(ExplicitWait(menuBarExpander)) {
                menuBarExpander.Click();
                menuBarContainer = driver.FindElement(By.XPath(".//div[contains(@class, 'mat-menu-panel')]"));
                loginMenuBar = menuBarContainer.FindElement(By.XPath(".//button[.//text()='Login']"));
                if (ExplicitWait(loginMenuBar)) {
                    loginMenuBar.Click();
                }
            }
        }

        public Boolean ExplicitWait(IWebElement element) => wait.Until(d => element.Displayed);
        public void NavigateUrl() {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = new Config().readFromPropertiesFile("url");
        }
    }
}
