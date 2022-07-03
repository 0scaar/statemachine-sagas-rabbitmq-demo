using MassTransit;
using statemachineSagasRabbitmqDemo.Domain.Contracts.MoveFile;
using ReadFile = statemachineSagasRabbitmqDemo.Domain.Contracts.ReadFile;
using statemachineSagasRabbitmqDemo.Domain.Contracts.ReadFile;
using statemachineSagasRabbitmqDemo.Domain.Contracts.ProcessLine;

namespace statemachineSagasRabbitmqDemo.Orchestrator.Configuration
{
    public class MigrationStateMachine : MassTransitStateMachine<MigrationState>
    {
        public MigrationStateMachine()
        {
            InstanceState(x => x.CurrentState, LineRequested);

            Event(() => ReadFileSubmitted, context => context.CorrelateById(i => i.Message.FileId));
            Event(() => LineSubmitted, context => context.CorrelateById(i => i.Message.FileId));

            Initially(
                When(ReadFileSubmitted).Then(context =>
                {
                    context.Saga.CorrelationId = context.Message.FileId;
                })
                .SendAsync(new Uri("queue:read-file"), context => context.Init<ReadFile::File>(new
                {
                    FileId = context.Message.FileId,
                    FilePath = context.Message.File
                }))
                .TransitionTo(LineRequested));

            During(LineRequested,
                When(LineSubmitted)
                .SendAsync(new Uri("queue:process-line"), context => context.Init<Line>(new
                {
                    FileId = context.Message.FileId,
                    LineId = context.Message.LineId
                })));
        }

        public State LineRequested { get; set; }

        public Event<ReadFileSubmitted> ReadFileSubmitted { get; set; }
        public Event<ILineSubmitted> LineSubmitted { get; set; }
    }
}
