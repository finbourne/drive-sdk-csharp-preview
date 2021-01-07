using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Model;
using Lusid.Drive.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Drive.Sdk.Tests.Tutorials
{
    [TestFixture]
    public class FilesTutorial
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
        public void Copy_File()
        {
            Stream data1 = RandomData.OfSize(100);

            //Create a unique file name
            var fileName1 = Guid.NewGuid().ToString();

            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();

            //Upload a file
            StorageObject upload = _filesApi.CreateFile(fileName1, _testFolder, (int) data1.Length, data1);

            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);

            StorageObject folder = _foldersApi.CreateFolder(createFolder);

            //Move files to folder
            PagedResourceListOfStorageObject movedFile =
                _foldersApi.MoveFolder(folder.Id, new List<string> {upload.Id}, deleteSource: false);

            CollectionAssert.Contains(movedFile.Values.Select(x => x.Name), upload.Name);
            Assert.AreEqual(upload.Name, _filesApi.GetFile(upload.Id).Name);
        }

        [Test]
        public void Delete_File()
        {
            Stream data = RandomData.OfSize(100);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload file
            StorageObject upload = _filesApi.CreateFile(fileName, _testFolder, (int) data.Length, data);

            //Delete file
            _filesApi.DeleteFile(upload.Id);

            CollectionAssert.IsEmpty(_foldersApi.GetFolderContents(_testFolderId, filter: $"Name eq '{upload.Name}'")
                .Values);
        }

        [Test]
        public void Download_File()
        {
            Stream uploadedFile = RandomData.OfSize(100);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload a file
            StorageObject upload = _filesApi.CreateFile(fileName, _testFolder, (int) uploadedFile.Length, uploadedFile);

            //Download file
            byte[] downloadedFile = _filesApi.DownloadFile(upload.Id).ReadAsBytes();

            Assert.AreEqual(uploadedFile, downloadedFile);
        }

        [Test]
        public void Move_File()
        {
            Stream data = RandomData.OfSize(100);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();

            //Upload a file
            StorageObject upload = _filesApi.CreateFile(fileName, _testFolder, (int) data.Length, data);

            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);
            StorageObject folder = _foldersApi.CreateFolder(createFolder);

            //Create UpdateFile DTO
            var update = new UpdateFile(_testFolder + "/" + folder.Name, fileName);

            //Move a file
            StorageObject movedFile = _filesApi.UpdateFileMetadata(upload.Id, update);

            Assert.AreEqual(upload.Id, movedFile.Id);
            Assert.AreEqual(_testFolder + "/" + folder.Name, movedFile.Path);
        }

        [Test]
        public void Move_File_With_Overwrite()
        {
            Stream data1 = RandomData.OfSize(100);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();

            //Upload a file
            StorageObject upload = _filesApi.CreateFile(fileName, _testFolder, (int) data1.Length, data1);

            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);
            StorageObject folder = _foldersApi.CreateFolder(createFolder);

            Stream data2 = RandomData.OfSize(100);

            //Upload the second file
            _filesApi.CreateFile(fileName, _testFolder + "/" + folder.Name, (int) data2.Length, data2);

            //Move files to folder
            PagedResourceListOfStorageObject movedFile =
                _foldersApi.MoveFolder(folder.Id, new List<string> {upload.Id}, true, true);

            byte[] downloadedFile = _filesApi.DownloadFile(movedFile.Values.Single(x => x.Name == upload.Name).Id)
                .ReadAsBytes();
            CollectionAssert.Contains(movedFile.Values.Select(x => x.Name), upload.Name);
            Assert.AreEqual(downloadedFile, data1);
            CollectionAssert.IsEmpty(_foldersApi.GetFolderContents(_testFolderId, filter: $"Name eq '{fileName}'")
                .Values);
        }

        [Test]
        public void Move_Files()
        {
            Stream data1 = RandomData.OfSize(100);

            //Create a unique file name
            var fileName1 = Guid.NewGuid().ToString();

            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();

            //Upload a file
            StorageObject upload = _filesApi.CreateFile(fileName1, _testFolder, (int) data1.Length, data1);

            Stream data2 = RandomData.OfSize(100);

            //Create a second unique file name
            var fileName2 = Guid.NewGuid().ToString();

            //Upload the second file
            StorageObject upload2 = _filesApi.CreateFile(fileName2, _testFolder, (int) data2.Length, data2);

            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);
            StorageObject folder = _foldersApi.CreateFolder(createFolder);

            //Move files to folder
            PagedResourceListOfStorageObject movedFile =
                _foldersApi.MoveFolder(folder.Id, new List<string> {upload.Id, upload2.Id});

            CollectionAssert.Contains(movedFile.Values.Select(x => x.Name), upload.Name);
            CollectionAssert.Contains(movedFile.Values.Select(x => x.Name), upload2.Name);
        }

        [Test]
        public void Rename_File()
        {
            Stream data = RandomData.OfSize(100);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload a file
            StorageObject upload = _filesApi.CreateFile(fileName, _testFolder, (int) data.Length, data);

            //Create new unique file name
            var newFileName = Guid.NewGuid().ToString();

            //Create UpdateFile DTO
            var update = new UpdateFile(_testFolder, newFileName);

            //Rename file
            StorageObject renamedFile = _filesApi.UpdateFileMetadata(upload.Id, update);

            Assert.AreEqual(upload.Id, renamedFile.Id);
            Assert.AreEqual(newFileName, renamedFile.Name);
        }

        [Test]
        public void Update_File_Contents()
        {
            Stream data = RandomData.OfSize(100);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload a file
            StorageObject upload = _filesApi.CreateFile(fileName, _testFolder, (int) data.Length, data);

            //Create new file data
            Stream newData = RandomData.OfSize(200);

            //Update file contents
            StorageObject updatedFile = _filesApi.UpdateFileContents(upload.Id, (int) newData.Length, newData);

            Assert.AreEqual(200, updatedFile.Size);

            //Create buffer for download
            var downloadedFile = new byte[200];

            //Download file
            _filesApi.DownloadFile(upload.Id).Read(downloadedFile);

            Assert.AreEqual(newData, downloadedFile);
        }

        [Test]
        public void Upload_File()
        {
            Stream data = RandomData.OfSize(100);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload a file
            StorageObject upload = _filesApi.CreateFile(fileName, _testFolder, (int) data.Length, data);

            Assert.AreEqual(fileName, upload.Name);
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
