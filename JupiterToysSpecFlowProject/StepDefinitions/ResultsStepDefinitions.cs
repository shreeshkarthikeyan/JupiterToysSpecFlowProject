using JupiterToysSpecFlowProject.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace JupiterToysSpecFlowProject.StepDefinitions
{
    [Binding]
    public class ResultsStepDefinitions
    {
        ResultsPage resultsPage;
        private IWebDriver driver;
        public ResultsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            resultsPage = new ResultsPage(driver);
        }

        [Then(@"the user finally obtains the order number and payment status")]
        public void ThenTheUserFinallyObtainsTheOrderNumberAndPaymentStatus()
        {
            Console.WriteLine($"Payment Status -> {resultsPage.GetPaymentStatus()}");
            Console.WriteLine($"Order number -> {resultsPage.GetOrderNumber()}");
        }
    }
}
