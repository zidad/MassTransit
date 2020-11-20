namespace MassTransit.Tests.Saga.Messages
{
    using System;


    [Serializable]
    public class InitiateSimpleSaga :
        SimpleSagaMessageBase
    {
        public InitiateSimpleSaga()
        {
        }

        public InitiateSimpleSaga(Guid correlationId)
            : base(correlationId)
        {
        }

        public string Name { get; set; }
    }

    [Serializable]
    public class InitiatesAndOrchestratesSimpleSaga :
        SimpleSagaMessageBase
    {
        public InitiatesAndOrchestratesSimpleSaga()
        {
        }

        public InitiatesAndOrchestratesSimpleSaga(Guid correlationId)
            : base(correlationId)
        {
        }

        public string Name { get; set; }
    }
}
