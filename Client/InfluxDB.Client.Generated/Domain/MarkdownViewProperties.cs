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
    /// MarkdownViewProperties
    /// </summary>
    [DataContract]
    public partial class MarkdownViewProperties :  IEquatable<MarkdownViewProperties>
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum Markdown for value: markdown
            /// </summary>
            [EnumMember(Value = "markdown")]
            Markdown = 1
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Defines Shape
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ShapeEnum
        {
            
            /// <summary>
            /// Enum ChronografV2 for value: chronograf-v2
            /// </summary>
            [EnumMember(Value = "chronograf-v2")]
            ChronografV2 = 1
        }

        /// <summary>
        /// Gets or Sets Shape
        /// </summary>
        [DataMember(Name="shape", EmitDefaultValue=false)]
        public ShapeEnum Shape { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownViewProperties" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MarkdownViewProperties() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownViewProperties" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="shape">shape (required).</param>
        /// <param name="note">note (required).</param>
        public MarkdownViewProperties(TypeEnum type = default(TypeEnum), ShapeEnum shape = default(ShapeEnum), string note = default(string))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for MarkdownViewProperties and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            // to ensure "shape" is required (not null)
            if (shape == null)
            {
                throw new InvalidDataException("shape is a required property for MarkdownViewProperties and cannot be null");
            }
            else
            {
                this.Shape = shape;
            }
            // to ensure "note" is required (not null)
            if (note == null)
            {
                throw new InvalidDataException("note is a required property for MarkdownViewProperties and cannot be null");
            }
            else
            {
                this.Note = note;
            }
        }



        /// <summary>
        /// Gets or Sets Note
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue=false)]
        public string Note { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MarkdownViewProperties {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Shape: ").Append(Shape).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
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
            return this.Equals(input as MarkdownViewProperties);
        }

        /// <summary>
        /// Returns true if MarkdownViewProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of MarkdownViewProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MarkdownViewProperties input)
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
                    this.Shape == input.Shape ||
                    (this.Shape != null &&
                    this.Shape.Equals(input.Shape))
                ) && 
                (
                    this.Note == input.Note ||
                    (this.Note != null &&
                    this.Note.Equals(input.Note))
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
                if (this.Shape != null)
                    hashCode = hashCode * 59 + this.Shape.GetHashCode();
                if (this.Note != null)
                    hashCode = hashCode * 59 + this.Note.GetHashCode();
                return hashCode;
            }
        }

    }

}
