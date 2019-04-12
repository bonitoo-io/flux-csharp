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
    /// Legend define encoding of data into a view&#39;s legend
    /// </summary>
    [DataContract]
    public partial class V1ViewPropertiesLegend :  IEquatable<V1ViewPropertiesLegend>
    {
        /// <summary>
        /// type is the style of the legend
        /// </summary>
        /// <value>type is the style of the legend</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum Static for value: static
            /// </summary>
            [EnumMember(Value = "static")]
            Static = 1
        }

        /// <summary>
        /// type is the style of the legend
        /// </summary>
        /// <value>type is the style of the legend</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// orientation is the location of the legend with respect to the view graph
        /// </summary>
        /// <value>orientation is the location of the legend with respect to the view graph</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrientationEnum
        {
            
            /// <summary>
            /// Enum Top for value: top
            /// </summary>
            [EnumMember(Value = "top")]
            Top = 1,
            
            /// <summary>
            /// Enum Bottom for value: bottom
            /// </summary>
            [EnumMember(Value = "bottom")]
            Bottom = 2,
            
            /// <summary>
            /// Enum Left for value: left
            /// </summary>
            [EnumMember(Value = "left")]
            Left = 3,
            
            /// <summary>
            /// Enum Right for value: right
            /// </summary>
            [EnumMember(Value = "right")]
            Right = 4
        }

        /// <summary>
        /// orientation is the location of the legend with respect to the view graph
        /// </summary>
        /// <value>orientation is the location of the legend with respect to the view graph</value>
        [DataMember(Name="orientation", EmitDefaultValue=false)]
        public OrientationEnum? Orientation { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="V1ViewPropertiesLegend" /> class.
        /// </summary>
        /// <param name="type">type is the style of the legend.</param>
        /// <param name="orientation">orientation is the location of the legend with respect to the view graph.</param>
        public V1ViewPropertiesLegend(TypeEnum? type = default(TypeEnum?), OrientationEnum? orientation = default(OrientationEnum?))
        {
            this.Type = type;
            this.Orientation = orientation;
        }



        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class V1ViewPropertiesLegend {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Orientation: ").Append(Orientation).Append("\n");
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
            return this.Equals(input as V1ViewPropertiesLegend);
        }

        /// <summary>
        /// Returns true if V1ViewPropertiesLegend instances are equal
        /// </summary>
        /// <param name="input">Instance of V1ViewPropertiesLegend to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(V1ViewPropertiesLegend input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Orientation == input.Orientation ||
                    (this.Orientation != null &&
                    this.Orientation.Equals(input.Orientation))
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Orientation != null)
                    hashCode = hashCode * 59 + this.Orientation.GetHashCode();
                return hashCode;
            }
        }

    }

}
