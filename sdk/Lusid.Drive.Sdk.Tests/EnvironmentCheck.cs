using Lusid.Drive.Sdk.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lusid.Drive.Sdk.Tests
{
    public static class EnvironmentCheck
    {
        public static ILusidApiFactory FactoryForEnvironment()
        {
            return 
                string.IsNullOrEmpty(Environment.GetEnvironmentVariable("FBN_ACCESS_TOKEN")) ?
                    LusidApiFactoryBuilder.Build("secrets.json") :
                    LusidApiFactoryBuilder.Build();
        }
    }
}
