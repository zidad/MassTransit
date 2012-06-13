namespace MassTransit
{
    using System;
    using Builders;
    using EndpointConfigurators;
    using Transports;

    /// <summary>
    /// This is a static singleton instance of an EndpointFactory. While it goes
    /// against my very soul, it is here to ensure consistent usage of MassTransit
    /// as a singleton. It is highly recommended that <see cref="ServiceBusFactory.New"/> be
    /// used instead and the application maintain the reference to the EndpointFactory.
    /// </summary>
    public static class Endpoints
    {
        //look at all of this room for activities
        // <activity zone>























        // <end of activity zone>

        static IEndpointFactory _endpointFactory;

        public static void Initialize(Action<EndpointFactoryBuilder> configure)
        {
            var settings = new EndpointFactoryDefaultSettings();
            var epf = new EndpointFactoryBuilderImpl(settings);
            configure(epf);
            _endpointFactory = epf.Build();

            
        }

        public static IEndpoint GetEndpoint(string uri)
        {
            return GetEndpoint(new Uri(uri));
        }

        public static IEndpoint GetEndpoint(Uri uri)
        {
            return _endpointFactory.CreateEndpoint(uri);
        }

        // "Hey I never asked you. Do you like guacamole?"
    }
}