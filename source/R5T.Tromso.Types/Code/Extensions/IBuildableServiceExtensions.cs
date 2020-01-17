using System;


namespace R5T.Tromso.Types
{
    public static class IBuildableServiceExtensions
    {
        public static IServiceBuilder<IServiceProvider> GetServiceBuilder(this IBuildableService buildableService)
        {
            var serviceBuilder = new ServiceBuilder(buildableService);
            return serviceBuilder;
        }
    }
}
