using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        public IWebElement ToyRowContainer(String toy) {
            if(ExplicitWait(driver.FindElement(By.XPath("//td[text()=' " + toy + " ']/.."))))
            {
                return driver.FindElement(By.XPath("//td[text()=' " + toy + " ']/.."));
            }
            return null;
        }

        public string GetToyQuantity(String toy) {
            return ToyRowContainer(toy)
                    .FindElement(By.XPath(".//input"))
                    .GetAttribute("value");
        }

        public string GetTotalPrice() {
            if(ExplicitWait(driver.FindElement(By.XPath("//td[contains(@class,'column-total')]/strong"))))
            {
                return driver.FindElement(By.XPath("//td[contains(@class,'column-total')]/strong"))
                    .Text;
            }
            return null;
        }

        public string GetToyPrice(string toy) {
            return ToyRowContainer(toy).FindElement(By.XPath(".//td[4]"))
                    .Text;
        }

        public void ClickCheckOutButton() {
            if(ExplicitWait(driver.FindElement(By.XPath("//a[contains(@class,'btn-checkout')]"))))
            {
                driver.FindElement(By.XPath("//a[contains(@class,'btn-checkout')]")).Click();
            }
        }
    }
}
