using AtolOnline.Unofficial;
using AtolOnline.Unofficial.Shared;

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

    private static ReceiptRequest SimpleReceipit(TestEnvParams settings) => new ReceiptRequest
    (
        Guid.NewGuid().ToString(),
        new Receipt
        (
            new Client("test@mail.ru"),
            new Company(settings.INN, settings.PaymentAddress, "sender@mail.ru", SNO.OSN, null),
            [
                new Item("Test", 10, 1.1m, Measurement.Kg, PaymentMethod.FullPayment, 2, Vat.None())
            ],
            [
                Payment.Cash(10 * 1.1m)
            ]
        )
    );
    private static CorrectionRequest SimpleCorrectionReceipit(TestEnvParams settings) => new CorrectionRequest
    (
        Guid.NewGuid().ToString(),
        new CorrectionReceipt
        (
            new Client("test@mail.ru"),
            new Company(settings.INN, settings.PaymentAddress, "sender@mail.ru", SNO.OSN, null),
            CorrectionInfo.Instruction(DateTime.Now, "1791"),
            [
                new Item("Test", 10, 1.1m, Measurement.Kg, PaymentMethod.FullPayment, 2, Vat.None())
            ],
            [
                Payment.Cash(10 * 1.1m)
            ],
            vats:
            [
                Vat.None(11m)
            ]
        )
    );

    private static AtolClient Client(TestEnvParams settings, string token = null)
        => new AtolClient(_httpClient, settings.Login, settings.Password, settings.Group, null, token, settings.BaseAddress);
     

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

    [Test]
    public async Task TokenTest([ValueSource(nameof(TestParams))] TestEnvParams settings)
    {
        var client = Client(settings);
        var token = await client.GetTokenAsync();
        Assert.IsNotNull(token);
        Assert.IsNotNull(token.Token);

        var withTokenClient = Client(settings, token.Token!);

        var res = await withTokenClient.SellAsync(SimpleReceipit(settings));
        Assert.NotNull(res);
        Assert.NotNull(res.Uuid);
    }

    [Test]
    public async Task SellTest([ValueSource(nameof(TestParams))] TestEnvParams settings)
    {
        var client = Client(settings);
        await client.GetTokenAsync();

        var res = await client.SellAsync(SimpleReceipit(settings));
        Assert.NotNull(res);
        Assert.NotNull(res.Uuid);
    }

    [Test]
    public async Task SellRefundTest([ValueSource(nameof(TestParams))] TestEnvParams settings)
    {
        var client = Client(settings);
        await client.GetTokenAsync();

        var res = await client.SellRefundAsync(SimpleReceipit(settings));
        Assert.NotNull(res);
        Assert.NotNull(res.Uuid);
    }

    [Test]
    public async Task BuyTest([ValueSource(nameof(TestParams))] TestEnvParams settings)
    {
        var client = Client(settings);
        await client.GetTokenAsync();

        var res = await client.Buy(SimpleReceipit(settings));
        Assert.NotNull(res);
        Assert.NotNull(res.Uuid);
    }

    [Test]
    public async Task BuyRefundTest([ValueSource(nameof(TestParams))] TestEnvParams settings)
    {
        var client = Client(settings);
        await client.GetTokenAsync();

        var res = await client.BuyRefund(SimpleReceipit(settings));
        Assert.NotNull(res);
        Assert.NotNull(res.Uuid);
    }

    [Test]
    public async Task SellCorrectionTest([ValueSource(nameof(TestParams))] TestEnvParams settings)
    {
        var client = Client(settings);
        await client.GetTokenAsync();

        var res = await client.SellCorrection(SimpleCorrectionReceipit(settings));
        Assert.NotNull(res);
        Assert.NotNull(res.Uuid);
    }

    [Test]
    public async Task SellRefundCorrectionTest()
    {
        var client = Client(TestEnvParams.V5);
        await client.GetTokenAsync();

        var res = await client.SellRefundCorrection(SimpleCorrectionReceipit(TestEnvParams.V5));
        Assert.NotNull(res);
        Assert.NotNull(res.Uuid);
    }

    [Test]
    public async Task BuyCorrectionTest([ValueSource(nameof(TestParams))] TestEnvParams settings)
    {
        var client = Client(settings);
        await client.GetTokenAsync();

        var res = await client.BuyCorrection(SimpleCorrectionReceipit(settings));
        Assert.NotNull(res);
        Assert.NotNull(res.Uuid);
    }

    [Test]
    public async Task BuyRefundCorrectionTest()
    {
        var client = Client(TestEnvParams.V5);
        await client.GetTokenAsync();

        var res = await client.BuyRefundCorrection(SimpleCorrectionReceipit(TestEnvParams.V5));
        Assert.NotNull(res);
        Assert.NotNull(res.Uuid);
    }

    [Test]
    public async Task ReportTest([ValueSource(nameof(TestParams))] TestEnvParams settings)
    {
        var client = Client(settings);
        await client.GetTokenAsync();

        var res = await client.SellAsync(SimpleReceipit(settings));
        Assert.NotNull(res);
        Assert.NotNull(res.Uuid);

        var ex = Assert.ThrowsAsync<AtolClientException>(async () => await client.ReportAsync(res.Uuid));
        Assert.NotNull(ex.Response);
        Assert.That(ex.Response, Is.InstanceOf<FailReportResponse>());
    }


}