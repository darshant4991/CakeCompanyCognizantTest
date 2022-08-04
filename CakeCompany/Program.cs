// See https://aka.ms/new-console-template for more information

using CakeCompany.Provider;
using Serilog;
using Serilog.Events;

namespace CakeCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                path: path + "\\log-.txt",
                outputTemplate:"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}",
                rollingInterval : RollingInterval.Day,
                restrictedToMinimumLevel : LogEventLevel.Information)
                .CreateLogger();
            
            var shipmentProvider = new ShipmentProvider();
            try
            {
                shipmentProvider.GetShipment();
            }
            catch(Exception e)
            {
                Log.Fatal(e.Message.ToString() + e.StackTrace );
            }
            Console.WriteLine("Shipment Details...");
        }
    }
}

