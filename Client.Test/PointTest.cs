using System;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using NodaTime.Text;
using NUnit.Framework;

namespace InfluxDB.Client.Test
{
    [TestFixture]
    public class PointTest
    {
        [Test]
        public void MeasurementEscape()
        {
            var point = Point.Measurement("h2 o")
                .Tag("location", "europe")
                .Tag("", "warn")
                .Field("level", 2);

            Assert.AreEqual("h2\\ o,location=europe level=2i", point.ToLineProtocol());

            point = Point.Measurement("h2=o")
                .Tag("location", "europe")
                .Tag("", "warn")
                .Field("level", 2);

            Assert.AreEqual("h2\\=o,location=europe level=2i", point.ToLineProtocol());

            point = Point.Measurement("h2,o")
                .Tag("location", "europe")
                .Tag("", "warn")
                .Field("level", 2);

            Assert.AreEqual("h2\\,o,location=europe level=2i", point.ToLineProtocol());
        }

        [Test]
        public void TagEmptyKey()
        {
            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Tag("", "warn")
                .Field("level", 2);

            Assert.AreEqual("h2o,location=europe level=2i", point.ToLineProtocol());
        }

        [Test]
        public void TagEmptyValue()
        {
            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Tag("log", "")
                .Field("level", 2);

            Assert.AreEqual("h2o,location=europe level=2i", point.ToLineProtocol());
        }

        [Test]
        public void OverrideTagField()
        {
            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Tag("location", "europe2")
                .Field("level", 2)
                .Field("level", 3);

            Assert.AreEqual("h2o,location=europe2 level=3i", point.ToLineProtocol());
        }

        [Test]
        public void FieldTypes()
        {
            var point = Point.Measurement("h2o").Tag("location", "europe")
                .Field("long", 1L)
                .Field("double", 250.69D)
                .Field("float", 35.0F)
                .Field("integer", 7)
                .Field("short", (short) 8)
                .Field("byte", (byte) 9)
                .Field("ulong", (ulong) 10)
                .Field("uint", (uint) 11)
                .Field("sbyte", (sbyte) 12)
                .Field("ushort", (ushort) 13)
                .Field("point", 13.3)
                .Field("decimal", (decimal) 25.6)
                .Field("boolean", false)
                .Field("string", "string value");

            var expected =
                "h2o,location=europe boolean=false,byte=9i,decimal=25.6,double=250.69,float=35,integer=7i,long=1i," +
                "point=13.3,sbyte=12i,short=8i,string=\"string value\",uint=11i,ulong=10i,ushort=13i";

            Assert.AreEqual(expected, point.ToLineProtocol());
        }

        [Test]
        public void FieldNullValue()
        {
            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", 2)
                .Field("warning", null);

            Assert.AreEqual("h2o,location=europe level=2i", point.ToLineProtocol());
        }

        [Test]
        public void FieldEscape()
        {
            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", "string esc\\ape value");

            Assert.AreEqual("h2o,location=europe level=\"string esc\\\\ape value\"", point.ToLineProtocol());

            point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", "string esc\"ape value");

            Assert.AreEqual("h2o,location=europe level=\"string esc\\\"ape value\"", point.ToLineProtocol());
        }

        [Test]
        public void Time()
        {
            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", 2)
                .Timestamp(123L, WritePrecision.S);

            Assert.AreEqual("h2o,location=europe level=2i 123", point.ToLineProtocol());
        }

        [Test]
        public void TimePrecisionDefault()
        {
            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", 2);

            Assert.AreEqual(WritePrecision.Ns, point.Precision);
        }

        [Test]
        public void TimeSpanFormatting()
        {
            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", 2)
                .Timestamp(TimeSpan.FromDays(1), WritePrecision.Ns);

            Assert.AreEqual("h2o,location=europe level=2i 86400000000000", point.ToLineProtocol());

            point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", 2)
                .Timestamp(TimeSpan.FromHours(356), WritePrecision.Ms);

            Assert.AreEqual("h2o,location=europe level=2i 1281600000000", point.ToLineProtocol());

            point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", 2)
                .Timestamp(TimeSpan.FromSeconds(156), WritePrecision.Ms);

            Assert.AreEqual("h2o,location=europe level=2i 156000", point.ToLineProtocol());

            point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", 2)
                .Timestamp(TimeSpan.FromSeconds(123), WritePrecision.S);

            Assert.AreEqual("h2o,location=europe level=2i 123", point.ToLineProtocol());
        }

        [Test]
        public void DateTimeFormatting()
        {
            var dateTime = new DateTime(2015, 10, 15, 8, 20, 15, DateTimeKind.Utc);

            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", 2)
                .Timestamp(dateTime, WritePrecision.Ms);

            Assert.AreEqual("h2o,location=europe level=2i 1444897215000", point.ToLineProtocol());
            
            dateTime = new DateTime(2015, 10, 15, 8, 20, 15, 750, DateTimeKind.Utc);

            point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", false)
                .Timestamp(dateTime, WritePrecision.S);
            
            Assert.AreEqual("h2o,location=europe level=false 1444897215", point.ToLineProtocol());
            
            point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", true)
                .Timestamp(DateTime.UtcNow, WritePrecision.S);

            var lineProtocol = point.ToLineProtocol();
            Assert.IsFalse(lineProtocol.Contains("."));
            
            point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", true)
                .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

            lineProtocol = point.ToLineProtocol();
            Assert.IsFalse(lineProtocol.Contains("."));
        }

        [Test]
        public void DateTimeUtc()
        {
            var dateTime = new DateTime(2015, 10, 15, 8, 20, 15);

            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", 2);

            Assert.Throws<ArgumentException>(() => point.Timestamp(dateTime, WritePrecision.Ms));
        }

        [Test]
        public void DateTimeOffsetFormatting()
        {
            var offset = DateTimeOffset.FromUnixTimeSeconds(15678);

            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", 2)
                .Timestamp(offset, WritePrecision.Ns);

            Assert.AreEqual("h2o,location=europe level=2i 15678000000000", point.ToLineProtocol());
        }

        [Test]
        public void InstantFormatting()
        {
            var instant = InstantPattern.ExtendedIso.Parse("1970-01-01T00:00:45.999999999Z").Value;
            
            var point = Point.Measurement("h2o")
                .Tag("location", "europe")
                .Field("level", 2)
                .Timestamp(instant, WritePrecision.S);
            
            Assert.AreEqual("h2o,location=europe level=2i 45", point.ToLineProtocol());
        }
    }
}