using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;
using RestSharp;

namespace Lusid.Drive.Sdk.Extensions
{
    /// <summary>
    /// Represents a collection of Extension Methods to interact with Rest Sharp using a Stream instead of a byte array
    /// </summary>
    public static class FilesApiExtensions
    {
        /// <summary>
        ///     Uploads data to a file as a stream instead of as a byte array.
        ///     The function is asynchronous as RestSharp only offers asynchronous methods.
        ///     This method was created in order to support file uploads as Streams as this is less taxing on memory
        ///     than byte arrays. This would be better for large file uploads or in the case where multiple users are
        ///     uploading at the same time, causing a lot of memory to be consumed.
        /// </summary>
        /// <param name="xLusidDriveFilename">File name.</param>
        /// <param name="xLusidDrivePath">File path.</param>
        /// <param name="contentLength">The size in bytes of the file to be uploaded</param>
        /// <param name="body">The data to upload</param>
        /// <returns>Storage Object as a Task</returns>
        public static async Task<StorageObject> UploadAsStreamAsync(this IFilesApi api,
            string xLusidDriveFilename,
            string xLusidDrivePath,
            int? contentLength,
            Stream body)
        {
            // Verify that 'xLusidDriveFilename' is set
            if (xLusidDriveFilename == null)
            {
                throw new ApiException(400, 
                    "Missing required parameter 'xLusidDriveFilename' when calling FilesApiExtensions->UploadAsStreamAsync");
            }

            // Verify that 'xLusidDrivePath' is set
            if (xLusidDrivePath == null)
            {
                throw new ApiException(400,
                    "Missing required parameter 'xLusidDrivePath' when calling FilesApiExtensions->UploadAsStreamAsync");
            }

            // Verify that 'contentLength' is set
            if (contentLength == null)
            {
                throw new ApiException(400, 
                    "Missing required parameter 'contentLength' when calling FilesApiExtensions->UploadAsStreamAsync");
            }

            // Endpoint to POST new file
            const string fileApiEndpointPath = "./api/files";
            
            // Set default parameters
            var localVarHeaderParams = new Dictionary<string, string>(api.Configuration.DefaultHeader);

            // Set the Content-Type header
            var localVarHttpContentTypes = new[] {"application/octet-stream"};
            var localVarHttpContentType = api.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // Set the Accept header
            var localVarHttpHeaderAccepts = new[] {"text/plain", "application/json", "text/json"};
            var localVarHttpHeaderAccept = api.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            
            if (localVarHttpHeaderAccept != null)
            {
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);
            }
            
            localVarHeaderParams.Add("x-lusid-drive-filename", api.Configuration.ApiClient.ParameterToString(xLusidDriveFilename));
            localVarHeaderParams.Add("x-lusid-drive-path", api.Configuration.ApiClient.ParameterToString(xLusidDrivePath));
            localVarHeaderParams.Add("Content-Length", api.Configuration.ApiClient.ParameterToString(contentLength));
            
            // Authentication (oauth2) required
            if (!string.IsNullOrEmpty(api.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + api.Configuration.AccessToken;
            }

            // Set the LUSID header
            localVarHeaderParams["X-LUSID-Sdk-Language"] = "C#";
            localVarHeaderParams["X-LUSID-Sdk-Version"] = typeof(FilesApiExtensions).Assembly.GetName().Version?.ToString();

            // Get a rest client
            var restClient = api.Configuration.ApiClient.RestClient;
            
            // Create a rest request with the created parameters
            var restRequest = new RestRequest(fileApiEndpointPath, Method.POST) {Serializer = null};

            // Create a parameters list for the HTTP request message 
            var parameters = CreateParameters(body, localVarHeaderParams, localVarHttpContentType);
            
            // Create a HTTP request message with a stream as content
            var requestMessage = restClient.HttpClientFactory.CreateRequestMessage(restClient, restRequest, 
            parameters);
            requestMessage.Content = new DefaultHttpContent(new StreamContent(body));
            requestMessage.Content.Headers.Add("Content-Length", api.Configuration.ApiClient.ParameterToString(contentLength));
            
            // Get a HTTP client from the rest client's HTTP client factory
            var httpClient = restClient.HttpClientFactory.CreateClient(restClient);
            
            // Send the HTTP request message
            var httpResponseMessage = await httpClient.SendAsync(requestMessage, CancellationToken.None);
            
            // Convert the HTTP response message to a REST response message
            var restResponseMessage =
                await RestResponse.CreateResponse(restClient, restRequest, httpResponseMessage, CancellationToken.None);

            // Exception Handling
            var exception = api.ExceptionFactory?.Invoke("UploadAsStreamAsync", restResponseMessage);
            if (exception != null)
            {
                throw exception;
            }

            return (StorageObject) api.Configuration.ApiClient.Deserialize(restResponseMessage, typeof(StorageObject));
        }
        
