# Informational Endpoint ![GitHub tag (latest SemVer pre-release)](https://img.shields.io/github/v/tag/deathchurch/informationalendpoint?include_prereleases) ![Nuget](https://img.shields.io/nuget/v/InformationalEndpoint?style=plastic)

A library to provide an informational endpoint.

Enables you to add an informational status page to your ASP.NET application, when you navigate to the page it will show the following details.

```json
{
  "Server": "<MachineName>",
  "OS": "<OS Version String>",
  "User": "<Username>",
  "Path": "<The Content Root Path",
  "Environment": "<ASPNETCORE_ENVIRONMENT Variable Value>",
  "Runtime": "<Runtime Version Information>",
  "Assembly": "<Assembly Information Version>"
}
```
If any of the values are not able to be determined they will be substituted with ```"N/A"```
