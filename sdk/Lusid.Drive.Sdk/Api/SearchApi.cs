/*
 * FINBOURNE Drive API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.1.409
 * Contact: info@finbourne.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Lusid.Drive.Sdk.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISearchApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// [EARLY ACCESS] Search: Search for a file or folder with a given name and path
        /// </summary>
        /// <exception cref="Lusid.Drive.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchBody">Search parameters</param>
        /// <param name="page"> (optional)</param>
        /// <param name="sortBy"> (optional)</param>
        /// <param name="limit"> (optional)</param>
        /// <param name="filter"> (optional, default to &quot;&quot;)</param>
        /// <returns>PagedResourceListOfStorageObject</returns>
        PagedResourceListOfStorageObject Search(SearchBody searchBody, string page = default(string), List<string> sortBy = default(List<string>), int? limit = default(int?), string filter = default(string));

        /// <summary>
        /// [EARLY ACCESS] Search: Search for a file or folder with a given name and path
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Lusid.Drive.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchBody">Search parameters</param>
        /// <param name="page"> (optional)</param>
        /// <param name="sortBy"> (optional)</param>
        /// <param name="limit"> (optional)</param>
        /// <param name="filter"> (optional, default to &quot;&quot;)</param>
        /// <returns>ApiResponse of PagedResourceListOfStorageObject</returns>
        ApiResponse<PagedResourceListOfStorageObject> SearchWithHttpInfo(SearchBody searchBody, string page = default(string), List<string> sortBy = default(List<string>), int? limit = default(int?), string filter = default(string));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISearchApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// [EARLY ACCESS] Search: Search for a file or folder with a given name and path
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Lusid.Drive.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchBody">Search parameters</param>
        /// <param name="page"> (optional)</param>
        /// <param name="sortBy"> (optional)</param>
        /// <param name="limit"> (optional)</param>
        /// <param name="filter"> (optional, default to &quot;&quot;)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfStorageObject</returns>
        System.Threading.Tasks.Task<PagedResourceListOfStorageObject> SearchAsync(SearchBody searchBody, string page = default(string), List<string> sortBy = default(List<string>), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] Search: Search for a file or folder with a given name and path
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Lusid.Drive.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchBody">Search parameters</param>
        /// <param name="page"> (optional)</param>
        /// <param name="sortBy"> (optional)</param>
        /// <param name="limit"> (optional)</param>
        /// <param name="filter"> (optional, default to &quot;&quot;)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfStorageObject)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedResourceListOfStorageObject>> SearchWithHttpInfoAsync(SearchBody searchBody, string page = default(string), List<string> sortBy = default(List<string>), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISearchApi : ISearchApiSync, ISearchApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class SearchApi : ISearchApi
    {
        private Lusid.Drive.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SearchApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SearchApi(String basePath)
        {
            this.Configuration = Lusid.Drive.Sdk.Client.Configuration.MergeConfigurations(
                Lusid.Drive.Sdk.Client.GlobalConfiguration.Instance,
                new Lusid.Drive.Sdk.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Lusid.Drive.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Lusid.Drive.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Lusid.Drive.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SearchApi(Lusid.Drive.Sdk.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = configuration;
            this.Client = new Lusid.Drive.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Lusid.Drive.Sdk.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Lusid.Drive.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public SearchApi(Lusid.Drive.Sdk.Client.ISynchronousClient client, Lusid.Drive.Sdk.Client.IAsynchronousClient asyncClient, Lusid.Drive.Sdk.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Lusid.Drive.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Lusid.Drive.Sdk.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Lusid.Drive.Sdk.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Lusid.Drive.Sdk.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Lusid.Drive.Sdk.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// [EARLY ACCESS] Search: Search for a file or folder with a given name and path 
        /// </summary>
        /// <exception cref="Lusid.Drive.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchBody">Search parameters</param>
        /// <param name="page"> (optional)</param>
        /// <param name="sortBy"> (optional)</param>
        /// <param name="limit"> (optional)</param>
        /// <param name="filter"> (optional, default to &quot;&quot;)</param>
        /// <returns>PagedResourceListOfStorageObject</returns>
        public PagedResourceListOfStorageObject Search(SearchBody searchBody, string page = default(string), List<string> sortBy = default(List<string>), int? limit = default(int?), string filter = default(string))
        {
            Lusid.Drive.Sdk.Client.ApiResponse<PagedResourceListOfStorageObject> localVarResponse = SearchWithHttpInfo(searchBody, page, sortBy, limit, filter);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] Search: Search for a file or folder with a given name and path 
        /// </summary>
        /// <exception cref="Lusid.Drive.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchBody">Search parameters</param>
        /// <param name="page"> (optional)</param>
        /// <param name="sortBy"> (optional)</param>
        /// <param name="limit"> (optional)</param>
        /// <param name="filter"> (optional, default to &quot;&quot;)</param>
        /// <returns>ApiResponse of PagedResourceListOfStorageObject</returns>
        public Lusid.Drive.Sdk.Client.ApiResponse<PagedResourceListOfStorageObject> SearchWithHttpInfo(SearchBody searchBody, string page = default(string), List<string> sortBy = default(List<string>), int? limit = default(int?), string filter = default(string))
        {
            // verify the required parameter 'searchBody' is set
            if (searchBody == null)
                throw new Lusid.Drive.Sdk.Client.ApiException(400, "Missing required parameter 'searchBody' when calling SearchApi->Search");

            Lusid.Drive.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Drive.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
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

            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Drive.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (sortBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Drive.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "sortBy", sortBy));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Drive.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Drive.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            localVarRequestOptions.Data = searchBody;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "0.1.409");

            // make the HTTP request
            var localVarResponse = this.Client.Post<PagedResourceListOfStorageObject>("/api/search", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("Search", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] Search: Search for a file or folder with a given name and path 
        /// </summary>
        /// <exception cref="Lusid.Drive.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchBody">Search parameters</param>
        /// <param name="page"> (optional)</param>
        /// <param name="sortBy"> (optional)</param>
        /// <param name="limit"> (optional)</param>
        /// <param name="filter"> (optional, default to &quot;&quot;)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfStorageObject</returns>
        public async System.Threading.Tasks.Task<PagedResourceListOfStorageObject> SearchAsync(SearchBody searchBody, string page = default(string), List<string> sortBy = default(List<string>), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Drive.Sdk.Client.ApiResponse<PagedResourceListOfStorageObject> localVarResponse = await SearchWithHttpInfoAsync(searchBody, page, sortBy, limit, filter, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] Search: Search for a file or folder with a given name and path 
        /// </summary>
        /// <exception cref="Lusid.Drive.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchBody">Search parameters</param>
        /// <param name="page"> (optional)</param>
        /// <param name="sortBy"> (optional)</param>
        /// <param name="limit"> (optional)</param>
        /// <param name="filter"> (optional, default to &quot;&quot;)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfStorageObject)</returns>
        public async System.Threading.Tasks.Task<Lusid.Drive.Sdk.Client.ApiResponse<PagedResourceListOfStorageObject>> SearchWithHttpInfoAsync(SearchBody searchBody, string page = default(string), List<string> sortBy = default(List<string>), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'searchBody' is set
            if (searchBody == null)
                throw new Lusid.Drive.Sdk.Client.ApiException(400, "Missing required parameter 'searchBody' when calling SearchApi->Search");


            Lusid.Drive.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Drive.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
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

            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Drive.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (sortBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Drive.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "sortBy", sortBy));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Drive.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Drive.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            localVarRequestOptions.Data = searchBody;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "0.1.409");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<PagedResourceListOfStorageObject>("/api/search", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("Search", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}