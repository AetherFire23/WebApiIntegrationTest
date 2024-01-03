using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Identity.Client;
using Xunit.Abstractions;
namespace ControllerTest;

public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly ITestOutputHelper _output;
    private readonly HttpClient _httpClient;
    public UnitTest1(WebApplicationFactory<Program> factory, ITestOutputHelper output)
    {
        _factory = factory;
        _output = output;
        _httpClient = _factory.CreateClient();

    }

    [Fact]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
    {
        _output.WriteLine("Integration Test");
        var caller = new Client("/", _httpClient);
        var ent = new MyEntity
        {
            Id = Guid.NewGuid(),
            FunName = "test",
        };
        _output.LogObject(ent, "this is entity My Entity at first request");
        await caller.GetWeatherForecastAsync(ent);
    }
}