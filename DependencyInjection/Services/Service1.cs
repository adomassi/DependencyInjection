using System;
using System.ComponentModel.Composition;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Services
{
    [Export(typeof(IService1))]
    public class Service1 : IService1
    {
        public void Initialize()
        {
            Console.WriteLine("Service1 Initialized");
        }

        public void DrawStuff(string text)
        {
            Console.WriteLine("This is your text input: " + text);
        }
    }
}
