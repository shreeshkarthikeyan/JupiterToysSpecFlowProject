using JupiterToysSpecFlowProject.DataContainer;
using JupiterToysSpecFlowProject.DataModel;
using JupiterToysSpecFlowProject.Pages;
using TechTalk.SpecFlow.Assist;

namespace JupiterToysSpecFlowProject.StepDefinitions
{
    [Binding]
    public class NavigationStepDefinitions
    {
        CommonObjects commonObjects;
        BasePage basePage;
        public NavigationStepDefinitions(CommonObjects commonObjects)
        {
            basePage = new BasePage(commonObjects.Driver);
            this.commonObjects = commonObjects;
        }

        [Given(@"the user opens the jupiter toys application")]
        public void GivenTheUserOpensTheJupiterToysApplication()
        {
            basePage.NavigateUrl();           
        }

        [Given(@"the user navigates to the shop tab")]
        public void GivenTheUserNavigatesToTheShopTab()
        {
            basePage.ClickShopButton();
        }

        [Then(@"the user navigates to the cart tab")]
        public void ThenTheUserNavigatesToTheCartTab()
        {
            basePage.ClickCartButton();
        }

        


    }
}
