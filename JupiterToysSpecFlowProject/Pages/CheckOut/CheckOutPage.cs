using JupiterToysSpecFlowProject.DataModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Pages.CheckOut
{
    public class CheckOutPage : BasePage
    {
        public CheckOutPage(IWebDriver driver) : base(driver) { }
        public IWebElement CheckOutPageContainer() {
            return driver.FindElement(By.XPath("//app-checkout"));
        }
        public IWebElement TabContainer() {
            return CheckOutPageContainer().FindElement(By.CssSelector("div[style*='visibility: inherit;']"));
        }
        public void ClickNextButton() {
            TabContainer().FindElement(By.XPath(".//button[contains(@class,'mat-stepper-next')]")).Click();
        }
        public void AddContactDetailsInCheckOutForm(ContactDetails contactDetails) {
            new ContactDetailsForm(driver).AddContactDetails(contactDetails);
        }
        public void AddDeliveryDetailsInCheckOutForm(DeliveryDetails deliveryDetails) {
            new DeliveryDetailsForm(driver).AddDeliveryDetails(deliveryDetails);
        }
        public void AddPaymentDetailsInCheckOutForm(PaymentDetails paymentDetails) {
            new PaymentDetailsForm(driver).AddPaymentDetails(paymentDetails);
        }
    }
}
