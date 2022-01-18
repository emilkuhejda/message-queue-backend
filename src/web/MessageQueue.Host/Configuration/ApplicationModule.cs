using Autofac;
using AutofacSerilogIntegration;
using MessageQueue.Business;
using MessageQueue.DataAccess;

namespace MessageQueue.Host.Configuration
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterModules(builder);
            RegisterServices(builder);
            ConfigureFilters(builder);
            ConfigureMappings(builder);
        }

        private void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<BusinessModule>();
            builder.RegisterModule<DataAccessModule>();
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterLogger();
        }

        private void ConfigureFilters(ContainerBuilder builder)
        {
        }

        private void ConfigureMappings(ContainerBuilder builder)
        {
        }
    }
}
