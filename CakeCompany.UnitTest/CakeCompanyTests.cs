using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakeCompany.Models;
using CakeCompany.Provider;

using NUnit.Framework;
namespace CakeCompany.UnitTest
{
    public class CakeCompanyTests
    {
        List<Product> products = new List<Product>();
        [SetUp]
        public void Init()
        {
            var Order1 = new Order[] { new("CakeBox", DateTime.Now, 1, Cake.RedVelvet, 120.25),
                new("ImportantCakeShop", DateTime.Now, 1, Cake.RedVelvet, 120.25) };

            var Product1 = new Product { Cake = Order1[0].Name, Id = Guid.NewGuid(), Quantity = Order1[0].Quantity, OrderId = Order1[0].Id };
            var Product2 = new Product { Cake = Order1[1].Name, Id = Guid.NewGuid(), Quantity = Order1[1].Quantity, OrderId = Order1[1].Id };
            products.Add(Product1);
            products.Add(Product2);
        }

        [Test]
        public void TestTransport()
        {
            var SProvider = new ShipmentProvider();
            string transport = SProvider.GetTransport(products);
            Assert.AreEqual("VAN", transport.ToUpper());
        }
    }
}
