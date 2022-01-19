using System.Reflection;
using Autofac;
using MessageQueue.Domain.Interfaces.Infrastructure;
using Module = Autofac.Module;

namespace MessageQueue.Business
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterServices(builder);
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClosedTypeOf(typeof(ICommand<,>)))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClosedTypeOf(typeof(ICommand<>)))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClosedTypeOf(typeof(IQuery<,>)))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClosedTypeOf(typeof(IQuery<>)))
                .AsImplementedInterfaces();
        }
    }
}
