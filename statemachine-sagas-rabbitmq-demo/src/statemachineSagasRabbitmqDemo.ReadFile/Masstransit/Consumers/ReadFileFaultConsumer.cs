using MassTransit;
using Microsoft.Extensions.Logging;

namespace statemachineSagasRabbitmqDemo.ReadFile.Masstransit.Consumers
{
    public class ReadFileFaultConsumer : IConsumer<Fault<Domain.Contracts.ReadFile.File>>
    {
        private readonly ILogger<ReadFileFaultConsumer> logger;

        public ReadFileFaultConsumer(ILogger<ReadFileFaultConsumer> logger)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<Fault<Domain.Contracts.ReadFile.File>> context)
        {
            logger.LogInformation($"Error {context.Message.Exceptions[0].Message}");
            logger.LogInformation($"Consuming message {context.Message.Message}");

            if (context.Message.Exceptions[0].Message.Equals("teste"))
            {
                return Task.CompletedTask;
            }

            return context.Publish<Domain.Contracts.ReadFile.File>(context.Message.Message);
        }
    }
}
