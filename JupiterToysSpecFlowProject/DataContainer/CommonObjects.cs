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
        public Dictionary<string, Toy> cartItems1 { get; }

        public CommonObjects()
        {
            cartItems1 = new Dictionary<string, Toy>();
        }

        public void AddCartItems(Toy toy)
        {
            cartItems1.Add(toy.toyName, toy);
        }

        public decimal GetToyItemPrice(String toy)
        {
            return cartItems1[toy].quantity * cartItems1[toy].price;
        }

        public decimal GetTotalPrice()
        {
            decimal price = 0;
            foreach(var item in cartItems1)
            {
                price += (item.Value.price * item.Value.quantity);
            }
            return price;
        }

    }
}
