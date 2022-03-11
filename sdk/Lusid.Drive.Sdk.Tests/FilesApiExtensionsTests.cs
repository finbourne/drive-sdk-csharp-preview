using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            _testFolderId = _foldersApi.GetRootFolder(filter: $"Name eq '{_testFolderName}'").Values.SingleOrDefault()
                ?.Id;
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
                _filesApi.UploadAsStreamAsync(fileName, "/", (int)data.Length, data));
            Assert.AreEqual(exception.ErrorCode, 400);
        }

        [Test]
        [Explicit(
            "This test creates a very large in memory file and is not suitable for running on CI/CD. It is a local test to prove large files can be uploaded. To make it part of CI/CD think of an alternate approach.")]
        public async Task UploadAsStreamAsync_LargeFileSuceeds()
        {
            var fileSizeBytes = 490000000;
            var enumerable =
                Enumerable.Repeat(Byte.MinValue,
                    fileSizeBytes); // ~450MB (Drive currently has a limit of 500MB which is being increased)
            var data = new MemoryStream(enumerable.ToArray());
            
            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            _filesApi.Configuration = Configuration.MergeConfigurations(_filesApi.Configuration,
                new Configuration() { Timeout = 1000 * 60 * 30 }); // 30 min timeout for large files

            var sut = await _filesApi.UploadAsStreamAsync(fileName, "/", (int)data.Length, data);
            Assert.GreaterOrEqual(sut.Size, fileSizeBytes);
            Assert.IsNotNull(sut.Id);

            var fileId = sut.Id;
            _filesApi.DeleteFile(fileId);
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