using MassTransit;
using Microsoft.Extensions.Logging;
using statemachineSagasRabbitmqDemo.ReadFile.UseCases.ReadFile;

namespace statemachineSagasRabbitmqDemo.ReadFile.Masstransit.Consumers
{
    public class ReadFileConsumer : IConsumer<Domain.Contracts.ReadFile.File>
    {
        private readonly ILogger<ReadFileConsumer> logger;
        private readonly IReadFileUseCase readFileUseCase;

        public ReadFileConsumer(ILogger<ReadFileConsumer> logger, IReadFileUseCase readFileUseCase)
        {
            this.logger = logger;
            this.readFileUseCase = readFileUseCase;
        }

        public Task Consume(ConsumeContext<Domain.Contracts.ReadFile.File> context)
        {
            return readFileUseCase.Execute(new ReadFileRequest(context.Message));
        }
    }
}
