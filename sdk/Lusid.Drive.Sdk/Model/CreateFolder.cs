/*
 * FINBOURNE Drive API
 *
 * Drive is a secure file repository and manager that can act as a staging area for LUSID. You can upload files to Drive in preparation for loading investment data into LUSID, or export data from LUSID to Drive for consumption by external systems. Or simply share files with other LUSID users.  ### Error Codes  | Code|Name|Description | | - --|- --|- -- | | <a name=\"-1\">-1</a>|Unknown error|An unexpected error was encountered on our side. | | <a name=\"144\">144</a>|Duplicate In Parameter Set|  | | <a name=\"151\">151</a>|Invalid Parameter Value|  | | <a name=\"165\">165</a>|Failed To Delete|  | | <a name=\"664\">664</a>|Folder already exists|  | | <a name=\"665\">665</a>|Destination directory not found|  | | <a name=\"666\">666</a>|Unknown Identifier|  | | <a name=\"668\">668</a>|Root directory not present|  | | <a name=\"669\">669</a>|Failed to create root directory|  | | <a name=\"670\">670</a>|File size exceeds maximum limit|  | | <a name=\"671\">671</a>|File already exists|  | | <a name=\"672\">672</a>|Could not retrieve file contents|  | | <a name=\"683\">683</a>|Full path to resource is too long|  | | <a name=\"689\">689</a>|The supplied pagination token is invalid|  | | <a name=\"692\">692</a>|This endpoint does not support impersonation|  | | <a name=\"696\">696</a>|Unexpected payload size|  | | <a name=\"715\">715</a>|Restricted from downloading file containing malware.|  | | <a name=\"716\">716</a>|Restricted from downloading file whilst virus scan in progress.|  | | <a name=\"871\">871</a>|The specified impersonated user does not exist|  | 
 *
 * The version of the OpenAPI document: 0.1.672
 * Contact: info@finbourne.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Lusid.Drive.Sdk.Client.OpenAPIDateConverter;

namespace Lusid.Drive.Sdk.Model
{
    /// <summary>
    /// DTO representing the creation of a folder
    /// </summary>
    [DataContract(Name = "CreateFolder")]
    public partial class CreateFolder : IEquatable<CreateFolder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFolder" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateFolder() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFolder" /> class.
        /// </summary>
        /// <param name="path">Path of the created folder (required).</param>
        /// <param name="name">Name of the created folder (required).</param>
        public CreateFolder(string path = default(string), string name = default(string))
        {
            // to ensure "path" is required (not null)
            this.Path = path ?? throw new ArgumentNullException("path is a required property for CreateFolder and cannot be null");
            // to ensure "name" is required (not null)
            this.Name = name ?? throw new ArgumentNullException("name is a required property for CreateFolder and cannot be null");
        }

        /// <summary>
        /// Path of the created folder
        /// </summary>
        /// <value>Path of the created folder</value>
        [DataMember(Name = "path", IsRequired = true, EmitDefaultValue = false)]
        public string Path { get; set; }

        /// <summary>
        /// Name of the created folder
        /// </summary>
        /// <value>Name of the created folder</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateFolder {\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as CreateFolder);
        }

        /// <summary>
        /// Returns true if CreateFolder instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateFolder to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateFolder input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Path == input.Path ||
                    (this.Path != null &&
                    this.Path.Equals(input.Path))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Path != null)
                    hashCode = hashCode * 59 + this.Path.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                return hashCode;
            }
        }

    }
}
