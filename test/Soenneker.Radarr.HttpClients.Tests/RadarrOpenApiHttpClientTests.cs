using Soenneker.Radarr.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Radarr.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class RadarrOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IRadarrOpenApiHttpClient _httpclient;

    public RadarrOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IRadarrOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
