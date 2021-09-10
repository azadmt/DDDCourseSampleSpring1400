using Autofac;
using Framework.Core.Messageing;
using Framework.Messaging.MassTransit;

namespace Framework.Configuration.Autofac
{
    public class Configurator
    {
        public static void Config(ContainerBuilder cb)
        {
            cb.RegisterType<MassTransitBus>().As<IEnterpriseServiceBus>();
        }
    }
}
