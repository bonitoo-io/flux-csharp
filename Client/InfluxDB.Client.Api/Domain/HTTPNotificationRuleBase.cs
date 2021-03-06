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
    /// HTTPNotificationRuleBase
    /// </summary>
    [DataContract]
    public partial class HTTPNotificationRuleBase : NotificationRule,  IEquatable<HTTPNotificationRuleBase>
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Http for value: http
            /// </summary>
            [EnumMember(Value = "http")]
            Http = 1

        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="HTTPNotificationRuleBase" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected HTTPNotificationRuleBase() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="HTTPNotificationRuleBase" /> class.
        /// </summary>
        /// <param name="type">type (required) (default to TypeEnum.Http).</param>
        /// <param name="url">url.</param>
        public HTTPNotificationRuleBase(TypeEnum type = TypeEnum.Http, string url = default(string), string endpointID = default(string), string orgID = default(string), string taskID = default(string), TaskStatusType status = default(TaskStatusType), string name = default(string), string sleepUntil = default(string), string every = default(string), string offset = default(string), string runbookLink = default(string), int? limitEvery = default(int?), int? limit = default(int?), List<TagRule> tagRules = default(List<TagRule>), string description = default(string), List<StatusRule> statusRules = default(List<StatusRule>), List<Label> labels = default(List<Label>), NotificationRuleBaseLinks links = default(NotificationRuleBaseLinks)) : base(endpointID, orgID, taskID, status, name, sleepUntil, every, offset, runbookLink, limitEvery, limit, tagRules, description, statusRules, labels, links)
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for HTTPNotificationRuleBase and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            this.Url = url;
        }


        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HTTPNotificationRuleBase {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
            return this.Equals(input as HTTPNotificationRuleBase);
        }

        /// <summary>
        /// Returns true if HTTPNotificationRuleBase instances are equal
        /// </summary>
        /// <param name="input">Instance of HTTPNotificationRuleBase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HTTPNotificationRuleBase input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                return hashCode;
            }
        }

    }

}
