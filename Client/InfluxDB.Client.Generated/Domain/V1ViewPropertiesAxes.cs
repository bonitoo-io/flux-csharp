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
    /// The viewport for a View&#39;s visualizations
    /// </summary>
    [DataContract]
    public partial class V1ViewPropertiesAxes :  IEquatable<V1ViewPropertiesAxes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1ViewPropertiesAxes" /> class.
        /// </summary>
        /// <param name="x">x.</param>
        /// <param name="y">y.</param>
        /// <param name="y2">y2.</param>
        public V1ViewPropertiesAxes(Axis x = default(Axis), Axis y = default(Axis), Axis y2 = default(Axis))
        {
            this.X = x;
            this.Y = y;
            this.Y2 = y2;
        }

        /// <summary>
        /// Gets or Sets X
        /// </summary>
        [DataMember(Name="x", EmitDefaultValue=false)]
        public Axis X { get; set; }

        /// <summary>
        /// Gets or Sets Y
        /// </summary>
        [DataMember(Name="y", EmitDefaultValue=false)]
        public Axis Y { get; set; }

        /// <summary>
        /// Gets or Sets Y2
        /// </summary>
        [DataMember(Name="y2", EmitDefaultValue=false)]
        public Axis Y2 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class V1ViewPropertiesAxes {\n");
            sb.Append("  X: ").Append(X).Append("\n");
            sb.Append("  Y: ").Append(Y).Append("\n");
            sb.Append("  Y2: ").Append(Y2).Append("\n");
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
            return this.Equals(input as V1ViewPropertiesAxes);
        }

        /// <summary>
        /// Returns true if V1ViewPropertiesAxes instances are equal
        /// </summary>
        /// <param name="input">Instance of V1ViewPropertiesAxes to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(V1ViewPropertiesAxes input)
        {
            if (input == null)
                return false;

            return 
                (
                    
                    (this.X != null &&
                    this.X.Equals(input.X))
                ) && 
                (
                    
                    (this.Y != null &&
                    this.Y.Equals(input.Y))
                ) && 
                (
                    
                    (this.Y2 != null &&
                    this.Y2.Equals(input.Y2))
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
                if (this.X != null)
                    hashCode = hashCode * 59 + this.X.GetHashCode();
                if (this.Y != null)
                    hashCode = hashCode * 59 + this.Y.GetHashCode();
                if (this.Y2 != null)
                    hashCode = hashCode * 59 + this.Y2.GetHashCode();
                return hashCode;
            }
        }

    }

}
