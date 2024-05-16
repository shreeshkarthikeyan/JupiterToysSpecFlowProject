using JupiterToysSpecFlowProject.DataModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Pages.CheckOut
{
    public class PaymentDetailsForm : CheckOutPage
    {
        public PaymentDetailsForm(IWebDriver driver) : base(driver) { }

        public void AddPaymentDetails(PaymentDetails paymentDetails) {
            if (ExplicitWait(TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='creditcardno']")))) {
                TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='creditcardno']")).SendKeys(paymentDetails.cardNumber);
                TabContainer().FindElement(By.XPath(".//mat-select[@ng-reflect-name='creditcardtype']")).Click();
                if(ExplicitWait(driver.FindElement(By.XPath(".//mat-option[@ng-reflect-value='" + paymentDetails.cardType + "']")))) {
                    driver.FindElement(By.XPath(".//mat-option[@ng-reflect-value='" + paymentDetails.cardType + "']")).Click();
                }
                TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='creditcardname']")).SendKeys(paymentDetails.nameOnCard);
                TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='creditcardexpiry']")).SendKeys(paymentDetails.expiryDate);
                TabContainer().FindElement(By.XPath(".//input[@ng-reflect-name='creditcardcvv']")).SendKeys(paymentDetails.CVV);
            }
        }
    }
}
