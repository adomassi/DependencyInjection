using System;
using DependencyInjection.Interfaces;

namespace DependencyInjection
{
    public class Program
    {
        static void Main()
        {
            var container = Container.Default.CompositionContainer;

            var service1 = container.GetExportedValue<IService1>();
            var service2 = container.GetExportedValue<IService2>();
            var serviceRunner = container.GetExportedValue<IServiceRunner>();

            var newService = container.GetExportedValue<INewService>();

            service1.Initialize();
            service2.Initialize();

            newService.RunNewService();

            Console.WriteLine("enter string");
            var stuff = Console.ReadLine();
            Console.WriteLine("enter number");
            var number = Console.ReadLine();

            serviceRunner.RunServices(stuff, Convert.ToInt32(number));

            Console.WriteLine("press any key to exit !");
            Console.ReadLine();
        }
    }
}
