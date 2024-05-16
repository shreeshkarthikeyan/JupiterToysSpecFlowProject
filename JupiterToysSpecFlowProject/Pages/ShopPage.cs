using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Pages
{
    public class ShopPage : BasePage
    {
        public ShopPage(IWebDriver driver) : base(driver) { }

        public IWebElement ToyContainer(String toy) {
            if(ExplicitWait(driver.FindElement(By.XPath("//h4[text()='" + toy + "']/..")))) {
                return driver.FindElement(By.XPath("//h4[text()='" + toy + "']/.."));
            }
            return null;
        }

        public void AddToys(string toy, int quantity) {
            if(ExplicitWait(ToyContainer(toy).FindElement(By.XPath(".//a[text()='Buy']"))))
            {
                for (int i = 0; i < quantity; i++)
                {
                    ToyContainer(toy).FindElement(By.XPath(".//a[text()='Buy']")).Click();
                    IWebElement overlayContainer = driver.FindElement(By.XPath("//div[@class=\"cdk-overlay-container\"]"));
                    ExplicitWait(overlayContainer.FindElement(By.XPath(".//span[contains(text(),'" + toy + " has been added to the cart')]")));
                    Thread.Sleep(500);
                }
            }
        }

        public decimal GetToyPrice(string toy) {
            return decimal.Parse(ToyContainer(toy).FindElement(By.XPath(".//span[contains(@class,'product-price')]"))
                                    .Text
                                    .Replace("$", ""));
        }

    }
}
