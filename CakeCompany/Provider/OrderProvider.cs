using System.Reflection.Metadata.Ecma335;
using CakeCompany.Models;

namespace CakeCompany.Provider
{
    internal class OrderProvider
    {
        public Order[] GetLatestOrders()
        {
            return new Order[]
            {
            new("CakeBox", DateTime.Now.Add(TimeSpan.FromMinutes(120)) , 1, Cake.RedVelvet, 120.25), //DateTime.Now
            new("ImportantCakeShop", DateTime.Now.Add(TimeSpan.FromMinutes(120)), 1, Cake.RedVelvet, 120.25) //DateTime.Now
            };
        }

        public void UpdateOrders(Order[] orders)
        {
        }
    }
}


