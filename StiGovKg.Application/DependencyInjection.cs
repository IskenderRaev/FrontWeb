using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace StiGovKg.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddStiGovKgApplication(this IServiceCollection services)
        {
            services
               .AddMediatR(Assembly.GetExecutingAssembly())
                  .AddFluentValidationAutoValidation()
                  .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
