using System;
using System.Net;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;
using Newtonsoft.Json;

namespace Lusid.Drive.Sdk.Utilities
{
    /// <summary>
    /// ApiException extensions
    /// </summary>
    public static class ApiExceptionExtensions
    {
        /// <summary>
        /// Identify whether the API exception was caused by a request validation problem
        /// </summary>
        public static bool IsValidationProblem(this ApiException ex)
        {
            return ex.ErrorCode == (int) HttpStatusCode.BadRequest;
        }

        /// <summary>
        /// Try and get the details of a validation problem, if there are any
        /// </summary>
        public static bool TryGetValidationProblemDetails(this ApiException ex,
            out LusidValidationProblemDetails details)
        {
            if (IsValidationProblem(ex))
            {
                details = ValidationProblemDetails(ex);
                return true;
            }

            details = null;
            return false;
        }
        
        /// <summary>
        /// Return details of the validation problem
        /// </summary>
        public static LusidValidationProblemDetails ValidationProblemDetails(this ApiException ex)
        {
            if (ex.ErrorContent == null)
            {
                return null;
            }
            
            //    ApiException.ErrorContent contains a JSON serialized ValidationProblemDetails
            return JsonConvert.DeserializeObject<LusidValidationProblemDetails>(ex.ErrorContent.ToString(), new JsonConverter[]
            {
                new PropertyBasedConverter(),
            });
        }

        /// <summary>
        /// Return details of the problem
        /// </summary>
        public static LusidProblemDetails ProblemDetails(this ApiException ex)
        {
            if (ex.ErrorContent == null)
            {
                return null;
            }

            //    ApiException.ErrorContent contains a JSON serialized ProblemDetails
            try
            {
                return JsonConvert.DeserializeObject<LusidProblemDetails>(ex.ErrorContent.ToString(), new JsonConverter[]
                {
                    new PropertyBasedConverter(),
                });
            }
            catch (JsonException jsonException)
            {
                throw new InvalidOperationException($"Failed to parse ProblemDetails: {jsonException.Message}{Environment.NewLine}{ex.ErrorContent}");
            }
        }
    }
}