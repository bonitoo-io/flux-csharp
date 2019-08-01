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
using OpenAPIDateConverter = InfluxDB.Client.Api.Client.OpenAPIDateConverter;

namespace InfluxDB.Client.Api.Domain
{
    /// <summary>
    /// PagerDutyNotificationRule
    /// </summary>
    [DataContract]
    public partial class PagerDutyNotificationRule : NotificationRule,  IEquatable<PagerDutyNotificationRule>
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Pagerduty for value: pagerduty
            /// </summary>
            [EnumMember(Value = "pagerduty")]
            Pagerduty = 1

        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PagerDutyNotificationRule" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PagerDutyNotificationRule() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PagerDutyNotificationRule" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="messageTemplate">messageTemplate (required).</param>
        public PagerDutyNotificationRule(TypeEnum type = default(TypeEnum), string messageTemplate = default(string), string orgID = default(string), TaskStatusType status = default(TaskStatusType), string name = default(string), string sleepUntil = default(string), string every = default(string), string offset = default(string), string cron = default(string), string runbookLink = default(string), int? limitEvery = default(int?), int? limit = default(int?), List<TagRule> tagRules = default(List<TagRule>), string description = default(string), List<StatusRule> statusRules = default(List<StatusRule>), List<Label> labels = default(List<Label>)) : base(orgID, status, name, sleepUntil, every, offset, cron, runbookLink, limitEvery, limit, tagRules, description, statusRules, labels)
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for PagerDutyNotificationRule and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            // to ensure "messageTemplate" is required (not null)
            if (messageTemplate == null)
            {
                throw new InvalidDataException("messageTemplate is a required property for PagerDutyNotificationRule and cannot be null");
            }
            else
            {
                this.MessageTemplate = messageTemplate;
            }
        }


        /// <summary>
        /// Gets or Sets MessageTemplate
        /// </summary>
        [DataMember(Name="messageTemplate", EmitDefaultValue=false)]
        public string MessageTemplate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PagerDutyNotificationRule {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  MessageTemplate: ").Append(MessageTemplate).Append("\n");
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
            return this.Equals(input as PagerDutyNotificationRule);
        }

        /// <summary>
        /// Returns true if PagerDutyNotificationRule instances are equal
        /// </summary>
        /// <param name="input">Instance of PagerDutyNotificationRule to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PagerDutyNotificationRule input)
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
                    this.MessageTemplate == input.MessageTemplate ||
                    (this.MessageTemplate != null &&
                    this.MessageTemplate.Equals(input.MessageTemplate))
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
                if (this.MessageTemplate != null)
                    hashCode = hashCode * 59 + this.MessageTemplate.GetHashCode();
                return hashCode;
            }
        }

    }

}
