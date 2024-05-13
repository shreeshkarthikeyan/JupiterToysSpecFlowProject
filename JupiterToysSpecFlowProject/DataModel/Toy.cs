using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.DataModel
{
    public class Toy
    {
        public string toyName { get; set; }
        public int quantity { get; set; }
        public Decimal price { get; set; }
    }
}
