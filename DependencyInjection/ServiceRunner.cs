using System.ComponentModel.Composition;
using DependencyInjection.Interfaces;

namespace DependencyInjection
{
    [Export(typeof(IServiceRunner))]
    public class ServiceRunner : IServiceRunner
    {
        [Import]
        private ServiceMain ServiceController { get; set; }
        [Import]
        private ServiceChecker ServiceCheckerController { get; set; }

        public void RunServices(string text, int number)
        {
            ServiceCheckerController.CheckService();
            ServiceController.DrawStuffAndPrintNumber(text, number);
        }
    }
}
