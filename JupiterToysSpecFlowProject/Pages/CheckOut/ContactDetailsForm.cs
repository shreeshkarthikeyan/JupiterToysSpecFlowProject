using JupiterToysSpecFlowProject.DataModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Pages.CheckOut
{
    public class ContactDetailsForm : CheckOutPage
    {
        public ContactDetailsForm(IWebDriver driver) : base(driver) { }

        public void AddContactDetails(ContactDetails contactDetails)
        {
            if (ExplicitWait(TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='firstName']"))))
            {
                TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='firstName']")).SendKeys(contactDetails.firstName);
                TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='lastName']")).SendKeys(contactDetails.lastName);
                TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='email']")).SendKeys(contactDetails.email);
                TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='phonenumber']")).SendKeys(contactDetails.phoneNumber);
                TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='addressline1']")).SendKeys(contactDetails.address);
                TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='suburb']")).SendKeys(contactDetails.suburb);
                TabContainer().FindElement(By.XPath(".//mat-select[@ng-reflect-name='state']")).Click();
                if(ExplicitWait(driver.FindElement(By.XPath(".//mat-option[@ng-reflect-value='" + contactDetails.state + "']")))) {
                    driver.FindElement(By.XPath(".//mat-option[@ng-reflect-value='" + contactDetails.state + "']")).Click();
                }
                TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='postcode']")).SendKeys(contactDetails.postcode);
            }
        }
    }
}
