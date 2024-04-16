using AtolOnline.Shared;
using AtolOnline.V5.Client;
using AtolOnline.V5.Entities;
using AtolOnline.V5.Enums;

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
        var client = Client(settings);

        var resp = await client.GetTokenAsync();
        Assert.NotNull(resp);
        Assert.Null(resp.Error);
        Assert.IsNotNull(resp.Token);
    }

    private static AtolReceiptRequest SimpleReceipit(TestEnvParams settings) => new AtolReceiptRequest
    (
        Guid.NewGuid().ToString(),
        new Receipt
        (
            new Client("test@mail.ru"),
            new Company(settings.INN, settings.PaymentAddress, "sender@mail.ru", null, null),
            [
                new Item("Test", 10, 1.1m, Measurement.Kg, PaymentMethod.FullPayment, 1, Vat.None)
            ],
            [
                Payment.Cash(10 * 1.1m)
            ]
        )
    );

    private static AtolClient Client(TestEnvParams settings)
        => new AtolClient(_httpClient, settings.Login, settings.Password, settings.Group, null, null, settings.BaseAddress);
     

    [Test]
    public void V5FailsOnV4Test()
    {
        var client = new AtolClient(_httpClient, 
            TestEnvParams.V4.Login,
            TestEnvParams.V4.Password, 
            TestEnvParams.V4.Group,
            null, 
            null,
            TestEnvParams.V5.BaseAddress);

        var atolEx = Assert.ThrowsAsync<AtolClientException>(client.GetTokenAsync);
        Assert.IsNotNull(atolEx.Response);
        Assert.IsNotNull(atolEx.Response.Error);
        Assert.That(atolEx.Response!.Error!.Code, Is.EqualTo(21));
        Assert.That(atolEx.V5IsNotSupported, Is.True);
    }

    [Test]
    public void CallGetTokenExceptionTest([ValueSource(nameof(TestParams))] TestEnvParams settings)
    {
        var client = Client(settings);

        var atolEx = Assert.ThrowsAsync<AtolClientException>(() => client.OperationAsync("sell", SimpleReceipit(settings)));
        Assert.IsNull(atolEx.Response);
    }
}