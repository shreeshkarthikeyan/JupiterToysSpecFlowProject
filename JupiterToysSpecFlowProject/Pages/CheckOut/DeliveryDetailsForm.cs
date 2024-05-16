using JupiterToysSpecFlowProject.DataModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Pages.CheckOut
{
    public class DeliveryDetailsForm : CheckOutPage
    {
        public DeliveryDetailsForm(IWebDriver driver) : base(driver) { }

        public void AddDeliveryDetails(DeliveryDetails deliveryDetails) {
            if (ExplicitWait(TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='name']")))) {
                if (deliveryDetails.isSameAsContactAddress) {
                    TabContainer().FindElement(By.XPath(".//mat-radio-button[@value='Yes' and contains(@class,'mat-radio-button')]")).Click();
                }
                else {
                    do{
                        TabContainer().FindElement(By.XPath(".//mat-radio-button[@value='No' and contains(@class,'mat-radio-button')]")).Click();
                    } while (TabContainer().FindElement(By.XPath(".//mat-radio-button[contains(@class,'mat-radio-checked')]")).GetAttribute("value").Equals("No"));
                    TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='name']")).SendKeys(deliveryDetails.name);
                    TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='addressline1']")).SendKeys(deliveryDetails.address);
                    TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='suburb']")).SendKeys(deliveryDetails.suburb);
                    TabContainer().FindElement(By.XPath(".//mat-select[@ng-reflect-name='state']")).Click();
                    if(ExplicitWait(driver.FindElement(By.XPath(".//mat-option[@ng-reflect-value='" + deliveryDetails.state + "']")))) {
                        driver.FindElement(By.XPath(".//mat-option[@ng-reflect-value='" + deliveryDetails.state + "']")).Click();
                    }
                    TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='postcode']")).SendKeys(deliveryDetails.postcode);
                }
            }
        }
    }
}
