namespace MassTransit.KafkaIntegration
{
    using System;
    using Confluent.Kafka;
    using Serializers;
    using Transports;


    public interface KafkaReceiveEndpointContext<TKey, TValue> :
        ReceiveEndpointContext
        where TValue : class
    {
        IHeadersDeserializer HeadersDeserializer { get; }
        IDeserializer<TKey> KeyDeserializer { get; }
        IDeserializer<TValue> ValueDeserializer { get; }
        IConsumerContextSupervisor ConsumerContextSupervisor { get; }

        KafkaTopicAddress NormalizeAddress(Uri address);
    }
}
