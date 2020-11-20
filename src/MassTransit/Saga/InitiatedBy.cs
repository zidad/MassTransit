namespace MassTransit.Saga
{
    using System;


    /// <summary>
    /// Specifies that the message type TMessage starts a new saga.
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public interface InitiatedBy<in TMessage> :
        IConsumer<TMessage>
        where TMessage : class, CorrelatedBy<Guid>
    {
    }

    /// <summary>
    /// Specifies that the message type TMessage starts a new saga.
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public interface InitiatedByAndOrchestrates<in TMessage> :
        IConsumer<TMessage>, InitiatedBy<TMessage>, Orchestrates<TMessage>
        where TMessage : class, CorrelatedBy<Guid>
    {
    }
}
