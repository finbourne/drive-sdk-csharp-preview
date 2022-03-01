# Finbourne.Drive.Sdk.Api.FilesApi

All URIs are relative to *https://www.lusid.com/drive*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateFile**](FilesApi.md#createfile) | **POST** /api/files | [BETA] CreateFile: Uploads a file to Lusid Drive. If using an SDK, consider using the UploadAsStreamAsync function for larger files instead.
[**DeleteFile**](FilesApi.md#deletefile) | **DELETE** /api/files/{id} | [BETA] DeleteFile: Deletes a file from Drive.
[**DownloadFile**](FilesApi.md#downloadfile) | **GET** /api/files/{id}/contents | [BETA] DownloadFile: Download the file from Drive.
[**GetFile**](FilesApi.md#getfile) | **GET** /api/files/{id} | [BETA] GetFile: Get a file stored in Drive.
[**UpdateFileContents**](FilesApi.md#updatefilecontents) | **PUT** /api/files/{id}/contents | [BETA] UpdateFileContents: Updates contents of a file in Drive.
[**UpdateFileMetadata**](FilesApi.md#updatefilemetadata) | **PUT** /api/files/{id} | [BETA] UpdateFileMetadata: Updates metadata for a file in Drive.


<a name="createfile"></a>
# **CreateFile**
> StorageObject CreateFile (string xLusidDriveFilename, string xLusidDrivePath, int contentLength, byte[] body)

[BETA] CreateFile: Uploads a file to Lusid Drive. If using an SDK, consider using the UploadAsStreamAsync function for larger files instead.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Finbourne.Drive.Sdk.Api;
using Finbourne.Drive.Sdk.Client;
using Finbourne.Drive.Sdk.Model;

namespace Example
{
    public class CreateFileExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(config);
            var xLusidDriveFilename = xLusidDriveFilename_example;  // string | File name.
            var xLusidDrivePath = xLusidDrivePath_example;  // string | File path.
            var contentLength = 56;  // int | The size in bytes of the file to be uploaded
            var body = BYTE_ARRAY_DATA_HERE;  // byte[] | 

            try
            {
                // [BETA] CreateFile: Uploads a file to Lusid Drive. If using an SDK, consider using the UploadAsStreamAsync function for larger files instead.
                StorageObject result = apiInstance.CreateFile(xLusidDriveFilename, xLusidDrivePath, contentLength, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FilesApi.CreateFile: " + e.Message );
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
 **xLusidDriveFilename** | **string**| File name. | 
 **xLusidDrivePath** | **string**| File path. | 
 **contentLength** | **int**| The size in bytes of the file to be uploaded | 
 **body** | **byte[]**|  | 

### Return type

[**StorageObject**](StorageObject.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/octet-stream
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletefile"></a>
# **DeleteFile**
> void DeleteFile (string id)

[BETA] DeleteFile: Deletes a file from Drive.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Finbourne.Drive.Sdk.Api;
using Finbourne.Drive.Sdk.Client;
using Finbourne.Drive.Sdk.Model;

namespace Example
{
    public class DeleteFileExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(config);
            var id = id_example;  // string | Identifier of the file to be deleted.

            try
            {
                // [BETA] DeleteFile: Deletes a file from Drive.
                apiInstance.DeleteFile(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FilesApi.DeleteFile: " + e.Message );
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
 **id** | **string**| Identifier of the file to be deleted. | 

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
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="downloadfile"></a>
# **DownloadFile**
> System.IO.Stream DownloadFile (string id)

[BETA] DownloadFile: Download the file from Drive.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Finbourne.Drive.Sdk.Api;
using Finbourne.Drive.Sdk.Client;
using Finbourne.Drive.Sdk.Model;

namespace Example
{
    public class DownloadFileExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(config);
            var id = id_example;  // string | Identifier of the file to be downloaded.

            try
            {
                // [BETA] DownloadFile: Download the file from Drive.
                System.IO.Stream result = apiInstance.DownloadFile(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FilesApi.DownloadFile: " + e.Message );
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
 **id** | **string**| Identifier of the file to be downloaded. | 

### Return type

**System.IO.Stream**

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **410** | Malware detected, restricted from downloading file. |  -  |
| **423** | Virus scan in progress, restricted from downloading file. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfile"></a>
# **GetFile**
> StorageObject GetFile (string id)

[BETA] GetFile: Get a file stored in Drive.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Finbourne.Drive.Sdk.Api;
using Finbourne.Drive.Sdk.Client;
using Finbourne.Drive.Sdk.Model;

namespace Example
{
    public class GetFileExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(config);
            var id = id_example;  // string | Identifier of the file to be retrieved.

            try
            {
                // [BETA] GetFile: Get a file stored in Drive.
                StorageObject result = apiInstance.GetFile(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FilesApi.GetFile: " + e.Message );
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
 **id** | **string**| Identifier of the file to be retrieved. | 

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
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatefilecontents"></a>
# **UpdateFileContents**
> StorageObject UpdateFileContents (string id, int contentLength, byte[] body)

[BETA] UpdateFileContents: Updates contents of a file in Drive.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Finbourne.Drive.Sdk.Api;
using Finbourne.Drive.Sdk.Client;
using Finbourne.Drive.Sdk.Model;

namespace Example
{
    public class UpdateFileContentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(config);
            var id = id_example;  // string | The unique file identifier
            var contentLength = 56;  // int | The size in bytes of the file to be uploaded
            var body = BYTE_ARRAY_DATA_HERE;  // byte[] | 

            try
            {
                // [BETA] UpdateFileContents: Updates contents of a file in Drive.
                StorageObject result = apiInstance.UpdateFileContents(id, contentLength, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FilesApi.UpdateFileContents: " + e.Message );
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
 **id** | **string**| The unique file identifier | 
 **contentLength** | **int**| The size in bytes of the file to be uploaded | 
 **body** | **byte[]**|  | 

### Return type

[**StorageObject**](StorageObject.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/octet-stream
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatefilemetadata"></a>
# **UpdateFileMetadata**
> StorageObject UpdateFileMetadata (string id, UpdateFile updateFile)

[BETA] UpdateFileMetadata: Updates metadata for a file in Drive.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Finbourne.Drive.Sdk.Api;
using Finbourne.Drive.Sdk.Client;
using Finbourne.Drive.Sdk.Model;

namespace Example
{
    public class UpdateFileMetadataExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(config);
            var id = id_example;  // string | Identifier of the file to be updated
            var updateFile = new UpdateFile(); // UpdateFile | Update to be applied to file

            try
            {
                // [BETA] UpdateFileMetadata: Updates metadata for a file in Drive.
                StorageObject result = apiInstance.UpdateFileMetadata(id, updateFile);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FilesApi.UpdateFileMetadata: " + e.Message );
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
 **id** | **string**| Identifier of the file to be updated | 
 **updateFile** | [**UpdateFile**](UpdateFile.md)| Update to be applied to file | 

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
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

