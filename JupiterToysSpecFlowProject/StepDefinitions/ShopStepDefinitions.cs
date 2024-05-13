using JupiterToysSpecFlowProject.DataContainer;
using JupiterToysSpecFlowProject.DataModel;
using JupiterToysSpecFlowProject.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace JupiterToysSpecFlowProject.StepDefinitions
{
    [Binding]
    public class ShopStepDefinitions
    {
        ShopPage showPage;
        CommonObjects commonObjects;

        public ShopStepDefinitions(CommonObjects commonObjects)
        {
            showPage = new ShopPage(commonObjects.Driver);
            this.commonObjects = commonObjects;           
        }

        [Given(@"the user adds following toys to the cart")]
        public void GivenTheUserAddsFollowingToysToTheCart(Table table)
        {
            var toys = table.CreateSet<Toy>();

            foreach (var toy in toys)
            {
                showPage.AddToys(toy.toyName, toy.quantity);
                toy.price = showPage.GetToyPrice(toy.toyName);
                commonObjects.AddCartItems(toy);
                //Console.WriteLine(commonObjects.GetToyItemPrice(toy.toyName));
            }
            //Console.WriteLine(commonObjects.GetTotalPrice());
        }
    }
}
