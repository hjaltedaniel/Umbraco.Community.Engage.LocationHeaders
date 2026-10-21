# Umbraco compatibility

| Umbraco CMS | Umbraco Engage | Package assembly |
| --- | --- | --- |
| 13.x | 13.x | .NET 8 |
| 17.x | 17.x | .NET 10 |
| 18.x | 18.x | .NET 10 |

The .NET 10 assembly supports both Umbraco 17 and 18. Its dependencies retain the Umbraco 17 minimum so installing it does not require an upgrade to Umbraco 18. On an Umbraco 18 site, install the matching Engage 18 version before adding this package.

The Umbraco 18 compatibility project references CMS 18 and Engage 18 directly while consuming the package project built against its original minimum dependencies. It tests composer registration, dependency injection, and location extraction against the Umbraco 18 interfaces:

```sh
dotnet test compatibility/Umbraco18.Tests.csproj
```

Support for each Umbraco major version ends when that Umbraco version reaches end of life, as published in the [Umbraco support policy](https://umbraco.com/products/knowledge-center/long-term-support-and-end-of-life/).
