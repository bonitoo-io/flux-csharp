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
    /// query influx with specified return formatting. The spec and query fields are mutually exclusive.
    /// </summary>
    [DataContract]
    public partial class Query :  IEquatable<Query>
    {
        /// <summary>
        /// type of query
        /// </summary>
        /// <value>type of query</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum Flux for value: flux
            /// </summary>
            [EnumMember(Value = "flux")]
            Flux = 1,
            
            /// <summary>
            /// Enum Influxql for value: influxql
            /// </summary>
            [EnumMember(Value = "influxql")]
            Influxql = 2
        }

        /// <summary>
        /// type of query
        /// </summary>
        /// <value>type of query</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Query" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Query() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Query" /> class.
        /// </summary>
        /// <param name="_extern">_extern.</param>
        /// <param name="query">query script to execute. (required).</param>
        /// <param name="spec">spec.</param>
        /// <param name="type">type of query (default to TypeEnum.Flux).</param>
        /// <param name="db">required for influxql type queries.</param>
        /// <param name="rp">required for influxql type queries.</param>
        /// <param name="cluster">required for influxql type queries.</param>
        /// <param name="dialect">dialect.</param>
        public Query(System.IO.Stream _extern = default(System.IO.Stream), string query = default(string), QuerySpecification spec = default(QuerySpecification), TypeEnum? type = TypeEnum.Flux, string db = default(string), string rp = default(string), string cluster = default(string), Dialect dialect = default(Dialect))
        {
            // to ensure "query" is required (not null)
            if (query == null)
            {
                throw new InvalidDataException("query is a required property for Query and cannot be null");
            }
            else
            {
                this._Query = query;
            }
            this.Extern = _extern;
            this.Spec = spec;
            // use default value if no "type" provided
            if (type == null)
            {
                this.Type = TypeEnum.Flux;
            }
            else
            {
                this.Type = type;
            }
            this.Db = db;
            this.Rp = rp;
            this.Cluster = cluster;
            this.Dialect = dialect;
        }

        /// <summary>
        /// Gets or Sets Extern
        /// </summary>
        [DataMember(Name="extern", EmitDefaultValue=false)]
        public System.IO.Stream Extern { get; set; }

        /// <summary>
        /// query script to execute.
        /// </summary>
        /// <value>query script to execute.</value>
        [DataMember(Name="query", EmitDefaultValue=false)]
        public string _Query { get; set; }

        /// <summary>
        /// Gets or Sets Spec
        /// </summary>
        [DataMember(Name="spec", EmitDefaultValue=false)]
        public QuerySpecification Spec { get; set; }


        /// <summary>
        /// required for influxql type queries
        /// </summary>
        /// <value>required for influxql type queries</value>
        [DataMember(Name="db", EmitDefaultValue=false)]
        public string Db { get; set; }

        /// <summary>
        /// required for influxql type queries
        /// </summary>
        /// <value>required for influxql type queries</value>
        [DataMember(Name="rp", EmitDefaultValue=false)]
        public string Rp { get; set; }

        /// <summary>
        /// required for influxql type queries
        /// </summary>
        /// <value>required for influxql type queries</value>
        [DataMember(Name="cluster", EmitDefaultValue=false)]
        public string Cluster { get; set; }

        /// <summary>
        /// Gets or Sets Dialect
        /// </summary>
        [DataMember(Name="dialect", EmitDefaultValue=false)]
        public Dialect Dialect { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Query {\n");
            sb.Append("  Extern: ").Append(Extern).Append("\n");
            sb.Append("  _Query: ").Append(_Query).Append("\n");
            sb.Append("  Spec: ").Append(Spec).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Db: ").Append(Db).Append("\n");
            sb.Append("  Rp: ").Append(Rp).Append("\n");
            sb.Append("  Cluster: ").Append(Cluster).Append("\n");
            sb.Append("  Dialect: ").Append(Dialect).Append("\n");
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
            return this.Equals(input as Query);
        }

        /// <summary>
        /// Returns true if Query instances are equal
        /// </summary>
        /// <param name="input">Instance of Query to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Query input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Extern == input.Extern ||
                    (this.Extern != null &&
                    this.Extern.Equals(input.Extern))
                ) && 
                (
                    this._Query == input._Query ||
                    (this._Query != null &&
                    this._Query.Equals(input._Query))
                ) && 
                (
                    
                    (this.Spec != null &&
                    this.Spec.Equals(input.Spec))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Db == input.Db ||
                    (this.Db != null &&
                    this.Db.Equals(input.Db))
                ) && 
                (
                    this.Rp == input.Rp ||
                    (this.Rp != null &&
                    this.Rp.Equals(input.Rp))
                ) && 
                (
                    this.Cluster == input.Cluster ||
                    (this.Cluster != null &&
                    this.Cluster.Equals(input.Cluster))
                ) && 
                (
                    
                    (this.Dialect != null &&
                    this.Dialect.Equals(input.Dialect))
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
                if (this.Extern != null)
                    hashCode = hashCode * 59 + this.Extern.GetHashCode();
                if (this._Query != null)
                    hashCode = hashCode * 59 + this._Query.GetHashCode();
                if (this.Spec != null)
                    hashCode = hashCode * 59 + this.Spec.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Db != null)
                    hashCode = hashCode * 59 + this.Db.GetHashCode();
                if (this.Rp != null)
                    hashCode = hashCode * 59 + this.Rp.GetHashCode();
                if (this.Cluster != null)
                    hashCode = hashCode * 59 + this.Cluster.GetHashCode();
                if (this.Dialect != null)
                    hashCode = hashCode * 59 + this.Dialect.GetHashCode();
                return hashCode;
            }
        }

    }

}
