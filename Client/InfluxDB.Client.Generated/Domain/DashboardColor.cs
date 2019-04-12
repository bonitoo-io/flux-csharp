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
    /// Color defines an encoding of data value into color space
    /// </summary>
    [DataContract]
    public partial class DashboardColor :  IEquatable<DashboardColor>
    {
        /// <summary>
        /// Type is how the color is used.
        /// </summary>
        /// <value>Type is how the color is used.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum Min for value: min
            /// </summary>
            [EnumMember(Value = "min")]
            Min = 1,
            
            /// <summary>
            /// Enum Max for value: max
            /// </summary>
            [EnumMember(Value = "max")]
            Max = 2,
            
            /// <summary>
            /// Enum Threshold for value: threshold
            /// </summary>
            [EnumMember(Value = "threshold")]
            Threshold = 3
        }

        /// <summary>
        /// Type is how the color is used.
        /// </summary>
        /// <value>Type is how the color is used.</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardColor" /> class.
        /// </summary>
        /// <param name="id">ID is the unique id of the view color.</param>
        /// <param name="type">Type is how the color is used..</param>
        /// <param name="hex">Hex is the hex number of the color.</param>
        /// <param name="name">Name is the user-facing name of the hex color.</param>
        /// <param name="value">Value is the data value mapped to this color.</param>
        public DashboardColor(string id = default(string), TypeEnum? type = default(TypeEnum?), string hex = default(string), string name = default(string), string value = default(string))
        {
            this.Id = id;
            this.Type = type;
            this.Hex = hex;
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// ID is the unique id of the view color
        /// </summary>
        /// <value>ID is the unique id of the view color</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }


        /// <summary>
        /// Hex is the hex number of the color
        /// </summary>
        /// <value>Hex is the hex number of the color</value>
        [DataMember(Name="hex", EmitDefaultValue=false)]
        public string Hex { get; set; }

        /// <summary>
        /// Name is the user-facing name of the hex color
        /// </summary>
        /// <value>Name is the user-facing name of the hex color</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Value is the data value mapped to this color
        /// </summary>
        /// <value>Value is the data value mapped to this color</value>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DashboardColor {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Hex: ").Append(Hex).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(input as DashboardColor);
        }

        /// <summary>
        /// Returns true if DashboardColor instances are equal
        /// </summary>
        /// <param name="input">Instance of DashboardColor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DashboardColor input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Hex == input.Hex ||
                    (this.Hex != null &&
                    this.Hex.Equals(input.Hex))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Hex != null)
                    hashCode = hashCode * 59 + this.Hex.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                return hashCode;
            }
        }

    }

}
