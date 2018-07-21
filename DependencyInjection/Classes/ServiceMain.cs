using System;
using System.ComponentModel.Composition;
using DependencyInjection.Interfaces;

namespace DependencyInjection
{
    [Export]
    public class ServiceMain
    {
        private readonly IService1 _service1;
        private readonly IService2 _service2;

        [ImportingConstructor]
        public ServiceMain([Import] IService1 service1, [Import] IService2 service2)
        {
            _service1 = service1;
            _service2 = service2;
        }
        
        public void DrawStuffAndPrintNumber(string text, int number)
        {
            Console.WriteLine("doing service1 and service2 jobs");
            _service1.DrawStuff(text);
            _service2.PrintNumber(number);
        }
    }
}
