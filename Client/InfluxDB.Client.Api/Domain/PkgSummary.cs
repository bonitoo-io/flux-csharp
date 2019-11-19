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
    /// PkgSummary
    /// </summary>
    [DataContract]
    public partial class PkgSummary :  IEquatable<PkgSummary>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PkgSummary" /> class.
        /// </summary>
        /// <param name="summary">summary.</param>
        /// <param name="diff">diff.</param>
        /// <param name="errors">errors.</param>
        public PkgSummary(PkgSummarySummary summary = default(PkgSummarySummary), PkgSummaryDiff diff = default(PkgSummaryDiff), List<PkgSummaryErrors> errors = default(List<PkgSummaryErrors>))
        {
            this.Summary = summary;
            this.Diff = diff;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets or Sets Summary
        /// </summary>
        [DataMember(Name="summary", EmitDefaultValue=false)]
        public PkgSummarySummary Summary { get; set; }

        /// <summary>
        /// Gets or Sets Diff
        /// </summary>
        [DataMember(Name="diff", EmitDefaultValue=false)]
        public PkgSummaryDiff Diff { get; set; }

        /// <summary>
        /// Gets or Sets Errors
        /// </summary>
        [DataMember(Name="errors", EmitDefaultValue=false)]
        public List<PkgSummaryErrors> Errors { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PkgSummary {\n");
            sb.Append("  Summary: ").Append(Summary).Append("\n");
            sb.Append("  Diff: ").Append(Diff).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
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
            return this.Equals(input as PkgSummary);
        }

        /// <summary>
        /// Returns true if PkgSummary instances are equal
        /// </summary>
        /// <param name="input">Instance of PkgSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PkgSummary input)
        {
            if (input == null)
                return false;

            return 
                (
                    
                    (this.Summary != null &&
                    this.Summary.Equals(input.Summary))
                ) && 
                (
                    
                    (this.Diff != null &&
                    this.Diff.Equals(input.Diff))
                ) && 
                (
                    this.Errors == input.Errors ||
                    this.Errors != null &&
                    this.Errors.SequenceEqual(input.Errors)
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
                if (this.Summary != null)
                    hashCode = hashCode * 59 + this.Summary.GetHashCode();
                if (this.Diff != null)
                    hashCode = hashCode * 59 + this.Diff.GetHashCode();
                if (this.Errors != null)
                    hashCode = hashCode * 59 + this.Errors.GetHashCode();
                return hashCode;
            }
        }

    }

}
