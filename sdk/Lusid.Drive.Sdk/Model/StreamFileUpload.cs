using System.IO;

namespace Lusid.Drive.Sdk.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class StreamFileUpload
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="body"></param>
        /// <param name="length"></param>
        /// <param name="path"></param>
        public StreamFileUpload(string name, Stream body, int length, string path)
        {
            Name = name;
            Length = length;
            Path = path;
            Body = body;
        }

        /// <summary>
        /// 
        /// </summary>
        public Stream Body { get; protected set; } 
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        public int Length { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        public string Path { get; protected set; }
    }
}