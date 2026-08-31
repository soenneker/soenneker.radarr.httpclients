[![](https://img.shields.io/nuget/v/soenneker.radarr.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.radarr.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.radarr.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.radarr.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.radarr.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.radarr.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.radarr.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.radarr.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Radarr.HttpClients

Provides a cached `HttpClient` configured for an authenticated Radarr instance.

## Installation

```bash
dotnet add package Soenneker.Radarr.HttpClients
```

## Configuration

```json
{
  "Radarr": {
    "ClientBaseUrl": "http://localhost:7878",
    "ApiKey": "your-radarr-api-key"
  }
}
```

`ClientBaseUrl` defaults to `http://localhost:7878`. Find the API key in Radarr under **Settings → General → Security**.

## Usage

```csharp
using Soenneker.Radarr.HttpClients.Abstract;
using Soenneker.Radarr.HttpClients.Registrars;

services.AddRadarrOpenApiHttpClientAsSingleton();

public sealed class RadarrStatusService
{
    private readonly IRadarrOpenApiHttpClient _radarr;

    public RadarrStatusService(IRadarrOpenApiHttpClient radarr)
    {
        _radarr = radarr;
    }

    public async Task<string> GetStatus(CancellationToken cancellationToken)
    {
        HttpClient client = await _radarr.Get(cancellationToken);
        return await client.GetStringAsync("api/v3/system/status", cancellationToken);
    }
}
```

The provider sends the key through Radarr's `X-Api-Key` header. `Radarr:AuthHeaderName` and `Radarr:AuthHeaderValueTemplate` can override that behavior for a proxy or compatible service; use `{token}` in the value template where the configured key should be inserted.
