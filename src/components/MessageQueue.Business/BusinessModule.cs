using Autofac;

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
        }
    }
}
