Masstransit Sample
===========

## Example code using MassTransit with Autofac, and RabbitMQ messaging.

Configuring Publisher on MassTransitSample.Web


```
    var builder = new ContainerBuilder();
    builder.AddMassTransit(x =>
    {
        // add a specific consumer

        // add the bus to the container
        x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            var host = cfg.Host("rabbitmq", "/", u => {
                u.Password("guest");
                u.Username("guest");
            });
            cfg.AutoDelete = false;
            cfg.Durable = true;
            cfg.Exclusive = false;
            // or, configure the endpoints by convention
            // cfg.ConfigureEndpoints(context);
        }));
    });
```

Configuring Consumer on MassTransitSample.Cmd

MassTransit with Autofac
```
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
```

AutoFac on Asp.Net Core
```
    builder.Populate(services);

    this.ApplicationContainer = builder.Build();

    // Create the IServiceProvider based on the container.
    return new AutofacServiceProvider(this.ApplicationContainer);
```
