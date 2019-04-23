using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InfluxDB.Client.Core;
using InfluxDB.Client.Core.Exceptions;
using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Flux;
using NodaTime;
using NUnit.Framework;

namespace Client.Legacy.Test
{
    public class ItFluxClientTest : AbstractItFluxClientTest
    {
        private static readonly string FromFluxDatabase = $"from(bucket:\"{DatabaseName}\")";

        [SetUp]
        public new void SetUp()
        {
            PrepareDara().Wait();
        }
        
        private async Task PrepareDara()
        {
            await InfluxDbWrite("mem,host=A,region=west free=10i 10000000000", DatabaseName);
            await InfluxDbWrite("mem,host=A,region=west free=11i 20000000000", DatabaseName);
            await InfluxDbWrite("mem,host=B,region=west free=20i 10000000000", DatabaseName);
            await InfluxDbWrite("mem,host=B,region=west free=22i 20000000000", DatabaseName);
            await InfluxDbWrite("cpu,host=A,region=west usage_system=35i,user_usage=45i 10000000000", DatabaseName);
            await InfluxDbWrite("cpu,host=A,region=west usage_system=38i,user_usage=49i 20000000000", DatabaseName);
            await InfluxDbWrite("cpu,host=A,hyper-threading=true,region=west usage_system=38i,user_usage=49i 20000000000", DatabaseName);
        }

        [Test]
        public async Task ChunkedOneTable() 
        {            
            await PrepareChunkRecords();

            var flux = FromFluxDatabase + "\n"
                                           + "\t|> filter(fn: (r) => r[\"_measurement\"] == \"chunked\")\n"
                                           + "\t|> range(start: 1970-01-01T00:00:00.000000000Z)";
            FluxClient.Query(flux, (cancellable, fluxRecord) => 
            {
                // +1 record
                CountdownEvent.Signal();

                if (CountdownEvent.CurrentCount % 100_000 == 0) 
                {
                    Trace.WriteLine($"Remaining parsed: {CountdownEvent.CurrentCount} records");
                }
            });

            WaitToCallback(30);
        }

        [Test]
        public async Task ChunkedMoreTables()
        {
            await PrepareChunkRecords();

            var flux = FromFluxDatabase + "\n"
                                           + "\t|> filter(fn: (r) => r[\"_measurement\"] == \"chunked\")\n"
                                           + "\t|> range(start: 1970-01-01T00:00:00.000000000Z)\n"
                                           + "\t|> window(every: 10m)";

            FluxClient.Query(flux, (cancellable, fluxRecord) =>
            {
                // +1 record
                CountdownEvent.Signal();

                if (CountdownEvent.CurrentCount % 100_000 == 0)
                {
                    Trace.WriteLine($"Remaining parsed: {CountdownEvent.CurrentCount} records");
                }
            });

            WaitToCallback(30);
        }

        [Test]
        public async Task ChunkedCancel() 
        {
            await PrepareChunkRecords();

            var flux = FromFluxDatabase + "\n"
                                             + "\t|> filter(fn: (r) => r[\"_measurement\"] == \"chunked\")\n"
                                             + "\t|> range(start: 1970-01-01T00:00:00.000000000Z)\n"
                                             + "\t|> window(every: 10m)";

            CountdownEvent = new CountdownEvent(10_000);
            var cancelCountDown = new CountdownEvent(1);

            FluxClient.Query(flux, (cancellable, fluxRecord) =>
            {
                // +1 record
                CountdownEvent.Signal();

                if (CountdownEvent.CurrentCount % 1_000 == 0 && CountdownEvent.CurrentCount != 0)
                {
                    Console.WriteLine($"Remaining parsed: {CountdownEvent.CurrentCount} records");
                }

                if (CountdownEvent.CurrentCount == 9_000)
                {
                    cancellable.Cancel();
                    cancelCountDown.Signal();
                }
            });

            // wait to cancel
            WaitToCallback(cancelCountDown, 30);

            //
            Assert.That(CountdownEvent.CurrentCount.Equals(9_000));
        }

        [Test]
        public void Query()
        {
            var flux = FromFluxDatabase + "\n"
                                           + "\t|> range(start: 1970-01-01T00:00:00.000000000Z)\n"
                                           + "\t|> filter(fn: (r) => (r[\"_measurement\"] == \"mem\" and r[\"_field\"] == \"free\"))\n"
                                           + "\t|> sum()";

            var fluxTables = FluxClient.Query(flux);

            AssertFluxResult(fluxTables);
        }

