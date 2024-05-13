using JupiterToysSpecFlowProject.DataModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Pages
{
    public class CheckOutPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement TabContainer(string tabName) => tabName switch
        {
            "Contact Details" => driver.FindElement(By.XPath("(//div[@role='tabpanel'])[1]")),
            "Delivery Details" => driver.FindElement(By.XPath("(//div[@role='tabpanel'])[2]")),
            "Payment Details" => driver.FindElement(By.XPath("(//div[@role='tabpanel'])[3]")),
            "Confirm Order" => driver.FindElement(By.XPath("(//div[@role='tabpanel'])[4]")),
        };

        public void AddContactDetailsInCheckOutForm(ContactDetails contactDetails)
        {
            if(ExplicitWait(TabContainer("Contact Details").FindElement(By.XPath(".//input[@ng-reflect-name='firstName']"))))
            {
                TabContainer("Contact Details").FindElement(By.XPath(".//input[@ng-reflect-name='firstName']")).SendKeys(contactDetails.firstName);
                TabContainer("Contact Details").FindElement(By.XPath(".//input[@ng-reflect-name='lastName']")).SendKeys(contactDetails.lastName);
                TabContainer("Contact Details").FindElement(By.XPath(".//input[@ng-reflect-name='email']")).SendKeys(contactDetails.email);
                TabContainer("Contact Details").FindElement(By.XPath(".//input[@ng-reflect-name='phonenumber']")).SendKeys(contactDetails.phoneNumber);
                TabContainer("Contact Details").FindElement(By.XPath(".//input[@ng-reflect-name='addressline1']")).SendKeys(contactDetails.address);
                TabContainer("Contact Details").FindElement(By.XPath(".//input[@ng-reflect-name='suburb']")).SendKeys(contactDetails.suburb);
                TabContainer("Contact Details").FindElement(By.XPath(".//mat-select[@ng-reflect-name='state']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath(".//mat-option[@ng-reflect-value='" + contactDetails.state +"']")).Click();
                TabContainer("Contact Details").FindElement(By.XPath(".//input[@ng-reflect-name='postcode']")).SendKeys(contactDetails.postcode);
            }
        }

        public void AddDeliveryDetailsInCheckOutForm(DeliveryDetails deliveryDetails)
        {
            if (ExplicitWait(TabContainer("Delivery Details").FindElement(By.XPath(".//input[@ng-reflect-name='name']"))))
            {
                if (deliveryDetails.isSameAsContactAddress) {
                    TabContainer("Delivery Details").FindElement(By.XPath(".//mat-radio-button[@value='Yes' and contains(@class,'mat-radio-button')]")).Click();
                } else {
                    TabContainer("Delivery Details").FindElement(By.XPath(".//mat-radio-button[@value='No' and contains(@class,'mat-radio-button')]")).Click();
                    Thread.Sleep(1000);
                    TabContainer("Delivery Details").FindElement(By.XPath(".//input[@ng-reflect-name='name']")).SendKeys(deliveryDetails.name);
                    TabContainer("Delivery Details").FindElement(By.XPath(".//input[@ng-reflect-name='addressline1']")).SendKeys(deliveryDetails.address);
                    TabContainer("Delivery Details").FindElement(By.XPath(".//input[@ng-reflect-name='suburb']")).SendKeys(deliveryDetails.suburb);
                    TabContainer("Delivery Details").FindElement(By.XPath(".//mat-select[@ng-reflect-name='state']")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath(".//mat-option[@ng-reflect-value='" + deliveryDetails.state + "']")).Click();
                    TabContainer("Delivery Details").FindElement(By.XPath(".//input[@ng-reflect-name='postcode']")).SendKeys(deliveryDetails.postcode);
                }
            }
        }

        public void AddPaymentDetailsInCheckOutForm(PaymentDetails paymentDetails)
        {
            if (ExplicitWait(TabContainer("Payment Details").FindElement(By.XPath(".//input[@ng-reflect-name='creditcardno']"))))
            {
                TabContainer("Payment Details").FindElement(By.XPath(".//input[@ng-reflect-name='creditcardno']")).SendKeys(paymentDetails.cardNumber);
                TabContainer("Payment Details").FindElement(By.XPath(".//mat-select[@ng-reflect-name='creditcardtype']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath(".//mat-option[@ng-reflect-value='" + paymentDetails.cardType + "']")).Click();
                TabContainer("Payment Details").FindElement(By.XPath(".//input[@ng-reflect-name='creditcardname']")).SendKeys(paymentDetails.nameOnCard);
                TabContainer("Payment Details").FindElement(By.XPath(".//input[@ng-reflect-name='creditcardexpiry']")).SendKeys(paymentDetails.expiryDate);
                TabContainer("Payment Details").FindElement(By.XPath(".//input[@ng-reflect-name='creditcardcvv']")).SendKeys(paymentDetails.CVV);
            }
        }

        public void ClickNextButton(String tab)
        {
            TabContainer(tab).FindElement(By.XPath(".//button[contains(@class,'mat-stepper-next')]")).Click();
        }
        public Boolean ExplicitWait(IWebElement element) => wait.Until(d => element.Displayed);

        public IWebElement ConfirmSectionsContainer(String sectionName)
        {
            return TabContainer("Confirm Order").FindElement(By.XPath(".//mat-panel-title[contains(text(),'"+sectionName+"')]/../../.."));
        }

        public decimal GetCartItemUnitPrice(String toy)
        {
            return decimal.Parse(ConfirmSectionsContainer("Order Details").FindElement(By.XPath(".//table/tbody//tr//td[contains(text(),'" + toy + "')]/..//td[2]"))
                .Text
                .Replace("$", "")
                .Trim());
        }
        public int GetCartItemQuanity(String toy)
        {
            return int.Parse(ConfirmSectionsContainer("Order Details").FindElement(By.XPath(".//table/tbody//tr//td[contains(text(),'" + toy + "')]/..//td[3]"))
               .Text
               .Trim());
        }
        public decimal GetCartItemSubTotal(String toy)
        {
            return decimal.Parse(ConfirmSectionsContainer("Order Details").FindElement(By.XPath(".//table/tbody//tr//td[contains(text(),'" + toy + "')]/..//td[4]"))
                .Text
                .Replace("$", "")
                .Trim());
        }
        public int GetNumberOfCartItems()
        {
            return ConfirmSectionsContainer("Order Details").FindElements(By.XPath(".//table/tbody//tr")).Count;
        }

        public string GetDName()
        {
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Name')][1]/following-sibling::td[1]"))
                .Text
                .Trim();
        }
        public string GetCName()
        {
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Name')][2]/following-sibling::td[1]"))
                .Text
                .Trim();
        }
        public string GetDAddress()
        {
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Address')][1]/following-sibling::td[1]"))
                .Text
                .Trim();
        }
        public string GetCAddress()
        {
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Address')][2]/following-sibling::td[1]"))
                .Text
                .Trim();
        }

        public string GetCEmailAddress()
        {
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Email')][1]/following-sibling::td[1]"))
                .Text
                .Trim();
        }

        public string GetCNumber()
        {
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Phone')][1]/following-sibling::td[1]"))
                .Text
                .Trim();
        }
        public string GetCardName()
        {
            return ConfirmSectionsContainer("Payment Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Card Name')]/following-sibling::td[1]"))
                .Text
                .Trim();
        }
        public string GetCardNumber()
        {
            return ConfirmSectionsContainer("Payment Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Card Number')]/following-sibling::td[1]"))
                .Text
                .Trim();
        }
        public string GetCardType()
        {
            return ConfirmSectionsContainer("Payment Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Card Type')]/following-sibling::td[1]"))
                .Text
                .Trim();
        }
        public string GetCardExpiry()
        {
            return ConfirmSectionsContainer("Payment Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Card Expiry')]/following-sibling::td[1]"))
                .Text
                .Trim();
        }
        public string GetCardCVV()
        {
            return ConfirmSectionsContainer("Payment Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Card CVV')]/following-sibling::td[1]"))
                .Text
                .Trim();
        }
        public void ClickEpandAllButton()
        {
            if(ExplicitWait(driver.FindElement(By.XPath("//button[.//text()='Expand All']"))))
            {
                driver.FindElement(By.XPath("//button[.//text()='Expand All']")).Click();
                Thread.Sleep(2000);
            }
        }
        public void ClickSubmitOrderButton()
        {
            if (ExplicitWait(driver.FindElement(By.XPath("//button[.//text()='Submit Order']"))))
            {
                driver.FindElement(By.XPath("//button[.//text()='Submit Order']")).Click();
                Thread.Sleep(2000);
            }
        }
    }
}
