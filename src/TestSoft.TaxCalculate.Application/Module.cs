using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestSoft.TaxCalculate.Application.Commands.TaxCalculate;
using TestSoft.TaxCalculate.Application.Filters;

namespace TestSoft.TaxCalculate.Application
{
    public static class Module
    {
        public static void RegisterApplications(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionFilter<,>));
            services.AddMediatR(typeof(TaxCalculateCommand));
        }
    }
}