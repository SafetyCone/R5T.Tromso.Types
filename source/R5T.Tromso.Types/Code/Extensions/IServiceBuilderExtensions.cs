using System;

using R5T.Dacia;


namespace R5T.Tromso
{
    public static class IServiceBuilderExtensions
    {
        public static void Build(this IServiceBuilder serviceBuilder)
        {
            serviceBuilder.Build(ServiceProviderHelper.GetNewEmptyServiceProvider());
        }

        public static IServiceBuilder<TService> BuildFluent<TService>(this IServiceBuilder<TService> serviceBuilder)
        {
            serviceBuilder.Build();

            return serviceBuilder;
        }
    }
}
