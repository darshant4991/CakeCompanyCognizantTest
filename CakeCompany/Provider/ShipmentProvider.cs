using System.Diagnostics;
using CakeCompany.Models;
using CakeCompany.Models.Transport;

namespace CakeCompany.Provider
{
    public class ShipmentProvider
    {
        public void GetShipment()
        {
            //Call order to get new orders
            Order[] orders = GetOrders();
            if (!orders.Any())
                return;

            var cancelledOrders = new List<Order>();
            var products = new List<Product>();

            foreach (var order in orders)
            {
                var cakeProvider = new CakeProvider();
                var estimatedBakeTime = cakeProvider.GetestimatedBakeTime(order); //Check
                var payment = new PaymentProvider();

                if (estimatedBakeTime > order.EstimatedDeliveryTime || !payment.Process(order).IsSuccessful)
                {
                    cancelledOrders.Add(order);
                }
                else
                {
                    var product = cakeProvider.Bake(order);
                    products.Add(product);
                    string transport = GetTransport(products);
                    DeliverProduct(products, transport);
                }
            }
        }

        public string GetTransport(List<Product> products)
        {
            var transportProvider = new TransportProvider();
            var transport = transportProvider.CheckForAvailability(products);
            return transport;
        }

        public static void DeliverProduct(List<Product> products, string transport)
        {
            switch (transport)
            {
                case "Van":
                    var van = new Van();
                    van.Deliver(products);
                    break;
                case "Truck":
                    var truck = new Truck();
                    truck.Deliver(products);
                    break;
                default:
                    var ship = new Ship();
                    ship.Deliver(products);
                    break;
            }
        }

        private static Order[] GetOrders()
        {
            var orderProvider = new OrderProvider();

            var orders = orderProvider.GetLatestOrders();
            return orders;
        }
    }
}