        /// <summary>
        ///     Downloads data to a file as a stream instead of as a byte array.
        ///     The function is asynchronous as RestSharp only offers asynchronous methods.
        ///     This method was created in order to support file downloads as Streams as this is less taxing on memory
        ///     than byte arrays. This would be better for large file downloads or in the case where multiple users are
        ///     downloading at the same time, causing a lot of memory to be consumed.
        /// </summary>
        /// <param name="id">ID of the file to download</param>
        /// <returns>The downloaded Stream as a Task</returns>
        public static async Task<Stream> DownloadAsStreamAsync(this IFilesApi api, string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new ApiException(400, "Missing required parameter 'id' when calling FilesApiExtensions->DownloadAsStreamAsync");
            }

            // Endpoint to GET new file
            const string fileApiEndpointPath = "./api/files/{id}/contents";
            
            // Set default parameters
            var localVarPathParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(api.Configuration.DefaultHeader);

            // Set the Content-Type header
            string[] localVarHttpContentTypes = {};
            string localVarHttpContentType = api.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // Set the Accept header
            string[] localVarHttpHeaderAccepts = {"text/plain", "application/json", "text/json"};
            var localVarHttpHeaderAccept = api.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            
            if (localVarHttpHeaderAccept != null)
            {
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);
            }
            
            // Set the Path Parameter
            localVarPathParams.Add("id", api.Configuration.ApiClient.ParameterToString(id)); // path parameter

            // Authentication (oauth2) required
            if (!string.IsNullOrEmpty(api.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + api.Configuration.AccessToken;
            }

            // Set the LUSID header
            localVarHeaderParams["X-LUSID-Sdk-Language"] = "C#";
            localVarHeaderParams["X-LUSID-Sdk-Version"] = typeof(FilesApiExtensions).Assembly.GetName().Version?.ToString();

            // Get a rest client
            var restClient = api.Configuration.ApiClient.RestClient;
            
            // Create a rest request with the created parameters
            var restRequest = new RestRequest(fileApiEndpointPath, Method.GET) {Serializer = null};
            foreach (var (key, value) in localVarPathParams)
            {
                restRequest.AddParameter(key, value, ParameterType.UrlSegment);
            }

            // Create a parameters list for the HTTP request message 
            var parameters = CreateParameters(null, localVarHeaderParams, localVarHttpContentType);
            
            // Create a HTTP request message
            var requestMessage = restClient.HttpClientFactory.CreateRequestMessage(restClient, restRequest, 
            parameters);

            // Get a HTTP client from the rest client's HTTP client factory
            var httpClient = restClient.HttpClientFactory.CreateClient(restClient);
            
            // Send the HTTP request message
            var httpResponseMessage = await httpClient.SendAsync(requestMessage, CancellationToken.None);
                
            // Convert the HTTP response message to a REST response message
            var restResponseMessage =
                await RestResponse.CreateResponse(restClient, restRequest, httpResponseMessage, CancellationToken.None);

            // Exception Handling
            var exception = api.ExceptionFactory?.Invoke("DownloadAsStreamAsync", restResponseMessage);
            if (exception != null)
            {
                throw exception;
            }

            return (Stream) api.Configuration.ApiClient.Deserialize(restResponseMessage, typeof(Stream));
        }

        private static IList<Parameter> CreateParameters(
            object postBody,
            Dictionary<string, string> headerParams,
            string contentType)
        {
            var parameters = new List<Parameter>();

            // Add header parameters, except for the 'Content-Length' parameter - it's added directly to the
            // HttpRequestMessage.Content property
            foreach (var (key, value) in headerParams)
            {
                if (key != "Content-Length")
                {
                    parameters.Add(CreateParameter(key, value, ParameterType.HttpHeader));
                }
            }

            // Add the stream as the body of the request
            if (postBody != null)
            {
                parameters.Add(new Parameter
                {
                    Value = postBody, 
                    Type = ParameterType.RequestBody, 
                    ContentType = contentType
                });
            }

            return parameters;
        }

        /// <summary>
        ///     Create a parameter for creating a http request message
        /// </summary>
        /// <param name="name">Name of the parameter</param>
        /// <param name="value">Value of the parameter</param>
        /// <param name="type">Type of the parameter</param>
        /// <returns>The newly created parameter</returns>
        private static Parameter CreateParameter(string name, object value, ParameterType type)
        {
            return new Parameter {Name = name, Value = value, Type = type};
        }
    }
}