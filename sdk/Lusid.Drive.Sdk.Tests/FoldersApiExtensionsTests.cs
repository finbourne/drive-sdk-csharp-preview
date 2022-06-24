using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;
using Lusid.Drive.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Drive.Sdk.Tests
{
    public class FoldersApiExtensionsTests
    {
        private ILusidApiFactory _factory;
        private IFoldersApi _foldersApi;
        private FoldersApiExtensions _foldersApiExtensions;

        [OneTimeSetUp]
        public void SetUp()
        {
            _factory = EnvironmentCheck.FactoryForEnvironment();
            _foldersApi = _factory.Api<IFoldersApi>();
            _foldersApiExtensions = new FoldersApiExtensions(_foldersApi);
        }

        [Test]
        public void CreateNewDirectoryReturnsStorageObject()
        {
            var folderPath = "/test/path/to/folder/";
            var folderName = Guid.NewGuid().ToString();

            var newFolder = _foldersApiExtensions.CreateAllFoldersInPath(folderPath + folderName);
            
            Assert.AreEqual(folderPath.TrimEnd('/'), newFolder.Path);
            Assert.AreEqual(folderName, newFolder.Name);
        }

        [Test]
        public void CreateDirectoryTwiceReturnsSameObject()
        {
            var folderPath = "/test/path/to/folder/";
            var folderName = Guid.NewGuid().ToString();

            var newFolder = _foldersApiExtensions.CreateAllFoldersInPath(folderPath + folderName);
            var newFolderDuplicate = _foldersApiExtensions.CreateAllFoldersInPath(folderPath + folderName);
            
            Assert.AreEqual(newFolder.Id, newFolderDuplicate.Id);
        }

        [Test]
        public void CreateRootDirectoryThrowsException()
        {
            Assert.Throws(typeof(ApiException), () => _foldersApiExtensions.CreateAllFoldersInPath("/"));
        }

        [Test]
        public void CreateLongDirectoryThrowsException()
        {
            var longFilePath = new string('a', 1025);
            Assert.Throws(typeof(ApiException), () => _foldersApiExtensions.CreateAllFoldersInPath(longFilePath));
        }

        [Test]
        public void CreateFolderOneLevelDeep()
        {
            var folderPath = "/" + Guid.NewGuid() + "/";

            var newFolder = _foldersApiExtensions.CreateAllFoldersInPath(folderPath);
            
            Assert.AreEqual(folderPath.Trim('/'), newFolder.Name);
            Assert.AreEqual("/", newFolder.Path);
        }
        
    }
}