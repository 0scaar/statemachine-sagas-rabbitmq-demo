using MassTransit;
using Microsoft.Extensions.Logging;
using Serilog;
using statemachineSagasRabbitmqDemo.Domain.Contracts.ProcessLine;

namespace statemachineSagasRabbitmqDemo.ProcessLine.Masstransit.Consumers
{
    public class ProcessLineConsumer : IConsumer<Line>
    {
        private readonly ILogger<ProcessLineConsumer> logger;

        public ProcessLineConsumer(ILogger<ProcessLineConsumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<Line> context)
        {
            logger.LogInformation($"Consuming message {context.Message}");

            Log.Information($"ProcessLineConsumer - FileID: {context.Message.FileId} - LineId {context.Message.LineId}");

            await Task.CompletedTask;
        }
    }
}
