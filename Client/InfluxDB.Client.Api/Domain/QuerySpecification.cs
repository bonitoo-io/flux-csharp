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
    /// consists of a set of operations and a set of edges between those operations to instruct the query engine to operate.
    /// </summary>
    [DataContract]
    public partial class QuerySpecification :  IEquatable<QuerySpecification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySpecification" /> class.
        /// </summary>
        /// <param name="spec">spec.</param>
        public QuerySpecification(QuerySpecificationSpec spec = default(QuerySpecificationSpec))
        {
            this.Spec = spec;
        }

        /// <summary>
        /// Gets or Sets Spec
        /// </summary>
        [DataMember(Name="spec", EmitDefaultValue=false)]
        public QuerySpecificationSpec Spec { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuerySpecification {\n");
            sb.Append("  Spec: ").Append(Spec).Append("\n");
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
            return this.Equals(input as QuerySpecification);
        }

        /// <summary>
        /// Returns true if QuerySpecification instances are equal
        /// </summary>
        /// <param name="input">Instance of QuerySpecification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuerySpecification input)
        {
            if (input == null)
                return false;

            return 
                (
                    
                    (this.Spec != null &&
                    this.Spec.Equals(input.Spec))
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
                if (this.Spec != null)
                    hashCode = hashCode * 59 + this.Spec.GetHashCode();
                return hashCode;
            }
        }

    }

}
