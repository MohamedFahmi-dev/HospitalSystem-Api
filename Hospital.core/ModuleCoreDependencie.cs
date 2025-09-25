using FluentValidation;
using Hospital.core.Behavior;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hospital.core
{
    public static class ModuleCoreDependencie
    {

        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            //mediator configuration
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // Automapper Configuration
            services.AddAutoMapper((Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;

        }

    }
}
