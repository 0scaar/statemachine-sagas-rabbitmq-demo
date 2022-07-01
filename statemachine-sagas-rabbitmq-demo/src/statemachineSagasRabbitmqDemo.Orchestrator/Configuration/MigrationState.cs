using MassTransit;

namespace statemachineSagasRabbitmqDemo.Orchestrator.Configuration
{
    public class MigrationState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public int CurrentState { get; set; }
    }
}
