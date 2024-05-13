using JupiterToysSpecFlowProject.DataContainer;
using JupiterToysSpecFlowProject.Pages;
using System;
using TechTalk.SpecFlow;

namespace JupiterToysSpecFlowProject.StepDefinitions
{
    [Binding]
    public class ResultsStepDefinitions
    {
        CommonObjects commonObjects;
        ResultsPage resultsPage;

        public ResultsStepDefinitions(CommonObjects commonObjects)
        {
            this.commonObjects = commonObjects;
            resultsPage = new ResultsPage(commonObjects.Driver);
        }

        [Then(@"the user finally obtains the order number and payment status")]
        public void ThenTheUserFinallyObtainsTheOrderNumberAndPaymentStatus()
        {
            Console.WriteLine($"Payment Status -> {resultsPage.GetPaymentStatus()}");
            Console.WriteLine($"Order number -> {resultsPage.GetOrderNumber()}");
        }
    }
}
