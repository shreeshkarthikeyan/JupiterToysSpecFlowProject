using JupiterToysSpecFlowProject.DataContainer;
using JupiterToysSpecFlowProject.DataModel;
using JupiterToysSpecFlowProject.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;

namespace JupiterToysSpecFlowProject.StepDefinitions
{
    [Binding]
    public class NavigationStepDefinitions
    {
        BasePage basePage;
        private IWebDriver driver;
        public NavigationStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            basePage = new BasePage(driver);
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
