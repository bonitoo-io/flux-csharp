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
    /// TelegrafPluginInputSyslog
    /// </summary>
    [DataContract]
    public partial class TelegrafPluginInputSyslog :  IEquatable<TelegrafPluginInputSyslog>
    {
        /// <summary>
        /// Defines Name
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum NameEnum
        {
            
            /// <summary>
            /// Enum Syslog for value: syslog
            /// </summary>
            [EnumMember(Value = "syslog")]
            Syslog = 1
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public NameEnum Name { get; set; }
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum Input for value: input
            /// </summary>
            [EnumMember(Value = "input")]
            Input = 1
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TelegrafPluginInputSyslog" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TelegrafPluginInputSyslog() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TelegrafPluginInputSyslog" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="type">type (required).</param>
        /// <param name="comment">comment.</param>
        /// <param name="config">config (required).</param>
        public TelegrafPluginInputSyslog(NameEnum name = default(NameEnum), TypeEnum type = default(TypeEnum), string comment = default(string), TelegrafPluginInputSyslogConfig config = default(TelegrafPluginInputSyslogConfig))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for TelegrafPluginInputSyslog and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for TelegrafPluginInputSyslog and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            // to ensure "config" is required (not null)
            if (config == null)
            {
                throw new InvalidDataException("config is a required property for TelegrafPluginInputSyslog and cannot be null");
            }
            else
            {
                this.Config = config;
            }
            this.Comment = comment;
        }



        /// <summary>
        /// Gets or Sets Comment
        /// </summary>
        [DataMember(Name="comment", EmitDefaultValue=false)]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or Sets Config
        /// </summary>
        [DataMember(Name="config", EmitDefaultValue=false)]
        public TelegrafPluginInputSyslogConfig Config { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TelegrafPluginInputSyslog {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Comment: ").Append(Comment).Append("\n");
            sb.Append("  Config: ").Append(Config).Append("\n");
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
            return this.Equals(input as TelegrafPluginInputSyslog);
        }

        /// <summary>
        /// Returns true if TelegrafPluginInputSyslog instances are equal
        /// </summary>
        /// <param name="input">Instance of TelegrafPluginInputSyslog to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TelegrafPluginInputSyslog input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Comment == input.Comment ||
                    (this.Comment != null &&
                    this.Comment.Equals(input.Comment))
                ) && 
                (
                    
                    (this.Config != null &&
                    this.Config.Equals(input.Config))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Comment != null)
                    hashCode = hashCode * 59 + this.Comment.GetHashCode();
                if (this.Config != null)
                    hashCode = hashCode * 59 + this.Config.GetHashCode();
                return hashCode;
            }
        }

    }

}
