using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Notification.Pipelines;
using System.Reflection;

namespace NewsAggregator.Notification.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services) 
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            return services;
        }
    }
}
