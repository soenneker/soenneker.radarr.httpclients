using Soenneker.Radarr.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Radarr.HttpClients.Tests;

[Collection("Collection")]
public sealed class RadarrOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IRadarrOpenApiHttpClient _httpclient;

    public RadarrOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IRadarrOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
