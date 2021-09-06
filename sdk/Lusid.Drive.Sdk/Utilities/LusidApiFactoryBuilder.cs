using System;
using System.Collections.Generic;
using Lusid.Drive.Sdk.Client;

namespace Lusid.Drive.Sdk.Utilities
{
    /// <summary>
    /// Builder class to build instances of ILusidApiFactory
    /// </summary>
    public class LusidApiFactoryBuilder
    {
        /// <summary>
        /// Create an ILusidApiFactory using the specified configuration file.  For details on the format of the configuration file see https://support.lusid.com/getting-started-with-apis-sdks
        /// </summary>
        public static ILusidApiFactory Build(string apiSecretsFilename)
        {
            var apiConfig = ApiConfigurationBuilder.Build(apiSecretsFilename);
            return new LusidApiFactory(apiConfig);
        }
        
        /// <summary>
        /// Create an ILusidApiFactory using a personal access token
        /// </summary>
        public static ILusidApiFactory Build()
        {
            Configuration config = new GlobalConfiguration(
                new Dictionary<string, string>(), new Dictionary<string, string>(), new Dictionary<string, string>()
                )
            {
                BasePath = Environment.GetEnvironmentVariable("FBN_DRIVE_API_URL") ?? Environment.GetEnvironmentVariable("fbn_drive_api_url"),
                AccessToken = Environment.GetEnvironmentVariable("FBN_ACCESS_TOKEN") ?? Environment.GetEnvironmentVariable("fbn_access_token")
            };
            return new LusidApiFactory(config);
        }
    }
}