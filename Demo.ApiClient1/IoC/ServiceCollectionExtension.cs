using Demo.ApiClient1.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.ApiClient1.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddDemoApiClientService(this IServiceCollection service, Action<ApiClientOptions> options)
        {
            service.Configure(options);
            service.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new DemoApiClientService(options);
            });
        }
    }
}
