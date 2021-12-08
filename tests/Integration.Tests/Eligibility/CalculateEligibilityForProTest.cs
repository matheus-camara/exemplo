using System.Net;
using System.Text;
using System.Text.Json;
using Core.Tests.Contexts;
using Core.Tests.ServiceProvider;
using FluentAssertions;
using Infra.Contexts;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Integration.Tests.Eligibility;

internal record ApiResponse(
    int score,
    string selected_project,
    string[] eligible_projects,
    string[] ineligible_projects);

public class CalculateEligibilityForProTest : IClassFixture<WebApplicationFactory<Program>>
{
    private const string API_URL = "/api/eligibility";
    private readonly WebApplicationFactory<Program> _factory;

    public CalculateEligibilityForProTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services => { services.MockDbContext<Context, TestContext>(); });
        });
    }

    private async Task<HttpResponseMessage> PostAsync(object input)
    {
        using var httpClient = _factory.CreateClient();
        using var content = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");

        return await httpClient.PostAsync(API_URL, content);
    }

    private async Task<T> GetResult<T>(HttpResponseMessage response)
    {
        return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync()) ?? default!;
    }

    [Fact]
    public async Task ShouldPostCalculateEligibilityForProAndSucceed()
    {
        var input = new
        {
            age = 35,
            education_level = "high_school",
            past_experiences = new
            {
                sales = false,
                support = true
            },
            internet_test = new
            {
                download_speed = 50.4,
                upload_speed = 40.2
            },
            writing_score = 0.6,
            referral_code = "token1234"
        };

        using var response = await PostAsync(input);

        if (!response.IsSuccessStatusCode)
        {
            var str = response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
        }

        var responseJson = await GetResult<ApiResponse>(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseJson.score.Should().Be(7
        );
        responseJson.selected_project.Should().Be("Determine if the Schrodinger's cat is alive");
        responseJson.ineligible_projects.Should().BeEquivalentTo("Calculate the Dark Matter of the universe for Nasa");

        responseJson.eligible_projects.Should().BeEquivalentTo("Determine if the Schrodinger's cat is alive",
            "Attend to users support for a YXZ Company",
            "Collect specific people information from their social media for XPTO Company");
    }

    [Fact]
    public async Task ShouldPostCalculateEligibilityForProAndReceiveErrorList()
    {
        var input = new
        {
            age = 35,
            education_level = "hgh_school",
            internet_test = new
            {
                upload_speed = 40.2
            },
            referral_code = "token1234"
        };

        using var response = await PostAsync(input);
        var responseJson = await GetResult<string[]>(response);

        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        responseJson.Should()
            .BeEquivalentTo("Education Level must be one of 'no_education, high_school, bachelors_or_higher'",
                "'Writing Score' deve ser informado.", "'Download Speed' deve ser informado.",
                "'Past Experiences' não pode ser nulo.");
    }
}