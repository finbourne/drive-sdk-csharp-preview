using System;
using System.Linq;
using System.Threading.Tasks;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;

namespace Lusid.Drive.Sdk.Utilities
{
    /// <summary>
    /// Represents a collection of methods to add functionality ontop of the Folders Api
    /// </summary>
    public class FoldersApiExtensions
    {
        private readonly IFoldersApi _foldersApi;

        /// <summary>
        /// Builds a FoldersApiExtensions using a provided FoldersApi
        /// </summary>
        /// <param name="foldersApi"></param>
        public FoldersApiExtensions(IFoldersApi foldersApi)
        {
            _foldersApi = foldersApi;
        }

        /// <summary>
        /// Given a path, will create all folders in that path, even if some already exist.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        public StorageObject CreateAllFoldersInPath(string path)
        {
            path = path.Trim('/');
            if (String.IsNullOrEmpty(path))
                throw new ApiException(157, "Invalid Path Provided, please supply one or more folders to be created");

            var folderPaths = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            StorageObject folderThusFar = null;
            var pathThusFar = "/";

            foreach (var folderPath in folderPaths)
            {
                // Try to create the folder
                try
                {
                    var createFolder = new CreateFolder(pathThusFar, folderPath);
                    folderThusFar = _foldersApi.CreateFolder(createFolder);
                }
                // catch any exceptions
                // in the case the folder already exists, we do not want to throw as this is expected
                catch (ApiException e)
                {
                    var errorResponse = e.ProblemDetails();
                    if (errorResponse == null ||
                        errorResponse.Code != Finbourne.Errors.ErrorCodes.FolderAlreadyExists) throw;
                    
                    // Get the folder that has the same name.
                    // Do not need to worry about paging, as there can only be one folder with the same name
                    if (pathThusFar == "/")
                    {
                        folderThusFar =
                            _foldersApi.GetRootFolder(filter: $"Name eq '{folderPath}' AND Type eq 'Folder'").Values.SingleOrDefault();
                    }
                    else
                    {
                        folderThusFar = _foldersApi
                            .GetFolderContents(id: folderThusFar!.Id,
                                filter: $"Name eq '{folderPath}' AND Type eq 'Folder'").Values.SingleOrDefault();
                    }
                    
                }

                pathThusFar += folderPath + "/";
            }

            return folderThusFar;
        }
    }
}