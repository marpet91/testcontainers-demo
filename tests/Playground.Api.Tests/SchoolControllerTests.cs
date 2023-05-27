using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Playground.Api.Data;
using Playground.Api.Tests.Setup;
using Xunit;

namespace Playground.Api.Tests;

public class SchoolControllerTests : IClassFixture<SqlServerWebApplicationFactory>
{
    private readonly SqlServerWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public SchoolControllerTests(SqlServerWebApplicationFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }
    
    [Fact]
    public async Task TestDatabaseIsNotEmpty()
    {
        var students = await _client.GetFromJsonAsync<IEnumerable<Student>>("students");

        students.Count().Should().BeGreaterThan(0);
    }
}