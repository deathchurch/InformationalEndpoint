# Informational Endpoint [![GitHub tag (latest SemVer pre-release)](https://img.shields.io/github/v/tag/deathchurch/informationalendpoint?include_prereleases)](https://github.com/deathchurch/InformationalEndpoint/releases/tag/v0.0.4-pre) [![Nuget](https://img.shields.io/nuget/v/InformationalEndpoint?style=plastic)](https://www.nuget.org/packages/InformationalEndpoint)

A library to provide an informational endpoint.

Enables you to add an informational status page to your ASP.NET application, when you navigate to the page it will show the following details.

```json
{
  "Hostname": "<MachineName>",
  "OS Version": "<OS Version String>",
  "OS Architecture": "<OS Architecture String>",
  "OS Description": "<OS Description String>",
  "Framework Description": "<Runtime Version Information>",
  "Username": "<Username>",
  "Path": "<The Content Root Path>",
  "Environment": "<ASPNETCORE_ENVIRONMENT Variable Value>",
  "Assembly": "<Assembly Information Version>"            
}
```
If any of the values are not able to be determined they will be substituted with ```"N/A"```.

The content type of the status page is ```application/json``` and the http response code is ```200```.
