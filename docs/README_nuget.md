# Engage LocationHeaders 

[![Downloads](https://img.shields.io/nuget/dt/Umbraco.Community.Engage.LocationHeaders?color=cc9900)](https://www.nuget.org/packages/Umbraco.Community.Engage.LocationHeaders/)
[![NuGet](https://img.shields.io/nuget/vpre/Umbraco.Community.Engage.LocationHeaders?color=0273B3)](https://www.nuget.org/packages/Umbraco.Community.Engage.LocationHeaders)
[![GitHub license](https://img.shields.io/github/license/hjaltedaniel-umbraco/Umbraco.Community.Engage.LocationHeaders?color=8AB803)](https://github.com/hjaltedaniel-umbraco/Umbraco.Community.Engage.LocationHeaders/blob/main/LICENSE)

**Engage - LocationHeaders** is a lightweight package for [Umbraco Engage](https://umbraco.com/products/umbraco-engage/) that enriches analytics and segmentation data with location information extracted from HTTP headers.

The defaults target **Umbraco Cloud** location headers. You can also configure headers supplied by **Cloudflare**, **Azure Front Door**, or another proxy. The package reads location information already present in the request; it does not perform an IP geolocation lookup itself.

## ✨ Features

- 🔌 **Defaults for Umbraco Cloud** location headers
- 🌍 **Supports Cloudflare, Azure Front Door, and other CDNs** that inject location headers
- ⚙️ **Optional configuration** for custom header names or alternative setups
- 📊 Enables location-based **segmentation** and **analytics** in Umbraco Engage

## Installation

Install the matching major version of Umbraco Engage on your Umbraco 13, 17, or 18 website, then add this package from NuGet:

`dotnet add package Umbraco.Community.Engage.LocationHeaders`

## 🛠️ Configuration (Optional)

By default, the package expects the following Umbraco Cloud header names. If your setup uses different headers, you can override the defaults using appsettings configuration:

```json
"Engage": {
  "LocationHeaders": {
    "Country": "uc-ipcountry",
    "County": "CF-Region",
    "Province": "CF-Region",
    "City": "cf-ipcity"
  }
}
```

If your infrastructure uses custom headers, you can override the defaults in your `appsettings.json` file. Simply add an `Engage:LocationHeaders` section with keys like `Country`, `County`, `Province`, or `City` and map them to your custom header names.

## CDN and proxy setup

On **Umbraco Cloud**, verify that the default headers above are present in requests reaching your site.

For **Cloudflare outside Umbraco Cloud**, set `Engage:LocationHeaders:Country` to `cf-ipcountry`. Enable the [Add visitor location headers managed transform](https://developers.cloudflare.com/rules/transform/managed-transforms/reference/#add-visitor-location-headers) to supply `cf-ipcity` and `cf-region`. The country header is also available through Cloudflare IP geolocation alone.

For **Azure Front Door or another proxy**, configure your infrastructure to provide location headers and map their names using the settings above. Installing this package does not make the proxy generate location data. Only map headers that your trusted proxy sets or overwrites.

County and province both use `CF-Region` by default, so they contain the same value unless you configure different headers.

## 🧠 Use Cases

- Segment content based on visitor location  
- Build region-specific personalizations  
- Enhance analytics with geographic insights  

## 📦 Package Compatibility

| Umbraco CMS | Umbraco Engage | .NET |
| --- | --- | --- |
| 13.x | 13.x | 8 |
| 17.x | 17.x | 10 |
| 18.x | 18.x | 10 |

Umbraco 17 and 18 use the same .NET 10 assembly. Versions outside this table have not been verified.

### Support policy

Support for this package on each Umbraco major version follows the [underlying Umbraco version's end-of-life date](https://umbraco.com/products/knowledge-center/long-term-support-and-end-of-life/). Once an Umbraco version reaches EOL, this package no longer receives fixes or compatibility testing for that version. Existing releases remain available on NuGet.

Bring location awareness to your digital experiences with **Engage - LocationHeaders** – simple, configurable, and Umbraco Cloud-ready.

## Contributing

Contributions to this package are most welcome! Please read the [Contributing Guidelines](https://github.com/hjaltedaniel/Umbraco.Community.Engage.LocationHeaders/blob/main/.github/CONTRIBUTING.md).

## 🙌 Acknowledgements

Big thanks to the community members who inspired and supported this package:

- 💡 [@TvGessel](https://github.com/TvGessel) – for the original idea of using location headers to enrich Umbraco Engage with geolocation data.  
- 🧰 [@LottePitcher](https://github.com/LottePitcher) – for providing the excellent [Umbraco Package Starter Kit](https://github.com/LottePitcher/opinionated-package-starter), which this package is built upon.

This package wouldn’t exist without your contributions — thank you!