using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.DataModel
{
    public class PaymentDetails
    {
        public string cardNumber {  get; set; }
        public string cardType { get; set; }
        public string nameOnCard { get; set; }
        public string expiryDate { get; set; }
        public string CVV { get; set; }


    }
}
