using Autofac;
using MassTransit;
using System;

namespace MassTransitSample.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.AddMassTransit(x =>
            {
                x.AddConsumer<Domain.SubmitConsumer>();
                // add the bus to the container
                x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host("localhost","/", u => {
                        u.Password("guest");
                        u.Username("guest");
                    });
                    cfg.AutoDelete = false;
                    cfg.Durable = true;
                    cfg.Exclusive = false;
                    cfg.ConfigureEndpoints(context);
                }));
            });
            var container = builder.Build();

            var bus = container.Resolve<IBusControl>();

            try
            {
                bus.Start();
                try
                {
                    Console.WriteLine("Bus started, type 'exit' to exit.");

                    bool running = true;
                    while (running)
                    {
                        var input = Console.ReadLine();
                        switch (input)
                        {
                            case "exit":
                            case "quit":
                                running = false;
                                break;
                        }
                    }
                }
                finally
                {
                    bus.Stop();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
