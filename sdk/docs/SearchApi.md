# Lusid.Drive.Sdk.Api.SearchApi

All URIs are relative to *https://fbn-ci.lusid.com/drive*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Search**](SearchApi.md#search) | **POST** /api/search | [BETA] Search: Search for a file or folder with a given name and path


<a name="search"></a>
# **Search**
> PagedResourceListOfStorageObject Search (SearchBody searchBody, string page = null, List<string> sortBy = null, int? limit = null, string filter = null)

[BETA] Search: Search for a file or folder with a given name and path

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class SearchExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SearchApi(config);
            var searchBody = new SearchBody(); // SearchBody | Search parameters
            var page = page_example;  // string |  (optional) 
            var sortBy = new List<string>(); // List<string> |  (optional) 
            var limit = 56;  // int? |  (optional) 
            var filter = filter_example;  // string |  (optional)  (default to "")

            try
            {
                // [BETA] Search: Search for a file or folder with a given name and path
                PagedResourceListOfStorageObject result = apiInstance.Search(searchBody, page, sortBy, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchApi.Search: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **searchBody** | [**SearchBody**](SearchBody.md)| Search parameters | 
 **page** | **string**|  | [optional] 
 **sortBy** | [**List&lt;string&gt;**](string.md)|  | [optional] 
 **limit** | **int?**|  | [optional] 
 **filter** | **string**|  | [optional] [default to &quot;&quot;]

### Return type

[**PagedResourceListOfStorageObject**](PagedResourceListOfStorageObject.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

