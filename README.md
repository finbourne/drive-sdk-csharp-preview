# LUSID<sup>®</sup> Drive SDK C# (Preview)
![LUSID by Finbourne](https://content.finbourne.com/LUSID_repo.png)

This is the C# SDK (Preview) for the Drive application, part of the [LUSID by FINBOURNE](https://www.finbourne.com/lusid-technology) platform. To use it you'll need a LUSID account. [Sign up for free at lusid.com](https://www.lusid.com/app/signup).

Drive is a secure file repository and manager for collaboration (like Dropbox).

For more details on other applications in the LUSID platform, see [Understanding all the applications in the LUSID platform](https://support.lusid.com/knowledgebase/article/KA-01787/en-us).

[C# SDK Extensions](https://github.com/finbourne/drive-sdk-extensions-csharp) to accompany this SDK are available. These provides the user with additional extensions to make it easy to configure and use the API endpoints.

## Installation

The NuGet package for the FINBOURNE Drive service SDK (Preview) can installed from https://www.nuget.org/packages/Finbourne.Drive.Sdk.Preview using the following:

```
$ dotnet add package Finbourne.Drive.Sdk.Preview
```

This C# SDK (Preview) supports `Production`, `Early Access`, `Beta` and `Experimental` API endpoints. For more details on API endpoint categories, see [Documentation - Release Lifecycle](https://www.lusid.com/app/resources/documentation/lifecycle). To find out which category an API endpoint falls into, see [FINBOURNE Drive API Documentation](https://www.lusid.com/drive/swagger/index.html).

## FOR VERSIONS PRIOR TO v0.1.305

This repository contained the functionality that has now been split into the [C# SDK Extensions](https://github.com/finbourne/drive-sdk-extensions-csharp) repository. Namespaces that begin Finbourne.Drive previously appeared as LUSID.Drive in the SDK prior to v0.1.305.

## Build Status 

| branch | status |
| --- | --- |
| `master` |  ![Nuget](https://img.shields.io/nuget/v/Finbourne.Drive.Sdk.Preview?color=blue) [![Build](https://github.com/finbourne/drive-sdk-csharp-preview/actions/workflows/build.yaml/badge.svg?branch=master)](https://github.com/finbourne/drive-sdk-csharp-preview/actions/workflows/build.yaml) |