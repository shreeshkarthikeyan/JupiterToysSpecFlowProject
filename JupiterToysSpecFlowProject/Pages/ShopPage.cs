using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Pages
{
    public class ShopPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public ShopPage(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement ToyContainer(String toy)
        {
            if(ExplicitWait(driver.FindElement(By.XPath("//h4[text()='" + toy + "']/..")))) {
                return driver.FindElement(By.XPath("//h4[text()='" + toy + "']/.."));
            }
            return null;
        }

        public void AddToys(string toy, int quantity)
        {
            if(ExplicitWait(ToyContainer(toy).FindElement(By.XPath(".//a[text()='Buy']"))))
            {
                for (int i = 0; i < quantity; i++)
                {
                    ToyContainer(toy).FindElement(By.XPath(".//a[text()='Buy']")).Click();
                    Thread.Sleep(2000);
                }
            }
        }

        public decimal GetToyPrice(string toy)
        {
            return decimal.Parse(ToyContainer(toy).FindElement(By.XPath(".//span[contains(@class,'product-price')]"))
                                    .Text
                                    .Replace("$", ""));
        }

        public Boolean ExplicitWait(IWebElement element) => wait.Until(d => element.Displayed);
    }
}
