using JupiterToysSpecFlowProject.DataContainer;
using JupiterToysSpecFlowProject.DataModel;
using JupiterToysSpecFlowProject.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace JupiterToysSpecFlowProject.StepDefinitions
{
    [Binding]
    public class ShopStepDefinitions
    {
        ShopPage showPage;
        private Dictionary<string, Toy> cartItems;
        private IWebDriver driver;
        public ShopStepDefinitions(IWebDriver driver, Dictionary<string, Toy> cartItems)
        {
            this.driver = driver;
            this.cartItems = cartItems;
            showPage = new ShopPage(driver);
        }

        [Given(@"the user adds following toys to the cart")]
        public void GivenTheUserAddsFollowingToysToTheCart(Table table)
        {
            var toys = table.CreateSet<Toy>();
            foreach (var toy in toys){
                showPage.AddToys(toy.toyName, toy.quantity);
                toy.price = showPage.GetToyPrice(toy.toyName);
                cartItems.Add(toy.toyName, toy);
            }
        }
    }
}
