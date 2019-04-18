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
using OpenAPIDateConverter = InfluxDB.Client.Api.Client.OpenAPIDateConverter;

namespace InfluxDB.Client.Api.Domain
{
    /// <summary>
    /// QueryConfigRange
    /// </summary>
    [DataContract]
    public partial class QueryConfigRange :  IEquatable<QueryConfigRange>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryConfigRange" /> class.
        /// </summary>
        /// <param name="lower">lower.</param>
        /// <param name="upper">upper.</param>
        public QueryConfigRange(string lower = default(string), string upper = default(string))
        {
            this.Lower = lower;
            this.Upper = upper;
        }

        /// <summary>
        /// Gets or Sets Lower
        /// </summary>
        [DataMember(Name="lower", EmitDefaultValue=false)]
        public string Lower { get; set; }

        /// <summary>
        /// Gets or Sets Upper
        /// </summary>
        [DataMember(Name="upper", EmitDefaultValue=false)]
        public string Upper { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QueryConfigRange {\n");
            sb.Append("  Lower: ").Append(Lower).Append("\n");
            sb.Append("  Upper: ").Append(Upper).Append("\n");
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
            return this.Equals(input as QueryConfigRange);
        }

        /// <summary>
        /// Returns true if QueryConfigRange instances are equal
        /// </summary>
        /// <param name="input">Instance of QueryConfigRange to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QueryConfigRange input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Lower == input.Lower ||
                    (this.Lower != null &&
                    this.Lower.Equals(input.Lower))
                ) && 
                (
                    this.Upper == input.Upper ||
                    (this.Upper != null &&
                    this.Upper.Equals(input.Upper))
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
                if (this.Lower != null)
                    hashCode = hashCode * 59 + this.Lower.GetHashCode();
                if (this.Upper != null)
                    hashCode = hashCode * 59 + this.Upper.GetHashCode();
                return hashCode;
            }
        }

    }

}
