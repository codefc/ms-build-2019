using Fumec.API.Handlers;
using Fumec.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Fumec.API.Extensions
{
    public static class RefitExtension
    {
        public static void AddRefit(this IServiceCollection services)
        {
            services.AddSingleton(new GitHeadersHandler());

           

            services.AddRefitClient<IGithubAPIService>()
                .AddHttpMessageHandler<GitHeadersHandler>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://api.github.com");
                });
        }
    }
}
