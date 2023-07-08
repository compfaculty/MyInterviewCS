using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MyIntervew.Udemy.DesignPatternCourse.Mediator
{
    public class PongResponse
    {
        public DateTime Timestamp;

        public PongResponse(DateTime timestamp)
        {
            Timestamp = timestamp;
        }
    }

    public class PingCommand : IRequest<PongResponse>
    {
        // nothing here
    }

    public class PingCommandHandler : IRequestHandler<PingCommand, PongResponse>
    {
        public async Task<PongResponse> Handle(PingCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new PongResponse(DateTime.UtcNow));
        }
    }

    public class Demo
    {
        public static async Task Run()
        {
            var services = new ServiceCollection();
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(Demo).Assembly);
            });
            // services.AddScoped<PingCommandHandler>();
            var builder = services.BuildServiceProvider();
            
            var mediator = builder.GetRequiredService<IMediator>();
            var response = await mediator.Send(new PingCommand());
            Console.WriteLine((object?)$"We got a pong at {response.Timestamp}");
        }
    }
}