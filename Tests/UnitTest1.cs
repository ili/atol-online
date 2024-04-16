using AtolOnline.Shared;
using AtolOnline.V5.Client;

namespace Tests;

public class Tests
{
    private static readonly HttpClient _httpClient = new();

    [SetUp]
    public void Setup()
    {
    }

    private static IEnumerable<TestEnvParams> TestParams()
    {
        yield return TestEnvParams.V4;
        yield return TestEnvParams.V5;
    }

    [Test]
    public async Task GetTokenTest([ValueSource(nameof(TestParams))] TestEnvParams settings)
    {
        var client = new AtolClient(_httpClient, settings.Login, settings.Password, null, null, settings.BaseAddress);

        var resp = await client.GetTokenAsync();
        Assert.NotNull(resp);
        Assert.Null(resp.Error);
        Assert.IsNotNull(resp.Token);
    }

    [Test]
    public void V5FailsOnV4Test()
    {
        var client = new AtolClient(_httpClient, 
            TestEnvParams.V4.Login,
            TestEnvParams.V4.Password, 
            null, 
            null,
            TestEnvParams.V5.BaseAddress);

        var atolEx = Assert.ThrowsAsync<AtolClientException>(client.GetTokenAsync);
        Assert.IsNotNull(atolEx.Response);
        Assert.IsNotNull(atolEx.Response.Error);
        Assert.That(atolEx.Response!.Error!.Code, Is.EqualTo(21));
    }
}