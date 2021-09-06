using System;
using System.IO;
using System.Linq;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Extensions;
using Lusid.Drive.Sdk.Model;
using Lusid.Drive.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Drive.Sdk.Tests
{
    [TestFixture]
    public class ExtensionTests
    {
        private string _testFolderName;
        private ILusidApiFactory _factory;
        private IFoldersApi _foldersApi;
        private IFilesApi _filesApi;
        private string _testFolderId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _testFolderName = "Test_Folder" + Guid.NewGuid();
            _factory = EnvironmentCheck.FactoryForEnvironment();
            _filesApi = _factory.Api<IFilesApi>();
            _foldersApi = _factory.Api<IFoldersApi>();
        }

        [SetUp]
        public void SetUp()
        {
            _testFolderId = _foldersApi.GetRootFolder(filter: $"Name eq '{_testFolderName}'").Values.SingleOrDefault()?.Id;
            var createFolder = new CreateFolder("/", _testFolderName);
            _testFolderId ??= _foldersApi.CreateFolder(createFolder).Id;
        }

        [TearDown]
        public void TearDown()
        {
            _foldersApi.DeleteFolder(_testFolderId);
        }
        
        [Test]
        public void UploadAsStreamAsync_EmptyStream_Throws400()
        {
            var data = new MemoryStream();

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload an empty Stream
            var exception = Assert.ThrowsAsync<ApiException>(() =>
                _filesApi.UploadAsStreamAsync(fileName, "/",  (int) data.Length, data));
            Assert.AreEqual(exception.ErrorCode, 400);
        }
        
        [Test]
        public void DownloadAsStreamAsync_IncorrectId_Throws404()
        {
            //Download a file that doesn't exist
            var exception = Assert.ThrowsAsync<ApiException>(() => 
                _filesApi.DownloadAsStreamAsync(Guid.NewGuid().ToString()));
            Assert.AreEqual(exception.ErrorCode, 404);
        }

        [Test]
        public void DownloadAsStreamAsync_WrongFormatId_Throws400()
        {
            //Download a file with an non Guid ID
            var exception = Assert.ThrowsAsync<ApiException>(() => _filesApi.DownloadAsStreamAsync("NotAnProperId"));
            Assert.AreEqual(exception.ErrorCode, 400);
        }
    }
}