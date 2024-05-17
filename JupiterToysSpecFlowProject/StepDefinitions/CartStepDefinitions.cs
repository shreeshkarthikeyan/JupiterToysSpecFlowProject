using JupiterToysSpecFlowProject.DataContainer;
using JupiterToysSpecFlowProject.DataModel;
using JupiterToysSpecFlowProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace JupiterToysSpecFlowProject.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions
    {
        CartPage cartPage;
        private IWebDriver driver;
        public Dictionary<string, Toy> cartItems;
        public CartStepDefinitions(IWebDriver driver, Dictionary<string, Toy> cartItems) 
        {
            this.driver = driver;
            this.cartItems = cartItems;
            cartPage = new CartPage(driver);
        }
        [Then(@"the user validates all the items subprice and total price")]
        public void ThenTheUserValidatesAllTheItemsSubpriceAndTotalPrice()
        {
            foreach(var item in cartItems)
            {
                Console.WriteLine($"{cartItems[item.Key].toyName}'s quantity --> {cartItems[item.Key].quantity}");
                Console.WriteLine($"{cartItems[item.Key].toyName}'s price --> {cartItems[item.Key].price}");
                //Checking toy sub price
                if (cartPage.GetToyPrice(item.Key).Contains((cartItems[item.Key].quantity * cartItems[item.Key].price).ToString())) {
                    Assert.IsTrue(true, $"{item.Key}'s sub price mismatches - Expected value: {(cartItems[item.Key].quantity * cartItems[item.Key].price).ToString()}, UI value: {cartPage.GetToyPrice(item.Key)}");
                }
            }


            //checking total price
            decimal price = 0;
            foreach (var item in cartItems) {
                price += (item.Value.price * item.Value.quantity);
            }
            if (cartPage.GetTotalPrice().Contains(price.ToString())) {
                Assert.IsTrue(true, $"Expected value: {price.ToString()}, UI value: {cartPage.GetTotalPrice()}");
            }
        }

        [Then(@"the user clicks Check Out button")]
        public void ThenTheUserClicksCheckOutButton()
        {
            cartPage.ClickCheckOutButton();
        }
    }
}
