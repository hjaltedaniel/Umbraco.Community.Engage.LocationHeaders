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

## Publishing releases

Releases use NuGet Trusted Publishing with GitHub OIDC; no stored NuGet API key is required. The NuGet policy for package owner `hjaltedaniel` must match:

- Repository owner: `hjaltedaniel`
- Repository: `Umbraco.Community.Engage.LocationHeaders`
- Workflow file: `release.yml`
- Environment: leave empty (the publishing job does not use an environment)

Pushing a version tag such as `0.3.0` validates and publishes that version. To retry an existing release, run the **Release Package** workflow from `main` with the existing tag as the `tag` input. Validation and packaging both use the tagged source. The publishing job obtains a short-lived key immediately before uploading the package.

See the [NuGet Trusted Publishing documentation](https://learn.microsoft.com/en-us/nuget/nuget-org/trusted-publishing) for policy setup.
