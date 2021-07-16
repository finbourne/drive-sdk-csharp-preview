using System;
using System.Collections.Immutable;
using System.Linq;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Client;
using Lusid.Drive.Sdk.Model;
using Lusid.Drive.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Drive.Sdk.Tests
{
    public class FoldersApiTests
    {
        private ILusidApiFactory _factory;
        private IFoldersApi _foldersApi;
        private string _testFolderId;

        [OneTimeSetUp]
        public void SetUp()
        {
            _factory = EnvironmentCheck.FactoryForEnvironment();
            _foldersApi = _factory.Api<IFoldersApi>();

            _testFolderId = _foldersApi.GetRootFolder(filter: "Name eq 'SDK_Test_Folder'").Values.SingleOrDefault()?.Id;
            var createFolder = new CreateFolder("/", "SDK_Test_Folder");
            _testFolderId ??= _foldersApi.CreateFolder(createFolder).Id;
        }

        [Test]
        public void List_Root_Folder_Contents()
        {
            var folderName = Guid.NewGuid().ToString();
            var createFolder = new CreateFolder("/SDK_Test_Folder", folderName);
            var create = _foldersApi.CreateFolder(createFolder);
            var innerFolderName = Guid.NewGuid().ToString();
            var innerCreateFolder = new CreateFolder("/SDK_Test_Folder/" + folderName, innerFolderName);
            var innerCreate = _foldersApi.CreateFolder(innerCreateFolder);
            
            var folderContents = _foldersApi.GetFolderContents(create.Id);
            Assert.True( _foldersApi.GetFolderContents(_testFolderId).Values.ToImmutableDictionary(x => x.Name, y => y).ContainsKey(folderName));
            Assert.That(folderContents.Values.Count, Is.EqualTo(1));
            
            _foldersApi.DeleteFolder(create.Id);
            Assert.False( _foldersApi.GetFolderContents(_testFolderId).Values.ToImmutableDictionary(x => x.Name, y => y).ContainsKey(folderName));
            Assert.Throws<ApiException>(() => _foldersApi.GetFolder(innerCreate.Id));
        }

        [Test]
        public void Create_Delete_Folder()
        {
            var folderName = Guid.NewGuid().ToString();
            var createFolder = new CreateFolder("/", folderName);
            var create = _foldersApi.CreateFolder(createFolder);
            
            var root = _foldersApi.GetRootFolder();
            Assert.That(root.Values.ToImmutableDictionary(x => x.Name, y => y.Id)[folderName], Is.EqualTo(create.Id));
            
            _foldersApi.DeleteFolder(create.Id);
            Assert.False( _foldersApi.GetRootFolder().Values.ToImmutableDictionary(x => x.Name, y => y).ContainsKey(folderName));
        }
        
    }
}