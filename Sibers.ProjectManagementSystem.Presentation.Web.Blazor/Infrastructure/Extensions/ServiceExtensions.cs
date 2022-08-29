using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IHttpClientBuilder AddApi<IInterface, IClient>(this IServiceCollection services, string Address)
            where IInterface : class where IClient : class, IInterface => services
           .AddHttpClient<IInterface, IClient>(
                (host, client) => client.BaseAddress = new($"https://localhost:7141/{Address}/"));

    }
}
