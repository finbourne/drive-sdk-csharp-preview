using NUnit.Framework;
using System.Collections.Immutable;
using System.Linq;
using Lusid.Drive.Sdk.Api;
using Lusid.Drive.Sdk.Model;
using Lusid.Drive.Sdk.Utilities;

namespace Lusid.Drive.Sdk.Tests
{
    [TestFixture]
    public class ApplicationMetadataTests
    {
        private ILusidApiFactory _factory;

        [OneTimeSetUp]
        public void SetUp()
        {
            _factory = EnvironmentCheck.FactoryForEnvironment();
        }

        [Test]
        public void ListAccessControlledResources()
        {
            var applicationMetadataApi = _factory.Api<IApplicationMetadataApi>();
            ResourceListOfAccessControlledResource resources = applicationMetadataApi.ListAccessControlledResources();

            Assert.That(resources.Values.Count == 3, "Expected Files, Folders and Features from the ActionKeys");
        }
    }
}