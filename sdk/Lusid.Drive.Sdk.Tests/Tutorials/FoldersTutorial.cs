using System;
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
        public void List_Root_Folder_Contents()
        {
            var pageSize = 5;
            
            //List root folder contents
            var contents = _foldersApi.GetRootFolder(limit: pageSize);
            
            Assert.That(contents.Values.Count, Is.LessThanOrEqualTo(pageSize));
        }
        
        [Test]
        public void List_Folder_Contents()
        {
            var rnd = new Random();
            var data = new byte[100];
            rnd.NextBytes(data);
            
            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();
            
            //Upload a file
            var upload = _filesApi.CreateFile(fileName, _testFolder, data.Length, data);
            
            //List folder contents
            var contents = _foldersApi.GetFolderContents(_testFolderId);
            
            CollectionAssert.Contains(contents.Values.Select(x=> x.Name), upload.Name);
        }
        
        [Test]
        public void Rename_Folder()
        {
            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();
            
            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);
            var folder = _foldersApi.CreateFolder(createFolder);
            
            //Create another unique folder name
            var newFolderName = Guid.NewGuid().ToString();
            
            //Create UpdateFolder DTO
            var update = new UpdateFolder(_testFolder, newFolderName);
            
            //Rename folder
            var renameFolder = _foldersApi.UpdateFolder(folder.Id, update);
            
            Assert.AreEqual(folder.Id, renameFolder.Id);
            Assert.AreEqual(newFolderName, renameFolder.Name);
        }
        
        [Test]
        public void Move_Folder()
        {
            //Create a unique folder name
            var folderName1 = Guid.NewGuid().ToString();
            
            var rnd = new Random();
            var data = new byte[100];
            rnd.NextBytes(data);
            
            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();

            //Create a folder
            var createFolder1 = new CreateFolder(_testFolder, folderName1);
            var folder1 = _foldersApi.CreateFolder(createFolder1);
            
            //Upload a file
            var file = _filesApi.CreateFile(fileName, _testFolder + "/" + folderName1, data.Length, data);
            
            //Create another unique folder name
            var folderName2 = Guid.NewGuid().ToString();
            
            //Create another folder
            var createFolder2 = new CreateFolder(_testFolder, folderName2);
            _foldersApi.CreateFolder(createFolder2);
            
            //Move folder and file
            var folderUpdate = new UpdateFolder(_testFolder + "/" + folderName2, folderName1);
            var updatedFolder =_foldersApi.UpdateFolder(folder1.Id, folderUpdate);
            
            Assert.AreEqual(updatedFolder.Path + "/" + updatedFolder.Name, _filesApi.GetFile(file.Id).Path);
            Assert.AreNotEqual(file.Path, _filesApi.GetFile(file.Id).Path);
        }
        
        [Test]
        public void Delete_Folder()
        {
            var rnd = new Random();
            var data = new byte[100];
            rnd.NextBytes(data);
            
            //Create a unique file name
            var fileName = Guid.NewGuid().ToString();
            
            //Create a unique folder name
            var folderName = Guid.NewGuid().ToString();
            
            //Create a folder
            var createFolder = new CreateFolder(_testFolder, folderName);
            var folder = _foldersApi.CreateFolder(createFolder);
            
            //Upload a file
            var upload = _filesApi.CreateFile(fileName, _testFolder + "/" + folderName, data.Length, data);
            
            //Delete folder and file
            _foldersApi.DeleteFolder(folder.Id);
            
            Assert.Throws<ApiException>(()=> _filesApi.GetFile(upload.Id));
            Assert.Throws<ApiException>(()=> _foldersApi.GetFolder(folder.Id));
        }
    }
}