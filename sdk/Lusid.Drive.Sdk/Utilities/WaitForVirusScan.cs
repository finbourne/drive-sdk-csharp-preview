using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lusid.Drive.Sdk.Utilities
{
    /// <summary>
    /// Use polly library to retry and wait for file to pass virus scan
    /// </summary>
    public class WaitForVirusScan
    {
        private readonly IFilesApi _filesApi;
        AsyncRetryPolicy _policy;

        /// <summary>
        /// Set retry policy to try up to 20 times, every 15 seconds.
        /// </summary>
        /// <param name="filesApi"></param>
        public WaitForVirusScan(IFilesApi filesApi)
        {
            _filesApi = filesApi;
            _policy = 
                Policy
                .Handle<ApiException>(e => e.ErrorCode == 423 /* Virus scan in progress */)
                .WaitAndRetryAsync(
                    20,
                    sleepDurationProvider: (retryNumber) =>
                    {
                        Console.WriteLine($"retrying {retryNumber}");
                        return TimeSpan.FromSeconds(15);
                    });
        }

        /// <summary>
        /// Asynchronously download file with a retry
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public async Task<Stream> DownloadFileWithRetry(string fileId)
        {
            var r = await _policy.ExecuteAsync(async () => await _filesApi.DownloadFileAsync(fileId));
            return r;
        }
    }    
}
