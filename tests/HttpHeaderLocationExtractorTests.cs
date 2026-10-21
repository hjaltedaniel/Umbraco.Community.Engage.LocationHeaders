using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Moq;
using Umbraco.Engage.Data.Analytics.Collection.Pageview;
using Xunit;

namespace Umbraco.Community.Engage.LocationHeaders.Tests;

public class HttpHeaderLocationExtractorTests
{
    [Theory]
    [InlineData("London", "London")]
    [InlineData("København", "København")]
    [InlineData("K%C3%B8benhavn", "København")]
    [InlineData("München", "München")]
    [InlineData("MÃ¼nchen", "München")]
    [InlineData("Zürich", "Zürich")]
    [InlineData("東京", "東京")]
    [InlineData("%E6%9D%B1%E4%BA%AC", "東京")]
    [InlineData("", "")]
    public void ExtractPreservesLocationNames(string header, string expected)
    {
        var pageview = new Mock<IRawPageview>();
        pageview.SetupGet(x => x.IpAddress).Returns("203.0.113.1");
        pageview.SetupGet(x => x.Headers).Returns(new HeaderDictionary
        {
            ["uc-ipcountry"] = "DK",
            ["cf-ipcity"] = header,
            ["CF-Region"] = header
        });
        var extractor = new HttpHeaderLocationExtractor(new ConfigurationBuilder().Build());

        var location = extractor.Extract(pageview.Object);

        Assert.Equal("Denmark", location.Country);
        Assert.Equal(expected, location.City);
        Assert.Equal(expected, location.County);
        Assert.Equal(expected, location.Province);
    }

    [Fact]
    public void ExtractAllowsMissingLocationHeaders()
    {
        var pageview = new Mock<IRawPageview>();
        pageview.SetupGet(x => x.IpAddress).Returns("203.0.113.1");
        pageview.SetupGet(x => x.Headers).Returns(new HeaderDictionary());
        var extractor = new HttpHeaderLocationExtractor(new ConfigurationBuilder().Build());

        var location = extractor.Extract(pageview.Object);

        Assert.Null(location.Country);
        Assert.Null(location.City);
        Assert.Null(location.County);
        Assert.Null(location.Province);
    }
}
