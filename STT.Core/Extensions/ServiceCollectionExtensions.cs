using Microsoft.Extensions.DependencyInjection;
using TRM_STT.Core.Services;
using TRM_STT.Core.Services.Interfaces;

namespace TRM_STT.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IGoodService, GoodService>();
            services.AddScoped<ISpeechToTextService, SpeechToTextService>();

            return services;
        }
    }
}