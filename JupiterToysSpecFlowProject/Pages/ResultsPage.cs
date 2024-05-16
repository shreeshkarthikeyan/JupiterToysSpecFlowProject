using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Pages
{
    public class ResultsPage : BasePage
    {
        public ResultsPage(IWebDriver driver) : base(driver) { }

        public string GetPaymentStatus() {
            if (ExplicitWait(driver.FindElement(By.XPath("//a[contains(text(),'Shopping Again')]")))) {
                return driver.FindElement(By.XPath("//div[contains(@class,'alert')]//strong[1]")).Text.Trim();
            }
            return null;
        }
        public string GetOrderNumber() {
            if (ExplicitWait(driver.FindElement(By.XPath("//a[contains(text(),'Shopping Again')]")))) {
                return driver.FindElement(By.XPath("//div[contains(@class,'alert')]//strong[2]")).Text.Trim();
            }
            return null;
        }
    }
}
