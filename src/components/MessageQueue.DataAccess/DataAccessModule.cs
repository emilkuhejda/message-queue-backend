using Autofac;

namespace MessageQueue.DataAccess
{
    public class DataAccessModule : Module
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
