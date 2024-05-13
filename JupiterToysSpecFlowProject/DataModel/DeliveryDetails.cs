using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.DataModel
{
    public class DeliveryDetails
    {
        public Boolean isSameAsContactAddress { get; set; }
        public string name {  get; set; }
        public string address { get; set; }
        public string suburb { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }

        public DeliveryDetails() { }

        public DeliveryDetails(Boolean isSameAsContactAddress, string name, string address, string suburb,
                                string state, string postcode) 
        {
            this.isSameAsContactAddress = isSameAsContactAddress;
            this.name = name;
            this.address = address;
            this.suburb = suburb;
            this.state = state;
            this.postcode = postcode;
        }
    }
}
