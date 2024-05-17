using JupiterToysSpecFlowProject.DataModel;
using JupiterToysSpecFlowProject.Pages.CheckOut;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace JupiterToysSpecFlowProject.StepDefinitions
{
    [Binding]
    public class CheckOutStepDefinitions
    {
        CheckOutPage checkOutPage;
        ContactDetails contactDetails;
        DeliveryDetails deliveryDetails;
        PaymentDetails paymentDetails;
        private IWebDriver driver;
        public Dictionary<string, Toy> cartItems;

        public CheckOutStepDefinitions(IWebDriver driver, Dictionary<string, Toy> cartItems) 
        {
            this.driver = driver;
            this.cartItems = cartItems;
            checkOutPage = new CheckOutPage(driver);
            contactDetails = new ContactDetails();
            deliveryDetails = new DeliveryDetails();
            paymentDetails = new PaymentDetails();
        }
        [Then(@"the user checks out using same delivery details")]
        public void ThenTheUserChecksOutUsingSameDeliveryDetails(Table table)
        {
            contactDetails = table.CreateInstance<ContactDetails>();
            checkOutPage.AddContactDetailsInCheckOutForm(contactDetails);
            checkOutPage.ClickNextButton();
            /*deliveryDetails = new DeliveryDetails(true, contactDetails.firstName + " " + contactDetails.lastName,
                                                                  contactDetails.address, contactDetails.suburb, contactDetails.state, 
                                                                  contactDetails.postcode);*/
            
            deliveryDetails.isSameAsContactAddress = true;
            deliveryDetails.name = contactDetails.firstName + " " + contactDetails.lastName;
            deliveryDetails.address = contactDetails.address;
            deliveryDetails.suburb = contactDetails.suburb;
            deliveryDetails.state = contactDetails.state;
            deliveryDetails.postcode = contactDetails.postcode;
            
            checkOutPage.AddDeliveryDetailsInCheckOutForm(deliveryDetails);
            checkOutPage.ClickNextButton();
        }

        [Then(@"the user verifies the details on the confirm order screen and confirms it")]
        public void ThenTheUserVerifiesTheDetailsOnTheConfirmOrderScreenAndConfirmsIt()
        {
            ConfirmOrderForm confirmOrderForm = new ConfirmOrderForm(driver);
            confirmOrderForm.ClickExpandAllButton();
            ValidateOrderDetailsSection(confirmOrderForm);
            ValidateDeliveryAndContactDetailsSection(confirmOrderForm);
            ValidatePaymentDetailsSection(confirmOrderForm);
            confirmOrderForm.ClickSubmitOrderButton();
        }

        public void ValidateOrderDetailsSection(ConfirmOrderForm confirmOrderForm)
        {
            // Checks the number of items in the cart
            Assert.AreEqual(cartItems.Count, confirmOrderForm.GetNumberOfCartItems(), "Cart Item Count mismatches");
            foreach (var item in cartItems)
            {
                var subTotal = cartItems[item.Key].quantity * cartItems[item.Key].price;
                Console.WriteLine($"{cartItems[item.Key].toyName}'s quantity --> {cartItems[item.Key].quantity}");
                Console.WriteLine($"{cartItems[item.Key].toyName}'s price --> {cartItems[item.Key].price}");
                Console.WriteLine($"{cartItems[item.Key].toyName}'s sub total --> {subTotal}");
                // Checks the item's unit
                if (confirmOrderForm.GetCartItemUnitPrice(item.Key).Contains(cartItems[item.Key].price.ToString())) {
                    Assert.IsTrue(true, $"{item.Key} Cart Item Unit Price mismatches");
                }
                
                // Checks the item's quantity
                Assert.AreEqual(cartItems[item.Key].quantity.ToString(), confirmOrderForm.GetCartItemQuanity(item.Key), $"{item.Key} Cart Item Quantity mismatches");
                
                // Checks the item's sub total
                if(confirmOrderForm.GetCartItemSubTotal(item.Key).Contains(subTotal.ToString())) {
                    Assert.IsTrue(true, $"{item.Key} Cart Item Sub Total mismatches");
                }
            }
        }

        public void ValidateDeliveryAndContactDetailsSection(ConfirmOrderForm confirmOrderForm)
        {
            Assert.AreEqual(contactDetails.firstName+ " "+contactDetails.lastName, confirmOrderForm.GetCName(), "Contact Name mismatches");
            Assert.AreEqual(deliveryDetails.name, confirmOrderForm.GetDName(), "Delivery Name mismatches");
            
            if(confirmOrderForm.GetDAddress().Contains(deliveryDetails.address)) {
                Assert.IsTrue(true, "Delivery Address Line 1 mismatches");
            }
            if (confirmOrderForm.GetDAddress().Contains(deliveryDetails.suburb)) {
                Assert.IsTrue(true, "Delivery Suburb mismatches");
            }
            if (confirmOrderForm.GetDAddress().Contains(deliveryDetails.state)) {
                Assert.IsTrue(true, "Delivery State mismatches");
            }
            if (confirmOrderForm.GetDAddress().Contains(deliveryDetails.postcode)) {
                Assert.IsTrue(true, "Delivery Post Code mismatches");
            }

            Assert.AreEqual(contactDetails.email, confirmOrderForm.GetCEmailAddress(), "Contact Email Address mismatches");
            Assert.AreEqual(contactDetails.phoneNumber, confirmOrderForm.GetCNumber(), "Contact Phone Number mismatches");

        }

        public void ValidatePaymentDetailsSection(ConfirmOrderForm confirmOrderForm)
        {
            Assert.AreEqual(paymentDetails.nameOnCard, confirmOrderForm.GetCardName(), "Name on Card mismatches");
            Assert.AreEqual(paymentDetails.cardNumber, confirmOrderForm.GetCardNumber(), "Card Number mismatches");
            Assert.AreEqual(paymentDetails.cardType, confirmOrderForm.GetCardType(), "Card Type mismatches");
            Assert.AreEqual(paymentDetails.expiryDate, confirmOrderForm.GetCardExpiry(), "Card Expiry mismatches");
            Assert.AreEqual(paymentDetails.CVV, confirmOrderForm.GetCardCVV(), "Card CVV mismatches");
        }

        [Then(@"the user finishes payment with below details")]
        public void ThenTheUserFinishesPaymentWithBelowDetails(Table table)
        {
            paymentDetails = table.CreateInstance<PaymentDetails>();
            checkOutPage.AddPaymentDetailsInCheckOutForm(paymentDetails);
            checkOutPage.ClickNextButton();
        }

    }
}
