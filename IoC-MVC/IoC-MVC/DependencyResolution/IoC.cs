using StructureMap;
using IoC_MVC.Controllers;
namespace IoC_MVC {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<ILogger>().Use<xLogger>();
                        });
            return ObjectFactory.Container;
        }
    }
}