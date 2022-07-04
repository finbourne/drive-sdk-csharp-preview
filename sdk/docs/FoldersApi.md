# Lusid.Drive.Sdk.Api.FoldersApi

All URIs are relative to *https://fbn-ci.lusid.com/drive*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateFolder**](FoldersApi.md#createfolder) | **POST** /api/folders | [EARLY ACCESS] CreateFolder: Create a new folder in LUSID Drive
[**DeleteFolder**](FoldersApi.md#deletefolder) | **DELETE** /api/folders/{id} | [EARLY ACCESS] DeleteFolder: Delete a specified folder and all subfolders
[**GetFolder**](FoldersApi.md#getfolder) | **GET** /api/folders/{id} | [EARLY ACCESS] GetFolder: Get metadata of folder
[**GetFolderContents**](FoldersApi.md#getfoldercontents) | **GET** /api/folders/{id}/contents | [EARLY ACCESS] GetFolderContents: List contents of a folder
[**GetRootFolder**](FoldersApi.md#getrootfolder) | **GET** /api/folders | [EARLY ACCESS] GetRootFolder: List contents of root folder
[**MoveFolder**](FoldersApi.md#movefolder) | **POST** /api/folders/{id} | [EARLY ACCESS] MoveFolder: Move files to specified folder
[**UpdateFolder**](FoldersApi.md#updatefolder) | **PUT** /api/folders/{id} | [EARLY ACCESS] UpdateFolder: Update an existing folder&#39;s name, path


<a name="createfolder"></a>
# **CreateFolder**
> StorageObject CreateFolder (CreateFolder createFolder)

[EARLY ACCESS] CreateFolder: Create a new folder in LUSID Drive

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class CreateFolderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi(config);
            var createFolder = new CreateFolder(); // CreateFolder | A CreateFolder object that defines the name and path of the new folder

            try
            {
                // [EARLY ACCESS] CreateFolder: Create a new folder in LUSID Drive
                StorageObject result = apiInstance.CreateFolder(createFolder);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FoldersApi.CreateFolder: " + e.Message );
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
 **createFolder** | [**CreateFolder**](CreateFolder.md)| A CreateFolder object that defines the name and path of the new folder | 

### Return type

[**StorageObject**](StorageObject.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletefolder"></a>
# **DeleteFolder**
> void DeleteFolder (string id)

[EARLY ACCESS] DeleteFolder: Delete a specified folder and all subfolders

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class DeleteFolderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi(config);
            var id = id_example;  // string | Unique ID of the folder

            try
            {
                // [EARLY ACCESS] DeleteFolder: Delete a specified folder and all subfolders
                apiInstance.DeleteFolder(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FoldersApi.DeleteFolder: " + e.Message );
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
 **id** | **string**| Unique ID of the folder | 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **404** | No folder with this Id exists |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfolder"></a>
# **GetFolder**
> StorageObject GetFolder (string id)

[EARLY ACCESS] GetFolder: Get metadata of folder

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class GetFolderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi(config);
            var id = id_example;  // string | Unique ID of the folder

            try
            {
                // [EARLY ACCESS] GetFolder: Get metadata of folder
                StorageObject result = apiInstance.GetFolder(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FoldersApi.GetFolder: " + e.Message );
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
 **id** | **string**| Unique ID of the folder | 

### Return type

[**StorageObject**](StorageObject.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **404** | No folder with this Id exists |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfoldercontents"></a>
# **GetFolderContents**
> PagedResourceListOfStorageObject GetFolderContents (string id, string page = null, List<string> sortBy = null, int? start = null, int? limit = null, string filter = null)

[EARLY ACCESS] GetFolderContents: List contents of a folder

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class GetFolderContentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi(config);
            var id = id_example;  // string | Unique ID of the folder
            var page = page_example;  // string | The pagination token to use to continue listing contents from a previous call to list contents.              This value is returned from the previous call. If a pagination token is provided the sortBy and filter fields              must not have changed since the original request. Also, if set, a start value cannot be provided. (optional) 
            var sortBy = new List<string>(); // List<string> | Order the results by these fields. Use use the '-' sign to denote descending order. (optional) 
            var start = 56;  // int? | When paginating, skip this number of results. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set. (optional)  (default to "")

            try
            {
                // [EARLY ACCESS] GetFolderContents: List contents of a folder
                PagedResourceListOfStorageObject result = apiInstance.GetFolderContents(id, page, sortBy, start, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FoldersApi.GetFolderContents: " + e.Message );
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
 **id** | **string**| Unique ID of the folder | 
 **page** | **string**| The pagination token to use to continue listing contents from a previous call to list contents.              This value is returned from the previous call. If a pagination token is provided the sortBy and filter fields              must not have changed since the original request. Also, if set, a start value cannot be provided. | [optional] 
 **sortBy** | [**List&lt;string&gt;**](string.md)| Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order. | [optional] 
 **start** | **int?**| When paginating, skip this number of results. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many. | [optional] 
 **filter** | **string**| Expression to filter the result set. | [optional] [default to &quot;&quot;]

### Return type

[**PagedResourceListOfStorageObject**](PagedResourceListOfStorageObject.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **404** | No folder with this Id exists |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getrootfolder"></a>
# **GetRootFolder**
> PagedResourceListOfStorageObject GetRootFolder (string page = null, List<string> sortBy = null, int? start = null, int? limit = null, string filter = null)

[EARLY ACCESS] GetRootFolder: List contents of root folder

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class GetRootFolderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi(config);
            var page = page_example;  // string | The pagination token to use to continue listing contents from a previous call to list contents.              This value is returned from the previous call. If a pagination token is provided the sortBy and filter fields              must not have changed since the original request. Also, if set, a start value cannot be provided. (optional) 
            var sortBy = new List<string>(); // List<string> | Order the results by these fields. Use use the '-' sign to denote descending order. (optional) 
            var start = 56;  // int? | When paginating, skip this number of results. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set. (optional)  (default to "true")

            try
            {
                // [EARLY ACCESS] GetRootFolder: List contents of root folder
                PagedResourceListOfStorageObject result = apiInstance.GetRootFolder(page, sortBy, start, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FoldersApi.GetRootFolder: " + e.Message );
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
 **page** | **string**| The pagination token to use to continue listing contents from a previous call to list contents.              This value is returned from the previous call. If a pagination token is provided the sortBy and filter fields              must not have changed since the original request. Also, if set, a start value cannot be provided. | [optional] 
 **sortBy** | [**List&lt;string&gt;**](string.md)| Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order. | [optional] 
 **start** | **int?**| When paginating, skip this number of results. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many. | [optional] 
 **filter** | **string**| Expression to filter the result set. | [optional] [default to &quot;true&quot;]

### Return type

[**PagedResourceListOfStorageObject**](PagedResourceListOfStorageObject.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="movefolder"></a>
# **MoveFolder**
> PagedResourceListOfStorageObject MoveFolder (string id, List<string> requestBody, bool? overwrite = null, bool? deleteSource = null)

[EARLY ACCESS] MoveFolder: Move files to specified folder

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class MoveFolderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi(config);
            var id = id_example;  // string | Unique ID of the folder where the files should be moved
            var requestBody = new List<string>(); // List<string> | Enumerable of unique IDs of files that should be moved
            var overwrite = true;  // bool? | True if the destination has file with same name if should be overwritten (optional)  (default to false)
            var deleteSource = true;  // bool? | If true after moving the original file is deleted (optional)  (default to false)

            try
            {
                // [EARLY ACCESS] MoveFolder: Move files to specified folder
                PagedResourceListOfStorageObject result = apiInstance.MoveFolder(id, requestBody, overwrite, deleteSource);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FoldersApi.MoveFolder: " + e.Message );
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
 **id** | **string**| Unique ID of the folder where the files should be moved | 
 **requestBody** | [**List&lt;string&gt;**](string.md)| Enumerable of unique IDs of files that should be moved | 
 **overwrite** | **bool?**| True if the destination has file with same name if should be overwritten | [optional] [default to false]
 **deleteSource** | **bool?**| If true after moving the original file is deleted | [optional] [default to false]

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
| **404** | No folder or file with the supplied Id exists |  -  |
| **409** | There is already a file with the same name at this location |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatefolder"></a>
# **UpdateFolder**
> StorageObject UpdateFolder (string id, UpdateFolder updateFolder)

[EARLY ACCESS] UpdateFolder: Update an existing folder's name, path

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class UpdateFolderExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi(config);
            var id = id_example;  // string | Unique ID of the folder
            var updateFolder = new UpdateFolder(); // UpdateFolder | An UpdateFolder object that defines the new name or path of the folder

            try
            {
                // [EARLY ACCESS] UpdateFolder: Update an existing folder's name, path
                StorageObject result = apiInstance.UpdateFolder(id, updateFolder);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FoldersApi.UpdateFolder: " + e.Message );
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
 **id** | **string**| Unique ID of the folder | 
 **updateFolder** | [**UpdateFolder**](UpdateFolder.md)| An UpdateFolder object that defines the new name or path of the folder | 

### Return type

[**StorageObject**](StorageObject.md)

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
| **404** | No folder with this Id exists |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

