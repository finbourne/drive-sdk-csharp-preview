using System;
using System.IO;
using System.Linq;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;
using Lusid.Drive.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Drive.Sdk.Tests
{
    public class FilesApiTests
    {
        private ILusidApiFactory _factory;
        private IFilesApi _filesApi;

        [OneTimeSetUp]
        public void SetUp()
        {
            _factory = LusidApiFactoryBuilder.Build();
            _filesApi = _factory.Api<IFilesApi>();
            var foldersApi = _factory.Api<IFoldersApi>();

            string testFolderId = foldersApi.GetRootFolder(filter: "Name eq 'SDK_Test_Folder'").Values.SingleOrDefault()
                ?.Id;
            if (testFolderId == null)
            {
                var createFolder = new CreateFolder("/", "SDK_Test_Folder");
                foldersApi.CreateFolder(createFolder);
            }
        }

        [Test]
        public void Create_Rename_Download_Delete_File()
        {
            var fileName = Guid.NewGuid().ToString();
            Stream data = RandomData.OfSize(50);
            StorageObject create = _filesApi.CreateFile(fileName, "/SDK_Test_Folder", 50, data);
            Assert.That(create.Name, Is.EqualTo(fileName));
            Assert.That(create.Path, Is.EqualTo("/SDK_Test_Folder"));

            var newName = Guid.NewGuid().ToString();
            var updateFile = new UpdateFile("/SDK_Test_Folder", newName);
            StorageObject update = _filesApi.UpdateFileMetadata(create.Id, updateFile);
            Assert.That(update.Name, Is.EqualTo(newName));
            Assert.That(update.Path, Is.EqualTo("/SDK_Test_Folder"));
            Assert.That(update.Id, Is.EqualTo(create.Id));

            Stream download = _filesApi.DownloadFile(update.Id);
            var endData = new byte[50];
            download.Read(endData);
            Assert.That(endData, Is.EqualTo(data));

            _filesApi.DeleteFile(update.Id);
            Assert.Throws<ApiException>(() => _filesApi.GetFile(create.Id));
        }
    }
}
