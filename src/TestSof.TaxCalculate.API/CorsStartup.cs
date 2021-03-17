using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TestSof.TaxCalculate.API
{
    public static class CorsStartup
    {
        public static void RegisterCorsServices(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("*", opts =>
                {
                    opts.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public static void AddCors(this IApplicationBuilder app)
        {
            app.UseCors(opts =>
            {
                opts.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        }
    }
}