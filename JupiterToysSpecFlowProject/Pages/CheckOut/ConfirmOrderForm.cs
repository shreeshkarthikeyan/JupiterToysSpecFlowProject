using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Pages.CheckOut
{
    public class ConfirmOrderForm : CheckOutPage
    {
        public ConfirmOrderForm(IWebDriver driver) : base(driver){ }
        public IWebElement ConfirmSectionsContainer(string sectionName) {
            return TabContainer().FindElement(By.XPath(".//mat-panel-title[contains(text(),'" + sectionName + "')]/../../.."));
        }
        public string GetCartItemUnitPrice(string toy) {
            return ConfirmSectionsContainer("Order Details").FindElement(By.XPath(".//table/tbody//tr//td[contains(text(),'" + toy + "')]/..//td[2]"))
                .Text;
        }
        public string GetCartItemQuanity(string toy) {
            return ConfirmSectionsContainer("Order Details").FindElement(By.XPath(".//table/tbody//tr//td[contains(text(),'" + toy + "')]/..//td[3]"))
               .Text;
        }
        public string GetCartItemSubTotal(string toy) {
            return ConfirmSectionsContainer("Order Details").FindElement(By.XPath(".//table/tbody//tr//td[contains(text(),'" + toy + "')]/..//td[4]"))
                .Text;
        }
        public int GetNumberOfCartItems() {
            return ConfirmSectionsContainer("Order Details").FindElements(By.XPath(".//table/tbody//tr")).Count;
        }
        public string GetDName() {
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Name')][1]/following-sibling::td[1]"))
                .Text;
        }
        public string GetCName() {
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Name')][2]/following-sibling::td[1]"))
                .Text;
        }
        public string GetDAddress() {
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Address')][1]/following-sibling::td[1]"))
                .Text;
        }
        public string GetCAddress() { 
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Address')][2]/following-sibling::td[1]"))
                .Text;
        }
        public string GetCEmailAddress() {
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Email')][1]/following-sibling::td[1]"))
                .Text;
        }
        public string GetCNumber() {
            return ConfirmSectionsContainer("Delivery & Contact Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Phone')][1]/following-sibling::td[1]"))
                .Text;
        }
        public string GetCardName() {
            return ConfirmSectionsContainer("Payment Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Card Name')]/following-sibling::td[1]"))
                .Text;
        }
        public string GetCardNumber() {
            return ConfirmSectionsContainer("Payment Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Card Number')]/following-sibling::td[1]"))
                .Text;
        }
        public string GetCardType() {
            return ConfirmSectionsContainer("Payment Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Card Type')]/following-sibling::td[1]"))
                .Text;
        }
        public string GetCardExpiry() {
            return ConfirmSectionsContainer("Payment Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Card Expiry')]/following-sibling::td[1]"))
                .Text;
        }
        public string GetCardCVV() {
            return ConfirmSectionsContainer("Payment Details").FindElement(By.XPath(".//table//tr//td[contains(text(),'Card CVV')]/following-sibling::td[1]"))
                .Text;
        }
        public void ClickExpandAllButton() {
            if (ExplicitWait(TabContainer().FindElement(By.XPath("//button[.//text()='Expand All']")))) {
                TabContainer().FindElement(By.XPath("//button[.//text()='Expand All']")).Click();

                //check if all the sections are expanded
                IList<IWebElement> sections = TabContainer().FindElements(By.XPath("//mat-expansion-panel"));
                int i = 1;
                IWebElement sectionHeader = null;
                foreach (IWebElement section in sections) {                   
                    if (i == 1) { sectionHeader = TabContainer().FindElement(By.XPath("//mat-expansion-panel[contains(@class,\"mat-expanded\")]//mat-expansion-panel-header[.//*[contains(text(),\"Order Details\")]]")); }
                    else if (i == 2) { sectionHeader = TabContainer().FindElement(By.XPath("//mat-expansion-panel[contains(@class,\"mat-expanded\")]//mat-expansion-panel-header[.//*[contains(text(),\"Delivery & Contact Details\")]]")); }
                    else if (i == 3) { sectionHeader = TabContainer().FindElement(By.XPath("//mat-expansion-panel[contains(@class,\"mat-expanded\")]//mat-expansion-panel-header[.//*[contains(text(),\"Payment Details\")]]")); }              
                    
                    if (!section.GetAttribute("class").Contains("mat-expanded")){
                        _ = ExplicitWait(sectionHeader);
                        Console.WriteLine($"{i}th count");
                    }
                    i++;
                }
            }
        }
        public void ClickSubmitOrderButton() {
            if (ExplicitWait(TabContainer().FindElement(By.XPath("//button[.//text()='Submit Order']")))) {
                TabContainer().FindElement(By.XPath("//button[.//text()='Submit Order']")).Click();
            }
        }
    }
}
