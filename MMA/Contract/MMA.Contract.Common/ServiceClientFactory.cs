using System;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;

namespace MMA.Contract.Common
{
    public class ServiceClientFactory<T> : IDisposable
    {
        private ChannelFactory<T> _channelFactory { get; }
        public static T Service() => new ServiceClientFactory<T>().GetService();
        public ServiceClientFactory()
        {
            _channelFactory = CreateChannelFactory();
        }

        public T GetService() => _channelFactory.CreateChannel();

        private ChannelFactory<T> CreateChannelFactory()
        {
            var clientSection = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
            if (clientSection == null)
                throw new Exception("Нет секции для конфигурации клиента сервиса.");

            var configurationName = typeof(T).Name;

            var endpointElements = clientSection.Endpoints;
                
            
            var endpointElement = endpointElements
                .Cast<ChannelEndpointElement>()
                .FirstOrDefault(c => c.Name == configurationName);

            if (endpointElement == null)
                throw new Exception($"Конечная точка для \"{configurationName}\" не задана.");

            var endpoint = new EndpointAddress(endpointElement.Address);
            var binding = new BasicHttpBinding();

            return new ChannelFactory<T>(binding, endpoint);
        }

        public void Dispose()
        {
            if (_channelFactory.State == CommunicationState.Opened)
                _channelFactory.Close();
        }
    }

}