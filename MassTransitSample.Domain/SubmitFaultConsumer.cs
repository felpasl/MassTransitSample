using MassTransit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MassTransitSample.Domain
{
    public class SubmitFaultConsumer :
        IConsumer<Fault<Submit>>
    {
        public Task Consume(ConsumeContext<Fault<Submit>> context)
        {
            context.Message.Exceptions.ToList().ForEach(f => Console.WriteLine($"Error: {f.Message}"));
            return Task.CompletedTask;
        }
    }
}
