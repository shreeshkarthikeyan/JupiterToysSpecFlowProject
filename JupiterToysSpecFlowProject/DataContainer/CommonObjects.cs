using JupiterToysSpecFlowProject.DataModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.DataContainer
{
    public class CommonObjects
    {
        private IWebDriver driver;

        public IWebDriver Driver { get => driver; set => driver = value; }
        public Dictionary<string, Toy> cartItems { get; }

        public CommonObjects()
        {
            cartItems = new Dictionary<string, Toy>();
        }

        public void AddCartItems(Toy toy)
        {
            cartItems.Add(toy.toyName, toy);
        }

        public decimal GetToyItemPrice(String toy)
        {
            return cartItems[toy].quantity * cartItems[toy].price;
        }

        public decimal GetTotalPrice()
        {
            decimal price = 0;
            foreach(var item in cartItems)
            {
                price += (item.Value.price * item.Value.quantity);
            }
            return price;
        }

    }
}
