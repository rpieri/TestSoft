using Microsoft.Extensions.DependencyInjection;

namespace TestSoft.TaxCalculate.Service
{
    public static class Module
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<ITaxCalculateService, TaxCalculateService>();
        }
    }
}