using DependencyInjection.Interfaces;
using System;
using System.ComponentModel.Composition;

namespace DependencyInjection.Services
{
    [Export(typeof(INewService))]
    public class NewService : INewService
    {
        [Import]
        private ServiceMain ServiceController { get; set; }

        private readonly IService1 _service1;

        [ImportingConstructor]
        public NewService([Import] IService1 service1)
        {
            _service1 = service1;
        }

        public void RunNewService()
        {
            ServiceController.DrawStuffAndPrintNumber("newServiceStuff", 29);
            _service1.DrawStuff("New Service Stuff service 1 draw");
            Console.WriteLine("New Service Run! ");
        }
    }
}
