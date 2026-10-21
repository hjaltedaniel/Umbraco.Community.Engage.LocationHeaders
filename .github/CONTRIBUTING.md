# Contributing Guidelines

Contributions to this package are welcome.

## Build and test

Install the .NET 8 and .NET 10 SDKs, then run these commands from the repository root:

```sh
dotnet build src/Umbraco.Community.Engage.LocationHeaders.csproj --configuration Release
dotnet test tests/Umbraco.Community.Engage.LocationHeaders.Tests.csproj --configuration Release
dotnet test compatibility/Umbraco18.Tests.csproj --configuration Release
```

The regression tests cover location decoding on .NET 8 and .NET 10. The compatibility tests verify composer registration and extraction with Umbraco CMS 18 and Engage 18. The repository does not include a running Umbraco test site or database; changes affecting hosted behavior should also be checked in an Umbraco site with the matching Engage version.

Package support follows the underlying [Umbraco version's EOL](https://umbraco.com/products/knowledge-center/long-term-support-and-end-of-life/).
