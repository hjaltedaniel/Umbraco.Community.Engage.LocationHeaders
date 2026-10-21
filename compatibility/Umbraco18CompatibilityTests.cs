using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Community.Engage.LocationHeaders;
using Umbraco.Engage.Data.Analytics.Collection.Pageview;
using Umbraco.Engage.Infrastructure.Analytics.Processing.Extractors;
using Xunit;

public class Umbraco18CompatibilityTests
{
    [Fact]
    public void ComposerRegistersExtractorWithUmbraco18()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(new ConfigurationBuilder().Build());
        var builder = new Mock<IUmbracoBuilder>();
        builder.SetupGet(x => x.Services).Returns(services);

        new EngageLocationComposer().Compose(builder.Object);
        using var provider = services.BuildServiceProvider();

        Assert.IsType<HttpHeaderLocationExtractor>(provider.GetRequiredService<IRawPageviewLocationExtractor>());
    }

    [Fact]
    public void ExtractorReadsEngage18Pageviews()
    {
        var pageview = new Mock<IRawPageview>();
        pageview.SetupGet(x => x.IpAddress).Returns("203.0.113.1");
        pageview.SetupGet(x => x.Headers).Returns(new HeaderDictionary
        {
            ["uc-ipcountry"] = "GB",
            ["cf-ipcity"] = "London",
            ["CF-Region"] = "England"
        });
        IRawPageviewLocationExtractor extractor = new HttpHeaderLocationExtractor(new ConfigurationBuilder().Build());

        var location = extractor.Extract(pageview.Object);

        Assert.NotNull(location);
        Assert.Equal("United Kingdom", location.Country);
        Assert.Equal("London", location.City);
        Assert.Equal("England", location.County);
        Assert.Equal("England", location.Province);
    }
}
