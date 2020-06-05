using System;
using System.Diagnostics;
using InfluxDB.Client.Api.Domain;

namespace InfluxDB.Client.Writes
{
    public interface IInfluxDBEventArgs
    { 
        void LogEvent();
        EventArgs Args { get;  }
    }

    public abstract class InfluxDBEventArgs : EventArgs, IInfluxDBEventArgs
    {
        /// <summary>
        /// Logs the event while keeping it hidden from IntelliSense.
        /// </summary>
        void IInfluxDBEventArgs.LogEvent() => OnLogEvent();

        protected abstract void OnLogEvent();

        EventArgs IInfluxDBEventArgs.Args => this;
    }

    public class WriteSuccessEvent : AbstractWriteEvent
    {
        public WriteSuccessEvent(string organization, string bucket, WritePrecision precision, string lineProtocol) :
            base(organization, bucket, precision, lineProtocol)
        {
        }

        protected override void OnLogEvent()
        {
            Trace.WriteLine("The data was successfully written to InfluxDB 2.0.");
        }
    }

    public class WriteErrorEvent : AbstractWriteEvent
    {
        /// <summary>
        /// The exception that was throw.
        /// </summary>
        public Exception Exception { get; }

        public WriteErrorEvent(string organization, string bucket, WritePrecision precision, string lineProtocol, Exception exception) :
            base(organization, bucket, precision, lineProtocol)
        {
            Exception = exception;
        }

        protected override void OnLogEvent()
        {
            Trace.TraceError($"The error occurred during writing of data: {Exception.Message}");
        }
    }

    /// <summary>
    /// The event is published when occurs a retriable write exception.
    /// </summary>
    public class WriteRetriableErrorEvent : AbstractWriteEvent
    {
        /// <summary>
        /// The exception that was throw.
        /// </summary>
        public Exception Exception { get; }
        
        /// <summary>
        /// The time to wait before retry unsuccessful write (milliseconds)
        /// </summary>
        public long RetryInterval { get; }
        
        public WriteRetriableErrorEvent(string organization, string bucket, WritePrecision precision, string lineProtocol, Exception exception, long retryInterval) : base(organization, bucket, precision, lineProtocol)
        {
            Exception = exception;
            RetryInterval = retryInterval;
        }
        
        protected override void OnLogEvent()
        {
            Trace.TraceError($"The retriable error occurred during writing of data. Retry in: {RetryInterval} [ms]");
        }
    }

    public abstract class AbstractWriteEvent : InfluxDBEventArgs
    {
        /// <summary>
        /// The organization that was used for write data.
        /// </summary>
        public string Organization { get; }

        /// <summary>
        /// The bucket that was used for write data.
        /// </summary>
        public string Bucket { get; }

        /// <summary>
        /// The Precision that was used for write data.
        /// </summary>
        public WritePrecision Precision { get; }

        /// <summary>
        /// The Data that was written.
        /// </summary>
        public string LineProtocol { get; }

        internal AbstractWriteEvent(string organization, string bucket, WritePrecision precision, string lineProtocol)
        {
            Organization = organization;
            Bucket = bucket;
            Precision = precision;
            LineProtocol = lineProtocol;
        }
    }
}