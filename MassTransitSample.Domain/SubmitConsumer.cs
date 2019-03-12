using MassTransit;
using System;
using System.Threading.Tasks;

namespace MassTransitSample.Domain
{
    public class SubmitConsumer :
        IConsumer<Submit>
    {
        public async Task Consume(ConsumeContext<Submit> context)
        {
            await Console.Out.WriteLineAsync($"Submit Consumer: {context.Message.Id} - {context.Message.Message} ({context.CorrelationId})");
        }
    }
}
