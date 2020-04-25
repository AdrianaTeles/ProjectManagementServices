using WebApplication1.Filters.ExceptionFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

using WebApplication1.Filters.ActionFilters;

namespace WebApplication1.Configurations
{
    internal static class MvcConfiguration
    {
        internal static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionFilter));
                options.Filters.Add(typeof(ApiValidationFilterAttribute));
                options.Filters.Add(typeof(ApiValidationResultFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest)
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
            .AddControllersAsServices();  //Injecting Controllers themselves through DI
                                          //For further info see: http://docs.autofac.org/en/latest/integration/aspnetcore.html#controllers-as-services

            return services;
        }
    }
}
