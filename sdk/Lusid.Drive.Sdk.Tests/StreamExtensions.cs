using System.IO;
using System.Threading.Tasks;

namespace Lusid.Drive.Sdk.Tests
{
    /// <summary>
    ///     Helper extensions methods to work with streams.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        ///     Read a stream as a byte array.
        ///     Needless to say, be careful when using this method as it will load the whole stream contents into memory.
        /// </summary>
        public static byte[] ReadAsBytes(this Stream stream)
        {
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
