/* 
 * Influx OSS API Service
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * OpenAPI spec version: 2.0.0
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenAPIDateConverter = InfluxDB.Client.Api.Client.OpenAPIDateConverter;

namespace InfluxDB.Client.Api.Domain
{
    /// <summary>
    /// ScraperTargetResponse
    /// </summary>
    [DataContract]
    public partial class ScraperTargetResponse : ScraperTargetRequest,  IEquatable<ScraperTargetResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScraperTargetResponse" /> class.
        /// </summary>
        /// <param name="org">The name of the organization..</param>
        /// <param name="bucket">The bucket name..</param>
        /// <param name="links">links.</param>
        public ScraperTargetResponse(string org = default(string), string bucket = default(string), ScraperTargetResponseLinks links = default(ScraperTargetResponseLinks), string name = default(string), TypeEnum? type = default(TypeEnum?), string url = default(string), string orgID = default(string), string bucketID = default(string), bool? allowInsecure = false) : base(name, type, url, orgID, bucketID, allowInsecure)
        {
            this.Org = org;
            this.Bucket = bucket;
            this.Links = links;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; private set; }

        /// <summary>
        /// The name of the organization.
        /// </summary>
        /// <value>The name of the organization.</value>
        [DataMember(Name="org", EmitDefaultValue=false)]
        public string Org { get; set; }

        /// <summary>
        /// The bucket name.
        /// </summary>
        /// <value>The bucket name.</value>
        [DataMember(Name="bucket", EmitDefaultValue=false)]
        public string Bucket { get; set; }

        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue=false)]
        public ScraperTargetResponseLinks Links { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ScraperTargetResponse {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Org: ").Append(Org).Append("\n");
            sb.Append("  Bucket: ").Append(Bucket).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ScraperTargetResponse);
        }

        /// <summary>
        /// Returns true if ScraperTargetResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of ScraperTargetResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScraperTargetResponse input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && base.Equals(input) && 
                (
                    this.Org == input.Org ||
                    (this.Org != null &&
                    this.Org.Equals(input.Org))
                ) && base.Equals(input) && 
                (
                    this.Bucket == input.Bucket ||
                    (this.Bucket != null &&
                    this.Bucket.Equals(input.Bucket))
                ) && base.Equals(input) && 
                (
                    
                    (this.Links != null &&
                    this.Links.Equals(input.Links))
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
                int hashCode = base.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Org != null)
                    hashCode = hashCode * 59 + this.Org.GetHashCode();
                if (this.Bucket != null)
                    hashCode = hashCode * 59 + this.Bucket.GetHashCode();
                if (this.Links != null)
                    hashCode = hashCode * 59 + this.Links.GetHashCode();
                return hashCode;
            }
        }

    }

}