        [Test]
        public void QueryWithTime()
        {
            var flux = FromFluxDatabase + "\n"
                                           + "\t|> range(start: 1970-01-01T00:00:00.000000000Z)\n"
                                           + "\t|> filter(fn: (r) => (r[\"_measurement\"] == \"mem\" and r[\"_field\"] == \"free\"))";

            var fluxTables = FluxClient.Query(flux);

            AssertFluxResultWithTime(fluxTables);
        }

        [Test]
        public void QueryDifferentSchemas()
        {
            var flux = FromFluxDatabase + "\n"
                                           + "\t|> range(start: 1970-01-01T00:00:00.000000000Z)";

            var fluxTables = FluxClient.Query(flux);

            Assert.That(fluxTables.Count == 6);
        }
        
        [Test]
        public void Error() 
        {
            try
            {
                FluxClient.Query("from(bucket:\"telegraf\")");
                
                Assert.Fail();
            }
            catch (InfluxException e)
            {
                Assert.That(e.Message.Contains("failed to plan query:"));
                Assert.That(e.Message.Contains("results from \"telegraf\" must be bounded"));
            }
        }
        
        [Test]
        public void ErrorWithStatusOk() 
        {
            try
            {
                FluxClient.Query(FromFluxDatabase);
                
                Assert.Fail();
            }
            catch (InfluxException e)
            {
                Assert.That(e.Message.Contains("failed to plan query:"));
                Assert.That(e.Message.Contains("results from \"flux_database\" must be bounded"));
            }
        }

        [Test]
        public void Callback()
        {
            CountdownEvent = new CountdownEvent(3);
            var records = new List<FluxRecord>();

            var flux = FromFluxDatabase + "\n"
                                           + "\t|> range(start: 1970-01-01T00:00:00.000000000Z)\n"
                                           + "\t|> filter(fn: (r) => (r[\"_measurement\"] == \"mem\" and r[\"_field\"] == \"free\"))\n"
                                           + "\t|> sum()";

            FluxClient.Query(flux, (cancellable, record) =>
                            {
                                records.Add(record);
                                CountdownEvent.Signal();
                            },
                            error => Assert.Fail("Unreachable"),
                            () => CountdownEvent.Signal());

            WaitToCallback();
            AssertFluxRecords(records);
        }

        [Test]
        public void CallbackWhenConnectionRefuse()
        {
            var options = new FluxConnectionOptions("http://localhost:8003");

            var fluxClient = FluxClientFactory.Create(options);

            fluxClient.Query(FromFluxDatabase + " |> last()",
                            (cancellable, record) => { },
                            error => CountdownEvent.Signal());

            WaitToCallback();
        }

        [Test]
        public void CallbackToMeasurement()
        {
            var flux = FromFluxDatabase + "\n"
                                           + "\t|> range(start: 1970-01-01T00:00:00.000000000Z)\n"
                                           + "\t|> filter(fn: (r) => (r[\"_measurement\"] == \"mem\" and r[\"_field\"] == \"free\"))";

            var memory = new List<Mem>();

            CountdownEvent = new CountdownEvent(4);

             FluxClient.Query<Mem>(flux, (cancellable, mem) =>
            {
                memory.Add(mem);
                CountdownEvent.Signal();
            });

            WaitToCallback();

            Assert.That(memory.Count == 4);

            Assert.AreEqual(memory[0].Host, "A");
            Assert.AreEqual(memory[0].Region, "west");
            Assert.AreEqual(memory[0].Free, 10L);
            Assert.AreEqual(memory[0].Time, Instant.Add(new Instant(), Duration.FromSeconds(10L)));

            Assert.AreEqual(memory[1].Host, "A");
            Assert.AreEqual(memory[1].Region, "west");
            Assert.AreEqual(memory[1].Free, 11L);
            Assert.AreEqual(memory[1].Time, Instant.Add(new Instant(), Duration.FromSeconds(20L)));

            Assert.AreEqual(memory[2].Host, "B");
            Assert.AreEqual(memory[2].Region, "west");
            Assert.AreEqual(memory[2].Free, 20L);
            Assert.AreEqual(memory[2].Time, Instant.Add(new Instant(), Duration.FromSeconds(10L)));

            Assert.AreEqual(memory[3].Host, "B");
            Assert.AreEqual(memory[3].Region, "west");
            Assert.AreEqual(memory[3].Free, 22L);
            Assert.AreEqual(memory[3].Time, Instant.Add(new Instant(), Duration.FromSeconds(20L)));
        }

