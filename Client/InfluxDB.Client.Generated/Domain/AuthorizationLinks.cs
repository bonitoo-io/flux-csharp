/* 
 * Influx API Service
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * OpenAPI spec version: 0.1.0
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
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = InfluxDB.Client.Generated.Client.OpenAPIDateConverter;

namespace InfluxDB.Client.Generated.Domain
{
    /// <summary>
    /// AuthorizationLinks
    /// </summary>
    [DataContract]
    public partial class AuthorizationLinks :  IEquatable<AuthorizationLinks>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationLinks" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public AuthorizationLinks()
        {
        }

        /// <summary>
        /// Gets or Sets Self
        /// </summary>
        [DataMember(Name="self", EmitDefaultValue=false)]
        public string Self { get; private set; }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [DataMember(Name="user", EmitDefaultValue=false)]
        public string User { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AuthorizationLinks {\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
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
            return this.Equals(input as AuthorizationLinks);
        }

        /// <summary>
        /// Returns true if AuthorizationLinks instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthorizationLinks to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthorizationLinks input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Self == input.Self ||
                    (this.Self != null &&
                    this.Self.Equals(input.Self))
                ) && 
                (
                    this.User == input.User ||
                    (this.User != null &&
                    this.User.Equals(input.User))
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
                if (this.Self != null)
                    hashCode = hashCode * 59 + this.Self.GetHashCode();
                if (this.User != null)
                    hashCode = hashCode * 59 + this.User.GetHashCode();
                return hashCode;
            }
        }

    }

}
