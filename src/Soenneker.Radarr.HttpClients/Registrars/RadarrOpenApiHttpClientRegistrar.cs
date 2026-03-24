using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Radarr.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Radarr.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class RadarrOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="RadarrOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddRadarrOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IRadarrOpenApiHttpClient, RadarrOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="RadarrOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddRadarrOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IRadarrOpenApiHttpClient, RadarrOpenApiHttpClient>();

        return services;
    }
}
