using System;
using System.IO;
using System.Linq;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;
using Lusid.Drive.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Drive.Sdk.Tests.Tutorials
{
    [TestFixture]
    public class FoldersTutorial
    {
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
        public void Delete_Folder()
        {
            Stream data = RandomData.OfSize(100);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();

            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);
            StorageObject folder = _foldersApi.CreateFolder(createFolder);

            //Upload a file
            StorageObject upload =
                _filesApi.CreateFile(fileName, _testFolder + "/" + folderName, (int) data.Length, data);

            //Delete folder and file
            _foldersApi.DeleteFolder(folder.Id);

            Assert.Throws<ApiException>(() => _filesApi.GetFile(upload.Id));
            Assert.Throws<ApiException>(() => _foldersApi.GetFolder(folder.Id));
        }

        [Test]
        public void List_Folder_Contents()
        {
            Stream data = RandomData.OfSize(100);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload a file
            StorageObject upload = _filesApi.CreateFile(fileName, _testFolder, (int) data.Length, data);

            //List folder contents
            PagedResourceListOfStorageObject contents = _foldersApi.GetFolderContents(_testFolderId);

            CollectionAssert.Contains(contents.Values.Select(x => x.Name), upload.Name);
        }

        [Test]
        public void List_Root_Folder_Contents()
        {
            var pageSize = 5;

            //List root folder contents
            PagedResourceListOfStorageObject contents = _foldersApi.GetRootFolder(limit: pageSize);

            Assert.That(contents.Values.Count, Is.LessThanOrEqualTo(pageSize));
        }

        [Test]
        public void Move_Folder()
        {
            //Create a unique folder name
            var folderName1 = Guid.NewGuid().ToString();

            Stream data = RandomData.OfSize(100);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Create a folder
            var createFolder1 = new CreateFolder(_testFolder, folderName1);
            StorageObject folder1 = _foldersApi.CreateFolder(createFolder1);

            //Upload a file
            StorageObject file =
                _filesApi.CreateFile(fileName, _testFolder + "/" + folderName1, (int) data.Length, data);

            //Create another unique folder name
            var folderName2 = Guid.NewGuid().ToString();

            //Create another folder
            var createFolder2 = new CreateFolder(_testFolder, folderName2);
            _foldersApi.CreateFolder(createFolder2);

            //Move folder and file
            var folderUpdate = new UpdateFolder(_testFolder + "/" + folderName2, folderName1);
            StorageObject updatedFolder = _foldersApi.UpdateFolder(folder1.Id, folderUpdate);

            Assert.AreEqual(updatedFolder.Path + "/" + updatedFolder.Name, _filesApi.GetFile(file.Id).Path);
            Assert.AreNotEqual(file.Path, _filesApi.GetFile(file.Id).Path);
        }

        [Test]
        public void Rename_Folder()
        {
            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();

            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);
            StorageObject folder = _foldersApi.CreateFolder(createFolder);

            //Create another unique folder name
            var newFolderName = Guid.NewGuid().ToString();

            //Create UpdateFolder DTO
            var update = new UpdateFolder(_testFolder, newFolderName);

            //Rename folder
            StorageObject renameFolder = _foldersApi.UpdateFolder(folder.Id, update);

            Assert.AreEqual(folder.Id, renameFolder.Id);
            Assert.AreEqual(newFolderName, renameFolder.Name);
        }

        private string _testFolder;
        private string _testFolderName;
        private ILusidApiFactory _factory;
        private IFoldersApi _foldersApi;
        private IFilesApi _filesApi;
        private string _testFolderId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _testFolderName = "Test_Folder" + Guid.NewGuid();
            _testFolder = "/" + _testFolderName;
            _factory = LusidApiFactoryBuilder.Build("secrets.json");
            _filesApi = _factory.Api<IFilesApi>();
            _foldersApi = _factory.Api<IFoldersApi>();
        }
    }
}
