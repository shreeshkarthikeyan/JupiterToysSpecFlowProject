using JupiterToysSpecFlowProject.DataContainer;
using JupiterToysSpecFlowProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace JupiterToysSpecFlowProject.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions
    {
        CommonObjects commonObjects;
        CartPage cartPage;

        public CartStepDefinitions(CommonObjects commonObjects) 
        { 
            this.commonObjects = commonObjects;
            cartPage = new CartPage(commonObjects.Driver);
        }
        [Then(@"the user validates all the items subprice and total price")]
        public void ThenTheUserValidatesAllTheItemsSubpriceAndTotalPrice()
        {
            foreach(var item in commonObjects.cartItems)
            {
                //Checking toy sub price
                if(cartPage.GetToyPrice(item.Key).Contains(commonObjects.GetToyItemPrice(item.Key).ToString())) {
                    Assert.IsTrue(true, $"{item.Key}'s sub price mismatches - Expected value: {commonObjects.GetToyItemPrice(item.Key)}, UI value: {cartPage.GetToyPrice(item.Key)}");
                }
            }

            //checking total price
            if(cartPage.GetTotalPrice().Contains(commonObjects.GetTotalPrice().ToString())) {
                Assert.IsTrue(true, $"Expected value: {commonObjects.GetTotalPrice()}, UI value: {cartPage.GetTotalPrice()}");
            }
        }

        [Then(@"the user clicks Check Out button")]
        public void ThenTheUserClicksCheckOutButton()
        {
            cartPage.ClickCheckOutButton();
        }
    }
}
