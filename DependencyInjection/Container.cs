using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DependencyInjection
{
    internal sealed class Container
    {
        private static Container _container;
        private readonly CompositionContainer _compositionContainer;

        private Container()
        {
            _compositionContainer = InitializeContainer();
        }

        public static Container Default
        {
            get { return _container ?? (_container = new Container()); }
        }

        public CompositionContainer CompositionContainer
        {
            get { return _compositionContainer; }
        }

        private CompositionContainer InitializeContainer()
        {
            try
            {
                var executingAssembly = Assembly.GetExecutingAssembly();
                var directory = Path.GetDirectoryName(executingAssembly.Location);
                if (directory == null)
                {
                    throw new Exception(string.Format("The directory for assembly \"{0}\" cannot be determined.", executingAssembly.FullName));
                }

                var assemblies = Directory
                    .EnumerateFiles(directory, "*.dll", SearchOption.AllDirectories)                   
                    .Select(LoadAssembly)
                    .Where(x => x != null)
                    .Concat(new[] { executingAssembly })
                    .Distinct()
                    .ToArray();

                var types = assemblies
                    .SelectMany(x => x.GetTypes())
                    .ToArray();

               return new CompositionContainer(new TypeCatalog(types)); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static Assembly LoadAssembly(string path)
        {
            try
            {
                return Assembly.LoadFile(path);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
