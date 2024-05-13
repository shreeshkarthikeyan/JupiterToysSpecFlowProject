using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace JupiterToysSpecFlowProject.Pages
{
    public class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IWebElement homeMenuBar;
        private IWebElement shopMenuBar;
        private IWebElement cartMenuBar;
        private IWebElement menuBarExpander;
        private IWebElement contactMenuBar;
        private IWebElement loginMenuBar;

        public BasePage(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));            
        }

        public void ClickShopButton()
        {
            shopMenuBar = driver.FindElement(By.XPath(".//button[@ng-reflect-router-link='/toy-list' and contains(@class,'nav-link')]"));
            if (ExplicitWait(shopMenuBar)) {
                shopMenuBar.Click();
            }
        }
        public void ClickCartButton()
        {
            
            cartMenuBar = driver.FindElement(By.XPath(".//button[@ng-reflect-router-link='/cart' and contains(@class,'nav-link')]"));
            if (ExplicitWait(cartMenuBar)) {
                cartMenuBar.Click();
            }
        }

        public void ClickContactButton()
        {
            menuBarExpander = driver.FindElement(By.XPath(".//button[contains(@class,'mat-menu-trigger mat-icon-button')]"));
            contactMenuBar = driver.FindElement(By.XPath("//button[@ng-reflect-router-link='/contact' and contains(@class,'nav-link')]"));
            if (ExplicitWait(menuBarExpander)) {
                menuBarExpander.Click();
                if (ExplicitWait(contactMenuBar)){
                    contactMenuBar.Click();
                }
            }
        }

        public void ClickLoginButton()
        {
            menuBarExpander = driver.FindElement(By.XPath(".//button[contains(@class,'mat-menu-trigger mat-icon-button')]"));
            loginMenuBar = driver.FindElement(By.XPath("//button[@role='menuitem']//*[text()='Login']"));
            if (ExplicitWait(menuBarExpander))
            {
                menuBarExpander.Click();
                if (ExplicitWait(loginMenuBar))
                {
                    loginMenuBar.Click();
                }
            }
        }
        public Boolean ExplicitWait(IWebElement element) => wait.Until(d => element.Displayed);
        public void NavigateUrl()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://ec2-54-206-101-9.ap-southeast-2.compute.amazonaws.com:5200/home";
        }
    }
}
