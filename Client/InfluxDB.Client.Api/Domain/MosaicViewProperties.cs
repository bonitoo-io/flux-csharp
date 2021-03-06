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
    /// MosaicViewProperties
    /// </summary>
    [DataContract]
    public partial class MosaicViewProperties : ViewProperties,  IEquatable<MosaicViewProperties>
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Mosaic for value: mosaic
            /// </summary>
            [EnumMember(Value = "mosaic")]
            Mosaic = 1

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
        /// Defines HoverDimension
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum HoverDimensionEnum
        {
            /// <summary>
            /// Enum Auto for value: auto
            /// </summary>
            [EnumMember(Value = "auto")]
            Auto = 1,

            /// <summary>
            /// Enum X for value: x
            /// </summary>
            [EnumMember(Value = "x")]
            X = 2,

            /// <summary>
            /// Enum Y for value: y
            /// </summary>
            [EnumMember(Value = "y")]
            Y = 3,

            /// <summary>
            /// Enum Xy for value: xy
            /// </summary>
            [EnumMember(Value = "xy")]
            Xy = 4

        }

        /// <summary>
        /// Gets or Sets HoverDimension
        /// </summary>
        [DataMember(Name="hoverDimension", EmitDefaultValue=false)]
        public HoverDimensionEnum? HoverDimension { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MosaicViewProperties" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MosaicViewProperties() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MosaicViewProperties" /> class.
        /// </summary>
        /// <param name="timeFormat">timeFormat.</param>
        /// <param name="type">type (required) (default to TypeEnum.Mosaic).</param>
        /// <param name="queries">queries (required).</param>
        /// <param name="colors">Colors define color encoding of data into a visualization (required).</param>
        /// <param name="shape">shape (required) (default to ShapeEnum.ChronografV2).</param>
        /// <param name="note">note (required).</param>
        /// <param name="showNoteWhenEmpty">If true, will display note when empty (required).</param>
        /// <param name="xColumn">xColumn (required).</param>
        /// <param name="generateXAxisTicks">generateXAxisTicks.</param>
        /// <param name="xTotalTicks">xTotalTicks.</param>
        /// <param name="xTickStart">xTickStart.</param>
        /// <param name="xTickStep">xTickStep.</param>
        /// <param name="yLabelColumnSeparator">yLabelColumnSeparator.</param>
        /// <param name="yLabelColumns">yLabelColumns.</param>
        /// <param name="ySeriesColumns">ySeriesColumns (required).</param>
        /// <param name="fillColumns">fillColumns (required).</param>
        /// <param name="xDomain">xDomain (required).</param>
        /// <param name="yDomain">yDomain (required).</param>
        /// <param name="xAxisLabel">xAxisLabel (required).</param>
        /// <param name="yAxisLabel">yAxisLabel (required).</param>
        /// <param name="xPrefix">xPrefix (required).</param>
        /// <param name="xSuffix">xSuffix (required).</param>
        /// <param name="yPrefix">yPrefix (required).</param>
        /// <param name="ySuffix">ySuffix (required).</param>
        /// <param name="hoverDimension">hoverDimension.</param>
        /// <param name="legendColorizeRows">legendColorizeRows.</param>
        /// <param name="legendHide">legendHide.</param>
        /// <param name="legendOpacity">legendOpacity.</param>
        /// <param name="legendOrientationThreshold">legendOrientationThreshold.</param>
        public MosaicViewProperties(string timeFormat = default(string), TypeEnum type = TypeEnum.Mosaic, List<DashboardQuery> queries = default(List<DashboardQuery>), List<string> colors = default(List<string>), ShapeEnum shape = ShapeEnum.ChronografV2, string note = default(string), bool? showNoteWhenEmpty = default(bool?), string xColumn = default(string), List<string> generateXAxisTicks = default(List<string>), int? xTotalTicks = default(int?), float? xTickStart = default(float?), float? xTickStep = default(float?), string yLabelColumnSeparator = default(string), List<string> yLabelColumns = default(List<string>), List<string> ySeriesColumns = default(List<string>), List<string> fillColumns = default(List<string>), List<decimal?> xDomain = default(List<decimal?>), List<decimal?> yDomain = default(List<decimal?>), string xAxisLabel = default(string), string yAxisLabel = default(string), string xPrefix = default(string), string xSuffix = default(string), string yPrefix = default(string), string ySuffix = default(string), HoverDimensionEnum? hoverDimension = default(HoverDimensionEnum?), bool? legendColorizeRows = default(bool?), bool? legendHide = default(bool?), float? legendOpacity = default(float?), int? legendOrientationThreshold = default(int?)) : base()
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            // to ensure "queries" is required (not null)
            if (queries == null)
            {
                throw new InvalidDataException("queries is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.Queries = queries;
            }
            // to ensure "colors" is required (not null)
            if (colors == null)
            {
                throw new InvalidDataException("colors is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.Colors = colors;
            }
            // to ensure "shape" is required (not null)
            if (shape == null)
            {
                throw new InvalidDataException("shape is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.Shape = shape;
            }
            // to ensure "note" is required (not null)
            if (note == null)
            {
                throw new InvalidDataException("note is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.Note = note;
            }
            // to ensure "showNoteWhenEmpty" is required (not null)
            if (showNoteWhenEmpty == null)
            {
                throw new InvalidDataException("showNoteWhenEmpty is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.ShowNoteWhenEmpty = showNoteWhenEmpty;
            }
            // to ensure "xColumn" is required (not null)
            if (xColumn == null)
            {
                throw new InvalidDataException("xColumn is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.XColumn = xColumn;
            }
            // to ensure "ySeriesColumns" is required (not null)
            if (ySeriesColumns == null)
            {
                throw new InvalidDataException("ySeriesColumns is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.YSeriesColumns = ySeriesColumns;
            }
            // to ensure "fillColumns" is required (not null)
            if (fillColumns == null)
            {
                throw new InvalidDataException("fillColumns is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.FillColumns = fillColumns;
            }
            // to ensure "xDomain" is required (not null)
            if (xDomain == null)
            {
                throw new InvalidDataException("xDomain is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.XDomain = xDomain;
            }
            // to ensure "yDomain" is required (not null)
            if (yDomain == null)
            {
                throw new InvalidDataException("yDomain is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.YDomain = yDomain;
            }
            // to ensure "xAxisLabel" is required (not null)
            if (xAxisLabel == null)
            {
                throw new InvalidDataException("xAxisLabel is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.XAxisLabel = xAxisLabel;
            }
            // to ensure "yAxisLabel" is required (not null)
            if (yAxisLabel == null)
            {
                throw new InvalidDataException("yAxisLabel is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.YAxisLabel = yAxisLabel;
            }
            // to ensure "xPrefix" is required (not null)
            if (xPrefix == null)
            {
                throw new InvalidDataException("xPrefix is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.XPrefix = xPrefix;
            }
            // to ensure "xSuffix" is required (not null)
            if (xSuffix == null)
            {
                throw new InvalidDataException("xSuffix is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.XSuffix = xSuffix;
            }
            // to ensure "yPrefix" is required (not null)
            if (yPrefix == null)
            {
                throw new InvalidDataException("yPrefix is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.YPrefix = yPrefix;
            }
            // to ensure "ySuffix" is required (not null)
            if (ySuffix == null)
            {
                throw new InvalidDataException("ySuffix is a required property for MosaicViewProperties and cannot be null");
            }
            else
            {
                this.YSuffix = ySuffix;
            }
            this.TimeFormat = timeFormat;
            this.GenerateXAxisTicks = generateXAxisTicks;
            this.XTotalTicks = xTotalTicks;
            this.XTickStart = xTickStart;
            this.XTickStep = xTickStep;
            this.YLabelColumnSeparator = yLabelColumnSeparator;
            this.YLabelColumns = yLabelColumns;
            this.HoverDimension = hoverDimension;
            this.LegendColorizeRows = legendColorizeRows;
            this.LegendHide = legendHide;
            this.LegendOpacity = legendOpacity;
            this.LegendOrientationThreshold = legendOrientationThreshold;
        }

        /// <summary>
        /// Gets or Sets TimeFormat
        /// </summary>
        [DataMember(Name="timeFormat", EmitDefaultValue=false)]
        public string TimeFormat { get; set; }


        /// <summary>
        /// Gets or Sets Queries
        /// </summary>
        [DataMember(Name="queries", EmitDefaultValue=false)]
        public List<DashboardQuery> Queries { get; set; }

        /// <summary>
        /// Colors define color encoding of data into a visualization
        /// </summary>
        /// <value>Colors define color encoding of data into a visualization</value>
        [DataMember(Name="colors", EmitDefaultValue=false)]
        public List<string> Colors { get; set; }


        /// <summary>
        /// Gets or Sets Note
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue=false)]
        public string Note { get; set; }

        /// <summary>
        /// If true, will display note when empty
        /// </summary>
        /// <value>If true, will display note when empty</value>
        [DataMember(Name="showNoteWhenEmpty", EmitDefaultValue=false)]
        public bool? ShowNoteWhenEmpty { get; set; }

        /// <summary>
        /// Gets or Sets XColumn
        /// </summary>
        [DataMember(Name="xColumn", EmitDefaultValue=false)]
        public string XColumn { get; set; }

        /// <summary>
        /// Gets or Sets GenerateXAxisTicks
        /// </summary>
        [DataMember(Name="generateXAxisTicks", EmitDefaultValue=false)]
        public List<string> GenerateXAxisTicks { get; set; }

        /// <summary>
        /// Gets or Sets XTotalTicks
        /// </summary>
        [DataMember(Name="xTotalTicks", EmitDefaultValue=false)]
        public int? XTotalTicks { get; set; }

        /// <summary>
        /// Gets or Sets XTickStart
        /// </summary>
        [DataMember(Name="xTickStart", EmitDefaultValue=false)]
        public float? XTickStart { get; set; }

        /// <summary>
        /// Gets or Sets XTickStep
        /// </summary>
        [DataMember(Name="xTickStep", EmitDefaultValue=false)]
        public float? XTickStep { get; set; }

        /// <summary>
        /// Gets or Sets YLabelColumnSeparator
        /// </summary>
        [DataMember(Name="yLabelColumnSeparator", EmitDefaultValue=false)]
        public string YLabelColumnSeparator { get; set; }

        /// <summary>
        /// Gets or Sets YLabelColumns
        /// </summary>
        [DataMember(Name="yLabelColumns", EmitDefaultValue=false)]
        public List<string> YLabelColumns { get; set; }

        /// <summary>
        /// Gets or Sets YSeriesColumns
        /// </summary>
        [DataMember(Name="ySeriesColumns", EmitDefaultValue=false)]
        public List<string> YSeriesColumns { get; set; }

        /// <summary>
        /// Gets or Sets FillColumns
        /// </summary>
        [DataMember(Name="fillColumns", EmitDefaultValue=false)]
        public List<string> FillColumns { get; set; }

        /// <summary>
        /// Gets or Sets XDomain
        /// </summary>
        [DataMember(Name="xDomain", EmitDefaultValue=false)]
        public List<decimal?> XDomain { get; set; }

        /// <summary>
        /// Gets or Sets YDomain
        /// </summary>
        [DataMember(Name="yDomain", EmitDefaultValue=false)]
        public List<decimal?> YDomain { get; set; }

        /// <summary>
        /// Gets or Sets XAxisLabel
        /// </summary>
        [DataMember(Name="xAxisLabel", EmitDefaultValue=false)]
        public string XAxisLabel { get; set; }

        /// <summary>
        /// Gets or Sets YAxisLabel
        /// </summary>
        [DataMember(Name="yAxisLabel", EmitDefaultValue=false)]
        public string YAxisLabel { get; set; }

        /// <summary>
        /// Gets or Sets XPrefix
        /// </summary>
        [DataMember(Name="xPrefix", EmitDefaultValue=false)]
        public string XPrefix { get; set; }

        /// <summary>
        /// Gets or Sets XSuffix
        /// </summary>
        [DataMember(Name="xSuffix", EmitDefaultValue=false)]
        public string XSuffix { get; set; }

        /// <summary>
        /// Gets or Sets YPrefix
        /// </summary>
        [DataMember(Name="yPrefix", EmitDefaultValue=false)]
        public string YPrefix { get; set; }

        /// <summary>
        /// Gets or Sets YSuffix
        /// </summary>
        [DataMember(Name="ySuffix", EmitDefaultValue=false)]
        public string YSuffix { get; set; }


        /// <summary>
        /// Gets or Sets LegendColorizeRows
        /// </summary>
        [DataMember(Name="legendColorizeRows", EmitDefaultValue=false)]
        public bool? LegendColorizeRows { get; set; }

        /// <summary>
        /// Gets or Sets LegendHide
        /// </summary>
        [DataMember(Name="legendHide", EmitDefaultValue=false)]
        public bool? LegendHide { get; set; }

        /// <summary>
        /// Gets or Sets LegendOpacity
        /// </summary>
        [DataMember(Name="legendOpacity", EmitDefaultValue=false)]
        public float? LegendOpacity { get; set; }

        /// <summary>
        /// Gets or Sets LegendOrientationThreshold
        /// </summary>
        [DataMember(Name="legendOrientationThreshold", EmitDefaultValue=false)]
        public int? LegendOrientationThreshold { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MosaicViewProperties {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  TimeFormat: ").Append(TimeFormat).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Queries: ").Append(Queries).Append("\n");
            sb.Append("  Colors: ").Append(Colors).Append("\n");
            sb.Append("  Shape: ").Append(Shape).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  ShowNoteWhenEmpty: ").Append(ShowNoteWhenEmpty).Append("\n");
            sb.Append("  XColumn: ").Append(XColumn).Append("\n");
            sb.Append("  GenerateXAxisTicks: ").Append(GenerateXAxisTicks).Append("\n");
            sb.Append("  XTotalTicks: ").Append(XTotalTicks).Append("\n");
            sb.Append("  XTickStart: ").Append(XTickStart).Append("\n");
            sb.Append("  XTickStep: ").Append(XTickStep).Append("\n");
            sb.Append("  YLabelColumnSeparator: ").Append(YLabelColumnSeparator).Append("\n");
            sb.Append("  YLabelColumns: ").Append(YLabelColumns).Append("\n");
            sb.Append("  YSeriesColumns: ").Append(YSeriesColumns).Append("\n");
            sb.Append("  FillColumns: ").Append(FillColumns).Append("\n");
            sb.Append("  XDomain: ").Append(XDomain).Append("\n");
            sb.Append("  YDomain: ").Append(YDomain).Append("\n");
            sb.Append("  XAxisLabel: ").Append(XAxisLabel).Append("\n");
            sb.Append("  YAxisLabel: ").Append(YAxisLabel).Append("\n");
            sb.Append("  XPrefix: ").Append(XPrefix).Append("\n");
            sb.Append("  XSuffix: ").Append(XSuffix).Append("\n");
            sb.Append("  YPrefix: ").Append(YPrefix).Append("\n");
            sb.Append("  YSuffix: ").Append(YSuffix).Append("\n");
            sb.Append("  HoverDimension: ").Append(HoverDimension).Append("\n");
            sb.Append("  LegendColorizeRows: ").Append(LegendColorizeRows).Append("\n");
            sb.Append("  LegendHide: ").Append(LegendHide).Append("\n");
            sb.Append("  LegendOpacity: ").Append(LegendOpacity).Append("\n");
            sb.Append("  LegendOrientationThreshold: ").Append(LegendOrientationThreshold).Append("\n");
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
            return this.Equals(input as MosaicViewProperties);
        }

        /// <summary>
        /// Returns true if MosaicViewProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of MosaicViewProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MosaicViewProperties input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.TimeFormat == input.TimeFormat ||
                    (this.TimeFormat != null &&
                    this.TimeFormat.Equals(input.TimeFormat))
                ) && base.Equals(input) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && base.Equals(input) && 
                (
                    this.Queries == input.Queries ||
                    this.Queries != null &&
                    this.Queries.SequenceEqual(input.Queries)
                ) && base.Equals(input) && 
                (
                    this.Colors == input.Colors ||
                    this.Colors != null &&
                    this.Colors.SequenceEqual(input.Colors)
                ) && base.Equals(input) && 
                (
                    this.Shape == input.Shape ||
                    (this.Shape != null &&
                    this.Shape.Equals(input.Shape))
                ) && base.Equals(input) && 
                (
                    this.Note == input.Note ||
                    (this.Note != null &&
                    this.Note.Equals(input.Note))
                ) && base.Equals(input) && 
                (
                    this.ShowNoteWhenEmpty == input.ShowNoteWhenEmpty ||
                    (this.ShowNoteWhenEmpty != null &&
                    this.ShowNoteWhenEmpty.Equals(input.ShowNoteWhenEmpty))
                ) && base.Equals(input) && 
                (
                    this.XColumn == input.XColumn ||
                    (this.XColumn != null &&
                    this.XColumn.Equals(input.XColumn))
                ) && base.Equals(input) && 
                (
                    this.GenerateXAxisTicks == input.GenerateXAxisTicks ||
                    this.GenerateXAxisTicks != null &&
                    this.GenerateXAxisTicks.SequenceEqual(input.GenerateXAxisTicks)
                ) && base.Equals(input) && 
                (
                    this.XTotalTicks == input.XTotalTicks ||
                    (this.XTotalTicks != null &&
                    this.XTotalTicks.Equals(input.XTotalTicks))
                ) && base.Equals(input) && 
                (
                    this.XTickStart == input.XTickStart ||
                    (this.XTickStart != null &&
                    this.XTickStart.Equals(input.XTickStart))
                ) && base.Equals(input) && 
                (
                    this.XTickStep == input.XTickStep ||
                    (this.XTickStep != null &&
                    this.XTickStep.Equals(input.XTickStep))
                ) && base.Equals(input) && 
                (
                    this.YLabelColumnSeparator == input.YLabelColumnSeparator ||
                    (this.YLabelColumnSeparator != null &&
                    this.YLabelColumnSeparator.Equals(input.YLabelColumnSeparator))
                ) && base.Equals(input) && 
                (
                    this.YLabelColumns == input.YLabelColumns ||
                    this.YLabelColumns != null &&
                    this.YLabelColumns.SequenceEqual(input.YLabelColumns)
                ) && base.Equals(input) && 
                (
                    this.YSeriesColumns == input.YSeriesColumns ||
                    this.YSeriesColumns != null &&
                    this.YSeriesColumns.SequenceEqual(input.YSeriesColumns)
                ) && base.Equals(input) && 
                (
                    this.FillColumns == input.FillColumns ||
                    this.FillColumns != null &&
                    this.FillColumns.SequenceEqual(input.FillColumns)
                ) && base.Equals(input) && 
                (
                    this.XDomain == input.XDomain ||
                    this.XDomain != null &&
                    this.XDomain.SequenceEqual(input.XDomain)
                ) && base.Equals(input) && 
                (
                    this.YDomain == input.YDomain ||
                    this.YDomain != null &&
                    this.YDomain.SequenceEqual(input.YDomain)
                ) && base.Equals(input) && 
                (
                    this.XAxisLabel == input.XAxisLabel ||
                    (this.XAxisLabel != null &&
                    this.XAxisLabel.Equals(input.XAxisLabel))
                ) && base.Equals(input) && 
                (
                    this.YAxisLabel == input.YAxisLabel ||
                    (this.YAxisLabel != null &&
                    this.YAxisLabel.Equals(input.YAxisLabel))
                ) && base.Equals(input) && 
                (
                    this.XPrefix == input.XPrefix ||
                    (this.XPrefix != null &&
                    this.XPrefix.Equals(input.XPrefix))
                ) && base.Equals(input) && 
                (
                    this.XSuffix == input.XSuffix ||
                    (this.XSuffix != null &&
                    this.XSuffix.Equals(input.XSuffix))
                ) && base.Equals(input) && 
                (
                    this.YPrefix == input.YPrefix ||
                    (this.YPrefix != null &&
                    this.YPrefix.Equals(input.YPrefix))
                ) && base.Equals(input) && 
                (
                    this.YSuffix == input.YSuffix ||
                    (this.YSuffix != null &&
                    this.YSuffix.Equals(input.YSuffix))
                ) && base.Equals(input) && 
                (
                    this.HoverDimension == input.HoverDimension ||
                    (this.HoverDimension != null &&
                    this.HoverDimension.Equals(input.HoverDimension))
                ) && base.Equals(input) && 
                (
                    this.LegendColorizeRows == input.LegendColorizeRows ||
                    (this.LegendColorizeRows != null &&
                    this.LegendColorizeRows.Equals(input.LegendColorizeRows))
                ) && base.Equals(input) && 
                (
                    this.LegendHide == input.LegendHide ||
                    (this.LegendHide != null &&
                    this.LegendHide.Equals(input.LegendHide))
                ) && base.Equals(input) && 
                (
                    this.LegendOpacity == input.LegendOpacity ||
                    (this.LegendOpacity != null &&
                    this.LegendOpacity.Equals(input.LegendOpacity))
                ) && base.Equals(input) && 
                (
                    this.LegendOrientationThreshold == input.LegendOrientationThreshold ||
                    (this.LegendOrientationThreshold != null &&
                    this.LegendOrientationThreshold.Equals(input.LegendOrientationThreshold))
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
                if (this.TimeFormat != null)
                    hashCode = hashCode * 59 + this.TimeFormat.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Queries != null)
                    hashCode = hashCode * 59 + this.Queries.GetHashCode();
                if (this.Colors != null)
                    hashCode = hashCode * 59 + this.Colors.GetHashCode();
                if (this.Shape != null)
                    hashCode = hashCode * 59 + this.Shape.GetHashCode();
                if (this.Note != null)
                    hashCode = hashCode * 59 + this.Note.GetHashCode();
                if (this.ShowNoteWhenEmpty != null)
                    hashCode = hashCode * 59 + this.ShowNoteWhenEmpty.GetHashCode();
                if (this.XColumn != null)
                    hashCode = hashCode * 59 + this.XColumn.GetHashCode();
                if (this.GenerateXAxisTicks != null)
                    hashCode = hashCode * 59 + this.GenerateXAxisTicks.GetHashCode();
                if (this.XTotalTicks != null)
                    hashCode = hashCode * 59 + this.XTotalTicks.GetHashCode();
                if (this.XTickStart != null)
                    hashCode = hashCode * 59 + this.XTickStart.GetHashCode();
                if (this.XTickStep != null)
                    hashCode = hashCode * 59 + this.XTickStep.GetHashCode();
                if (this.YLabelColumnSeparator != null)
                    hashCode = hashCode * 59 + this.YLabelColumnSeparator.GetHashCode();
                if (this.YLabelColumns != null)
                    hashCode = hashCode * 59 + this.YLabelColumns.GetHashCode();
                if (this.YSeriesColumns != null)
                    hashCode = hashCode * 59 + this.YSeriesColumns.GetHashCode();
                if (this.FillColumns != null)
                    hashCode = hashCode * 59 + this.FillColumns.GetHashCode();
                if (this.XDomain != null)
                    hashCode = hashCode * 59 + this.XDomain.GetHashCode();
                if (this.YDomain != null)
                    hashCode = hashCode * 59 + this.YDomain.GetHashCode();
                if (this.XAxisLabel != null)
                    hashCode = hashCode * 59 + this.XAxisLabel.GetHashCode();
                if (this.YAxisLabel != null)
                    hashCode = hashCode * 59 + this.YAxisLabel.GetHashCode();
                if (this.XPrefix != null)
                    hashCode = hashCode * 59 + this.XPrefix.GetHashCode();
                if (this.XSuffix != null)
                    hashCode = hashCode * 59 + this.XSuffix.GetHashCode();
                if (this.YPrefix != null)
                    hashCode = hashCode * 59 + this.YPrefix.GetHashCode();
                if (this.YSuffix != null)
                    hashCode = hashCode * 59 + this.YSuffix.GetHashCode();
                if (this.HoverDimension != null)
                    hashCode = hashCode * 59 + this.HoverDimension.GetHashCode();
                if (this.LegendColorizeRows != null)
                    hashCode = hashCode * 59 + this.LegendColorizeRows.GetHashCode();
                if (this.LegendHide != null)
                    hashCode = hashCode * 59 + this.LegendHide.GetHashCode();
                if (this.LegendOpacity != null)
                    hashCode = hashCode * 59 + this.LegendOpacity.GetHashCode();
                if (this.LegendOrientationThreshold != null)
                    hashCode = hashCode * 59 + this.LegendOrientationThreshold.GetHashCode();
                return hashCode;
            }
        }

    }

}
