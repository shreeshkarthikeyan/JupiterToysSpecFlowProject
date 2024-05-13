using JupiterToysSpecFlowProject.DataContainer;
using JupiterToysSpecFlowProject.DataModel;
using JupiterToysSpecFlowProject.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace JupiterToysSpecFlowProject.StepDefinitions
{
    [Binding]
    public class CheckOutStepDefinitions
    {
        CommonObjects commonObjects;
        CheckOutPage checkOutPage;
        ContactDetails contactDetails;
        DeliveryDetails deliveryDetails;
        PaymentDetails paymentDetails;

        public CheckOutStepDefinitions(CommonObjects commonObjects) 
        {
            this.commonObjects = commonObjects;
            checkOutPage = new CheckOutPage(commonObjects.Driver);
            contactDetails = new ContactDetails();
            deliveryDetails = new DeliveryDetails();
            paymentDetails = new PaymentDetails();
        }
        [Then(@"the user checks out using same delivery details")]
        public void ThenTheUserChecksOutUsingSameDeliveryDetails(Table table)
        {
            contactDetails = table.CreateInstance<ContactDetails>();
            checkOutPage.AddContactDetailsInCheckOutForm(contactDetails);
            checkOutPage.ClickNextButton("Contact Details");
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
            checkOutPage.ClickNextButton("Delivery Details");
        }

        [Then(@"the user verifies the details on the confirm order screen and confirms it")]
        public void ThenTheUserVerifiesTheDetailsOnTheConfirmOrderScreenAndConfirmsIt()
        {
            checkOutPage.ClickEpandAllButton();
            ValidateOrderDetailsSection();
            ValidateDeliveryAndContactDetailsSection();
            ValidatePaymentDetailsSection();
            checkOutPage.ClickSubmitOrderButton();
        }

        public void ValidateOrderDetailsSection()
        {
            // Checks the number of items in the cart
            Assert.AreEqual(commonObjects.cartItems.Count, checkOutPage.GetNumberOfCartItems(), "Cart Item Count mismatches");
            foreach (var item in commonObjects.cartItems)
            {
                // Checks the item's unit price
                Assert.AreEqual(commonObjects.cartItems[item.Key].price, checkOutPage.GetCartItemUnitPrice(item.Key), $"{item.Key} Cart Item Unit Price mismatches");
                // Checks the item's quantity
                Assert.AreEqual(commonObjects.cartItems[item.Key].quantity, checkOutPage.GetCartItemQuanity(item.Key), $"{item.Key} Cart Item Quantity mismatches");
                // Checks the item's sub total
                Assert.AreEqual(commonObjects.GetToyItemPrice(item.Key), checkOutPage.GetCartItemSubTotal(item.Key), $"{item.Key} Cart Item Sub Total mismatches");
            }
        }

        public void ValidateDeliveryAndContactDetailsSection()
        {
            Assert.AreEqual(contactDetails.firstName+ " "+contactDetails.lastName, checkOutPage.GetCName(), "Contact Name mismatches");
            Assert.AreEqual(deliveryDetails.name, checkOutPage.GetDName(), "Delivery Name mismatches");
            
            if(checkOutPage.GetDAddress().Contains(deliveryDetails.address)) {
                Assert.IsTrue(true, "Delivery Address Line 1 mismatches");
            }
            if (checkOutPage.GetDAddress().Contains(deliveryDetails.suburb)) {
                Assert.IsTrue(true, "Delivery Suburb mismatches");
            }
            if (checkOutPage.GetDAddress().Contains(deliveryDetails.state)) {
                Assert.IsTrue(true, "Delivery State mismatches");
            }
            if (checkOutPage.GetDAddress().Contains(deliveryDetails.postcode))
            {
                Assert.IsTrue(true, "Delivery Post Code mismatches");
            }

            Assert.AreEqual(contactDetails.email, checkOutPage.GetCEmailAddress(), "Contact Email Address mismatches");
            Assert.AreEqual(contactDetails.phoneNumber, checkOutPage.GetCNumber(), "Contact Phone Number mismatches");

        }

        public void ValidatePaymentDetailsSection()
        {
            Assert.AreEqual(paymentDetails.nameOnCard, checkOutPage.GetCardName(), "Name on Card mismatches");
            Assert.AreEqual(paymentDetails.cardNumber, checkOutPage.GetCardNumber(), "Card Number mismatches");
            Assert.AreEqual(paymentDetails.cardType, checkOutPage.GetCardType(), "Card Type mismatches");
            Assert.AreEqual(paymentDetails.expiryDate, checkOutPage.GetCardExpiry(), "Card Expiry mismatches");
            Assert.AreEqual(paymentDetails.CVV, checkOutPage.GetCardCVV(), "Card CVV mismatches");
        }

        [Then(@"the user finishes payment with below details")]
        public void ThenTheUserFinishesPaymentWithBelowDetails(Table table)
        {
            paymentDetails = table.CreateInstance<PaymentDetails>();
            checkOutPage.AddPaymentDetailsInCheckOutForm(paymentDetails);
            checkOutPage.ClickNextButton("Payment Details");
        }

    }
}
