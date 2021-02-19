using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Extensions;
using Lusid.Drive.Sdk.Model;
using Lusid.Drive.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Drive.Sdk.Tests.Tutorials
{
    [TestFixture]
    public class FilesTutorial
    {

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
        public void Upload_File()
        {
            var rnd = new Random();
            var data = new byte[100];
            rnd.NextBytes(data);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload a file
            var upload = _filesApi.CreateFile(fileName, _testFolder, data.Length, data);

            Assert.AreEqual(fileName, upload.Name);
        }
        
        [Test]
        public async Task Upload_File_As_Stream()
        {
            var data = new MemoryStream(Encoding.UTF8.GetBytes("a,b \n c,d"));

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload a file
            var upload = await _filesApi.UploadAsStreamAsync(fileName, "/",  (int) data.Length, data);
             
            Assert.AreEqual(fileName, upload.Name);
        }

        [Test]
        public void Delete_File()
        {
            var rnd = new Random();
            var data = new byte[100];
            rnd.NextBytes(data);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload file
            var upload = _filesApi.CreateFile(fileName, _testFolder, data.Length, data);

            //Delete file
            _filesApi.DeleteFile(upload.Id);

            CollectionAssert.IsEmpty(_foldersApi.GetFolderContents(_testFolderId, filter: $"Name eq '{upload.Name}'").Values);
        }

        [Test]
        public void Download_File()
        {
            var rnd = new Random();
            var uploadedFile = new byte[100];
            rnd.NextBytes(uploadedFile);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload a file
            var upload = _filesApi.CreateFile(fileName, _testFolder, uploadedFile.Length, uploadedFile);

            //Create buffer for download
            var downloadedFile = new byte[100];

            //Download file
            _filesApi.DownloadFile(upload.Id).Read(downloadedFile);

            Assert.AreEqual(uploadedFile, downloadedFile);
        }

        [Test]
        public async Task Download_File_As_Stream()
        {
            var data = new MemoryStream(Encoding.UTF8.GetBytes("a,b \n c,d"));

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload a file
            var upload = await _filesApi.UploadAsStreamAsync(fileName, "/",  (int) data.Length, data);

            //Download the file that was just uploaded
            var downloadedData = await _filesApi.DownloadAsStreamAsync(upload.Id);
            
            Assert.AreEqual(data, downloadedData);
        }

        [Test]
        public void Rename_File()
        {
            var rnd = new Random();
            var data = new byte[100];
            rnd.NextBytes(data);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload a file
            var upload = _filesApi.CreateFile(fileName, _testFolder, data.Length, data);

            //Create new unique file name
            var newFileName = Guid.NewGuid().ToString();

            //Create UpdateFile DTO
            var update = new UpdateFile(_testFolder, newFileName);

            //Rename file
            var renamedFile = _filesApi.UpdateFileMetadata(upload.Id, update);

            Assert.AreEqual(upload.Id, renamedFile.Id);
            Assert.AreEqual(newFileName, renamedFile.Name);
        }

        [Test]
        public void Update_File_Contents()
        {
            var rnd = new Random();
            var data = new byte[100];
            rnd.NextBytes(data);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Upload a file
            var upload = _filesApi.CreateFile(fileName, _testFolder, data.Length, data);

            //Create new file data
            var newData = new byte[200];
            rnd.NextBytes(data);

            //Update file contents
            var updatedFile = _filesApi.UpdateFileContents(upload.Id, newData.Length, newData);

            Assert.AreEqual(200,updatedFile.Size);

            //Create buffer for download
            var downloadedFile = new byte[200];

            //Download file
            _filesApi.DownloadFile(upload.Id).Read(downloadedFile);

            Assert.AreEqual(newData, downloadedFile);
        }

        [Test]
        public void Move_File()
        {
            var rnd = new Random();
            var data = new byte[100];
            rnd.NextBytes(data);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();

            //Upload a file
            var upload = _filesApi.CreateFile(fileName, _testFolder, data.Length, data);

            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);
            var folder = _foldersApi.CreateFolder(createFolder);

            //Create UpdateFile DTO
            var update = new UpdateFile(_testFolder + "/" + folder.Name, fileName);

            //Move a file
            var movedFile = _filesApi.UpdateFileMetadata(upload.Id, update);

            Assert.AreEqual(upload.Id, movedFile.Id);
            Assert.AreEqual(_testFolder + "/" + folder.Name, movedFile.Path);
        }

        [Test]
        public void Move_Files()
        {
            var rnd = new Random();
            var data1 = new byte[100];
            rnd.NextBytes(data1);

            //Create a unique file name
            var fileName1 = Guid.NewGuid().ToString();

            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();

            //Upload a file
            var upload = _filesApi.CreateFile(fileName1, _testFolder, data1.Length, data1);

            var data2 = new byte[100];
            rnd.NextBytes(data2);

            //Create a second unique file name
            var fileName2 = Guid.NewGuid().ToString();

            //Upload the second file
            var upload2 = _filesApi.CreateFile(fileName2, _testFolder, data2.Length, data2);

            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);
            var folder = _foldersApi.CreateFolder(createFolder);

            //Move files to folder
            var movedFile = _foldersApi.MoveFolder(folder.Id, new List<string>{upload.Id, upload2.Id});

            CollectionAssert.Contains(movedFile.Values.Select(x=>x.Name), upload.Name);
            CollectionAssert.Contains(movedFile.Values.Select(x=>x.Name), upload2.Name);
        }

        [Test]
        public void Move_File_With_Overwrite()
        {
            var rnd = new Random();
            var data1 = new byte[100];
            rnd.NextBytes(data1);

            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();

            //Upload a file
            var upload = _filesApi.CreateFile(fileName, _testFolder, data1.Length, data1);

            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);
            var folder = _foldersApi.CreateFolder(createFolder);

            var data2 = new byte[100];
            rnd.NextBytes(data2);

            //Upload the second file
            _filesApi.CreateFile(fileName, _testFolder + "/" + folder.Name, data2.Length, data2);

            //Move files to folder
            var movedFile = _foldersApi.MoveFolder(folder.Id, new List<string>{upload.Id}, true, true);

            var downloadedFile = new byte[100];
            _filesApi.DownloadFile(movedFile.Values.Single(x => x.Name == upload.Name).Id).Read(downloadedFile);
            CollectionAssert.Contains(movedFile.Values.Select(x=>x.Name), upload.Name);
            Assert.AreEqual(downloadedFile, data1);
            CollectionAssert.IsEmpty(_foldersApi.GetFolderContents(_testFolderId, filter: $"Name eq '{fileName}'").Values);
        }

        [Test]
        public void Copy_File()
        {
            var rnd = new Random();
            var data1 = new byte[100];
            rnd.NextBytes(data1);

            //Create a unique file name
            var fileName1 = Guid.NewGuid().ToString();

            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();

            //Upload a file
            var upload = _filesApi.CreateFile(fileName1, _testFolder, data1.Length, data1);

            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);

            var folder = _foldersApi.CreateFolder(createFolder);

            //Move files to folder
            var movedFile = _foldersApi.MoveFolder(folder.Id, new List<string>{upload.Id}, deleteSource: false);

            CollectionAssert.Contains(movedFile.Values.Select(x=>x.Name), upload.Name);
            Assert.AreEqual(upload.Name, _filesApi.GetFile(upload.Id).Name);
        }
    }
}
