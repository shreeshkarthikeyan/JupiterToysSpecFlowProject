using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Pages
{
    public class CartPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public CartPage(IWebDriver driver) 
        { 
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement ToyRowContainer(String toy)
        {
            if(ExplicitWait(driver.FindElement(By.XPath("//td[text()=' " + toy + " ']/.."))))
            {
                return driver.FindElement(By.XPath("//td[text()=' " + toy + " ']/.."));
            }
            return null;          
        }

        public int GetToyQuantity(String toy)
        {
            return int.Parse(ToyRowContainer(toy).FindElement(By.XPath(".//input")).GetAttribute("value"));
        }

        public decimal GetTotalPrice()
        {
            if(ExplicitWait(driver.FindElement(By.XPath("//td[contains(@class,'column-total')]/strong"))))
            {
                return decimal.Parse(driver.FindElement(By.XPath("//td[contains(@class,'column-total')]/strong")).Text.Replace("Total ", "").Trim());
            }
            return Decimal.Zero;
        }

        public decimal GetToyPrice(String toy)
        {
            return decimal.Parse(ToyRowContainer(toy).FindElement(By.XPath(".//td[4]")).Text.Replace("$", "").Trim());
        }

        public void ClickCheckOutButton()
        {
            if(ExplicitWait(driver.FindElement(By.XPath("//a[contains(@class,'btn-checkout')]"))))
            {
                driver.FindElement(By.XPath("//a[contains(@class,'btn-checkout')]")).Click();
            }
        }
        public Boolean ExplicitWait(IWebElement element) => wait.Until(d => element.Displayed);
    }
}
