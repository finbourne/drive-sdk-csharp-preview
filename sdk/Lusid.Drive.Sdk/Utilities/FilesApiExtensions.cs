using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.WebSockets;
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

            var restClient = new ApiClient(api.Configuration.BasePath);

            RequestOptions localVarRequestOptions = new RequestOptions();
            
            String[] _contentTypes = new String[] {
                "application/octet-stream"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Drive.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Drive.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.HeaderParameters.Add("Content-Length", ClientUtils.ParameterToString(contentLength)); // header parameter
            localVarRequestOptions.Data = body;
            
            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(api.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + api.Configuration.AccessToken);
            }
            
            // Set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", typeof(FilesApiExtensions).Assembly.GetName().Version?.ToString());
            
            var configuration = new Configuration();
            
            var localVarResponse = await restClient.PutAsync<StorageObject>(fileApiEndpointPath, localVarRequestOptions, configuration).ConfigureAwait(false);
            
            // Exception Handling
            if (api.ExceptionFactory != null)
            {
                Exception _exception = api.ExceptionFactory("UpdateFileContents", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse.Data;
        }
    }
}