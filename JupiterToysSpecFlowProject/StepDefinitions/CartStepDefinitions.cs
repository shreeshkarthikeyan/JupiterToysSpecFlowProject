using JupiterToysSpecFlowProject.DataContainer;
using JupiterToysSpecFlowProject.Pages;
using NUnit.Framework;
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
                Assert.AreEqual(commonObjects.GetToyItemPrice(item.Key), cartPage.GetToyPrice(item.Key), $"Calculated value: {commonObjects.GetToyItemPrice(item.Key)}, UI value: {cartPage.GetToyPrice(item.Key)}");
            }

            //checking total price
            Assert.AreEqual(commonObjects.GetTotalPrice(), cartPage.GetTotalPrice(), $"Calculated value: {commonObjects.GetTotalPrice()}, UI value: {cartPage.GetTotalPrice()}");
        }

        [Then(@"the user starts checkout process")]
        public void ThenTheUserStartsCheckoutProcess()
        {
            cartPage.ClickCheckOutButton();
        }
    }
}