        [Test]
        public void Ping() 
        {
            Assert.IsTrue(FluxClient.Ping());
        }
        
        [Test]
        public void Version()
        {
            var version = FluxClient.Version();
            
            Assert.IsNotEmpty(version);
        }
        
        [Test]
        public void Logging()
        {
            // Default None
            Assert.AreEqual(LogLevel.None, FluxClient.GetLogLevel());
            
            // Headers
            FluxClient.SetLogLevel(LogLevel.Headers);
            Assert.AreEqual(LogLevel.Headers, FluxClient.GetLogLevel());
        }

        private async Task PrepareChunkRecords() 
        {
            var totalRecords = 500_000;
            CountdownEvent = new CountdownEvent(totalRecords);

            var points = new List<string>();

            for (var ii = 1; ii <= totalRecords + 1; ii++)
            {
                var value = string.Format("chunked,host=A,region=west free={0}i {0}", ii);
                points.Add(value);
                
                if (ii % 100_000 == 0) 
                {
                    await InfluxDbWrite(string.Join("\n", points), DatabaseName);
                    points.Clear();
                }
            }
        }
        
        private void AssertFluxResult(IReadOnlyList<FluxTable> tables) 
        {
            Assert.IsNotNull(tables);

            Assert.That(tables.Count == 2);

            var table1 = tables[0];
            
            // Data types
            Assert.That(table1.Columns.Count == 9);
            var expected = new List<string>{"string", "long", "dateTime:RFC3339", "dateTime:RFC3339", "long", "string", "string", "string", "string"};
            CollectionAssert.AreEquivalent(table1.Columns.Select(c => c.DataType).ToList(), expected);

            // Columns
            var expected2 = new List<string>{"result", "table", "_start", "_stop", "_value", "_field", "_measurement", "host", "region"};
            CollectionAssert.AreEquivalent(table1.Columns.Select(c => c.Label).ToList(), expected2);

            // Records
            Assert.That(table1.Records.Count == 1);

            var records = new List<FluxRecord> {table1.Records[0], tables[1].Records[0]};
            AssertFluxRecords(records);
        }
        
        private void AssertFluxResultWithTime(IReadOnlyList<FluxTable> tables) 
        {
            Assert.IsNotNull(tables);

            Assert.That(tables.Count == 2);

            var table1 = tables[0];
            
            // Data types
            Assert.That(table1.Columns.Count == 10);
            var expected = new List<string>{"string", "long", "dateTime:RFC3339", "dateTime:RFC3339", "dateTime:RFC3339", "long", "string", "string", "string", "string"};
            CollectionAssert.AreEquivalent(table1.Columns.Select(c => c.DataType).ToList(), expected);

            // Columns
            var expected2 = new List<string>{"result", "table", "_start", "_stop", "_time", "_value", "_field", "_measurement", "host", "region"};
            CollectionAssert.AreEquivalent(table1.Columns.Select(c => c.Label).ToList(), expected2);

            // Records
            Assert.That(table1.Records.Count == 2);
            Assert.That(tables[1].Records.Count == 2);
        }
        
        private void AssertFluxRecords(IReadOnlyList<FluxRecord> records) 
        {
            Assert.NotNull(records);
            Assert.That(records.Count == 2);

            // Record 1
            var record1 = records[0];
            Assert.AreEqual(record1.GetMeasurement(), "mem");
            Assert.AreEqual(record1.GetField(), "free");

            Assert.AreEqual(record1.GetStart(), new Instant());
            Assert.NotNull(record1.GetStop());
            Assert.IsNull(record1.GetTime());
            
            Assert.AreEqual(record1.GetValue(), 21L);

            Assert.AreEqual("A", record1.GetValueByKey("host"));
            Assert.AreEqual("west", record1.GetValueByKey("region"));
            
            // Record 2
            var record2 = records[1];
            Assert.AreEqual(record2.GetMeasurement(), "mem");
            Assert.AreEqual(record2.GetField(), "free");

            Assert.AreEqual(record2.GetStart(), new Instant());
            Assert.NotNull(record2.GetStop());
            Assert.IsNull(record2.GetTime());

            Assert.AreEqual(record2.GetValue(), 42L);

            Assert.AreEqual("B", record2.GetValueByKey("host"));
            Assert.AreEqual("west", record2.GetValueByKey("region"));
        }
        
        private class Mem 
        {
            public string Host { get; set; }
            public string Region { get; set; }

            [Column("_value")]
            public long Free { get; set; }
            
            [Column("_time")]
            public Instant Time { get; set; }
        }
    }
}