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
    /// RunLinks
    /// </summary>
    [DataContract]
    public partial class RunLinks :  IEquatable<RunLinks>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RunLinks" /> class.
        /// </summary>
        /// <param name="self">self.</param>
        /// <param name="task">task.</param>
        /// <param name="logs">logs.</param>
        /// <param name="retry">retry.</param>
        public RunLinks(string self = default(string), string task = default(string), string logs = default(string), string retry = default(string))
        {
            this.Self = self;
            this.Task = task;
            this.Logs = logs;
            this.Retry = retry;
        }

        /// <summary>
        /// Gets or Sets Self
        /// </summary>
        [DataMember(Name="self", EmitDefaultValue=false)]
        public string Self { get; set; }

        /// <summary>
        /// Gets or Sets Task
        /// </summary>
        [DataMember(Name="task", EmitDefaultValue=false)]
        public string Task { get; set; }

        /// <summary>
        /// Gets or Sets Logs
        /// </summary>
        [DataMember(Name="logs", EmitDefaultValue=false)]
        public string Logs { get; set; }

        /// <summary>
        /// Gets or Sets Retry
        /// </summary>
        [DataMember(Name="retry", EmitDefaultValue=false)]
        public string Retry { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RunLinks {\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  Task: ").Append(Task).Append("\n");
            sb.Append("  Logs: ").Append(Logs).Append("\n");
            sb.Append("  Retry: ").Append(Retry).Append("\n");
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
            return this.Equals(input as RunLinks);
        }

        /// <summary>
        /// Returns true if RunLinks instances are equal
        /// </summary>
        /// <param name="input">Instance of RunLinks to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RunLinks input)
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
                    this.Task == input.Task ||
                    (this.Task != null &&
                    this.Task.Equals(input.Task))
                ) && 
                (
                    this.Logs == input.Logs ||
                    (this.Logs != null &&
                    this.Logs.Equals(input.Logs))
                ) && 
                (
                    this.Retry == input.Retry ||
                    (this.Retry != null &&
                    this.Retry.Equals(input.Retry))
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
                if (this.Task != null)
                    hashCode = hashCode * 59 + this.Task.GetHashCode();
                if (this.Logs != null)
                    hashCode = hashCode * 59 + this.Logs.GetHashCode();
                if (this.Retry != null)
                    hashCode = hashCode * 59 + this.Retry.GetHashCode();
                return hashCode;
            }
        }

    }

}
