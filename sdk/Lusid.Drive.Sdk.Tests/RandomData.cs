using System;
using System.IO;

namespace Lusid.Drive.Sdk.Tests
{
    /// <summary>
    /// Helper factory methods to create streams containing random data
    /// </summary>
    public static class RandomData
    {
        public static Stream OfSize(int size)
        {
            var rnd = new Random();
            var data = new byte[size];
            rnd.NextBytes(data);
            return new MemoryStream(data);
        }
    }
}
