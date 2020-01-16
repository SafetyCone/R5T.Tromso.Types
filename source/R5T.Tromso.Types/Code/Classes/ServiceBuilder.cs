using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace R5T.Tromso.Types
{
    public class ServiceBuilder : IServiceBuilder
    {
        private List<Action<IConfigurationBuilder, IServiceProvider>> ConfigureConfigurationActions { get; } = new List<Action<IConfigurationBuilder, IServiceProvider>>();
        private List<Action<IServiceCollection>> ConfigureServicesActions { get; } = new List<Action<IServiceCollection>>();
        private List<Action<IServiceProvider>> ConfigureActions { get; } = new List<Action<IServiceProvider>>();
        

        public void AddConfigureConfiguration(Action<IConfigurationBuilder, IServiceProvider> configureConfigurationAction)
        {
            this.ConfigureConfigurationActions.Add(configureConfigurationAction);
        }

        public void AddConfigureServices(Action<IServiceCollection> configureServicesAction)
        {
            this.ConfigureServicesActions.Add(configureServicesAction);
        }

        public void AddConfigure(Action<IServiceProvider> configureAction)
        {
            this.ConfigureActions.Add(configureAction);
        }

        public void Build(IBuildableService buildableService, IServiceProvider configurationServiceProvider)
        {
            var configurationBuilder = buildableService.ConfigurationBuilder;
            foreach (var action in this.ConfigureConfigurationActions)
            {
                action(configurationBuilder, configurationServiceProvider);
            }

            var servicesollection = buildableService.ServiceCollection;
            foreach (var action in this.ConfigureServicesActions)
            {
                action(servicesollection);
            }

            var serviceProvider = buildableService.ServiceProvider;
            foreach (var action in this.ConfigureActions)
            {
                action(serviceProvider);
            }
        }
    }
}
