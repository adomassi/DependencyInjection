using System;
using System.ComponentModel.Composition;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Services
{
    [Export(typeof(IService2))]
    public class Service2 : IService2
    {
        public void Initialize()
        {
            Console.WriteLine("Service2 Initialized");
        }

        public void PrintNumber(int number)
        {
            Console.WriteLine("Number printed: " + number);
        }
    }
}
