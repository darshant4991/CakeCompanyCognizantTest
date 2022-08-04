using CakeCompany.Models;

namespace CakeCompany.Provider
{
    internal class CakeProvider
    {
        public DateTime GetestimatedBakeTime(Order order) //Check
        {
            if (order.Name == Cake.Chocolate)
            {
                return DateTime.Now.Add(TimeSpan.FromMinutes(30));
            }

            if (order.Name == Cake.RedVelvet)
            {
                return DateTime.Now.Add(TimeSpan.FromMinutes(60));
            }

            return DateTime.Now.Add(TimeSpan.FromHours(15));
        }

        public Product Bake(Order order)
        {
            if (order.Name == Cake.Chocolate)
            {
                return new()
                {
                    Cake = Cake.Chocolate,
                    Id = new Guid(),
                    Quantity = order.Quantity
                };
            }

            if (order.Name == Cake.RedVelvet)
            {
                return new()
                {
                    Cake = Cake.RedVelvet,
                    Id = new Guid(),
                    Quantity = order.Quantity
                };
            }

            return new()
            {
                Cake = Cake.Vanilla,
                Id = new Guid(),
                Quantity = order.Quantity
            }; ;
        }
    }
}