# Lusid.Drive.Sdk.Api.FilesApi

All URIs are relative to *https://fbn-ci.lusid.com/drive*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateFile**](FilesApi.md#createfile) | **POST** /api/files | [EXPERIMENTAL] Uploads a file to Lusid Drive.
[**DeleteFile**](FilesApi.md#deletefile) | **DELETE** /api/files/{id} | [EXPERIMENTAL] Deletes a file from Drive.
[**DownloadFile**](FilesApi.md#downloadfile) | **GET** /api/files/{id}/contents | [EXPERIMENTAL] Download the file from Drive.
[**GetFile**](FilesApi.md#getfile) | **GET** /api/files/{id} | [EXPERIMENTAL] Get a file stored in Drive.
[**UpdateFileContents**](FilesApi.md#updatefilecontents) | **PUT** /api/files/{id}/contents | [EXPERIMENTAL] Updates contents of a file in Drive.
[**UpdateFileMetadata**](FilesApi.md#updatefilemetadata) | **PUT** /api/files/{id} | [EXPERIMENTAL] Updates metadata for a file in Drive.



## CreateFile

> StorageObject CreateFile (string xLusidDriveFilename, string xLusidDrivePath, int? contentLength, byte[] body = null)

[EXPERIMENTAL] Uploads a file to Lusid Drive.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class CreateFileExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(Configuration.Default);
            var xLusidDriveFilename = xLusidDriveFilename_example;  // string | File name.
            var xLusidDrivePath = xLusidDrivePath_example;  // string | File path.
            var contentLength = 56;  // int? | File size.
            var body = {"x-lusid-drive-filename":"filename","x-lusid-drive-path":"/file/path","content-Length":"123"};  // byte[] | File contents. (optional) 

            try
            {
                // [EXPERIMENTAL] Uploads a file to Lusid Drive.
                StorageObject result = apiInstance.CreateFile(xLusidDriveFilename, xLusidDrivePath, contentLength, body);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
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
 **contentLength** | **int?**| File size. | 
 **body** | **byte[]**| File contents. | [optional] 

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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteFile

> void DeleteFile (string id)

[EXPERIMENTAL] Deletes a file from Drive.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class DeleteFileExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(Configuration.Default);
            var id = id_example;  // string | Identifier of the file to be deleted.

            try
            {
                // [EXPERIMENTAL] Deletes a file from Drive.
                apiInstance.DeleteFile(id);
            }
            catch (ApiException e)
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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DownloadFile

> System.IO.Stream DownloadFile (string id)

[EXPERIMENTAL] Download the file from Drive.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class DownloadFileExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(Configuration.Default);
            var id = id_example;  // string | Identifier of the file to be downloaded.

            try
            {
                // [EXPERIMENTAL] Download the file from Drive.
                System.IO.Stream result = apiInstance.DownloadFile(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
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
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetFile

> StorageObject GetFile (string id)

[EXPERIMENTAL] Get a file stored in Drive.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class GetFileExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(Configuration.Default);
            var id = id_example;  // string | Identifier of the file to be retrieved.

            try
            {
                // [EXPERIMENTAL] Get a file stored in Drive.
                StorageObject result = apiInstance.GetFile(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpdateFileContents

> StorageObject UpdateFileContents (string id, byte[] body = null)

[EXPERIMENTAL] Updates contents of a file in Drive.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class UpdateFileContentsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(Configuration.Default);
            var id = id_example;  // string | Identifier of the file.
            var body = {"path":"/New/parent/folder/path","name":"new-file-name"};  // byte[] | File contents. (optional) 

            try
            {
                // [EXPERIMENTAL] Updates contents of a file in Drive.
                StorageObject result = apiInstance.UpdateFileContents(id, body);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
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
 **id** | **string**| Identifier of the file. | 
 **body** | **byte[]**| File contents. | [optional] 

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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpdateFileMetadata

> StorageObject UpdateFileMetadata (string id, UpdateFile updateFile)

[EXPERIMENTAL] Updates metadata for a file in Drive.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Example
{
    public class UpdateFileMetadataExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-ci.lusid.com/drive";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FilesApi(Configuration.Default);
            var id = id_example;  // string | Identifier of the file to be updated
            var updateFile = new UpdateFile(); // UpdateFile | Update to be applied to file

            try
            {
                // [EXPERIMENTAL] Updates metadata for a file in Drive.
                StorageObject result = apiInstance.UpdateFileMetadata(id, updateFile);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

