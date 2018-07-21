using System;
using System.ComponentModel.Composition;

namespace DependencyInjection
{
    [Export]
    public class ServiceChecker
    {
        public void CheckService()
        {
            Console.WriteLine("Service checking started!");
        }
    }
}
