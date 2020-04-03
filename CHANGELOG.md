## 1.7.0 [unreleased]

1. [#69](https://github.com/influxdata/influxdb-client-csharp/pull/69): Write buffer uses correct flush interval and batch size under heavy load

## 1.6.0 [2020-03-13]

### Features
1. [#61](https://github.com/influxdata/influxdb-client-csharp/issues/61): Set User-Agent to influxdb-client-csharp/VERSION for all requests
1. [#64](https://github.com/influxdata/influxdb-client-csharp/issues/64): Add authentication with Username and Password for Client.Legacy

### Bugs
1. [#63](https://github.com/influxdata/influxdb-client-csharp/pull/63): Correctly parse CSV where multiple results include multiple tables

## 1.5.0 [2020-02-14]

### Features
1. [#57](https://github.com/influxdata/influxdb-client-csharp/pull/57): LogLevel Header also contains query parameters

### CI
1. [#58](https://github.com/influxdata/influxdb-client-csharp/pull/58): CircleCI builds over dotnet 2.2, 3.0 and 3.1; Added build on Windows Server 2019
1. [#60](https://github.com/influxdata/influxdb-client-csharp/pull/60): Deploy dev version to Nuget repository

## 1.4.0 [2020-01-17]

### API
1. [#52](https://github.com/influxdata/influxdb-client-csharp/pull/52): Updated swagger to latest version

### CI
1. [#54](https://github.com/influxdata/influxdb-client-csharp/pull/54): Added beta release to continuous integration

### Bugs
1. [#56](https://github.com/influxdata/influxdb-client-csharp/issues/56): WriteApi is disposed after a buffer is fully processed

## 1.3.0 [2019-12-06]

### Performance

1. [#49](https://github.com/influxdata/influxdb-client-csharp/pull/49): Optimized serialization to LineProtocol

### API
1. [#46](https://github.com/influxdata/influxdb-client-csharp/pull/46): Updated swagger to latest version

### Bugs
1. [#45](https://github.com/influxdata/influxdb-client-csharp/issues/45): Assemblies are strong-named
2. [#48](https://github.com/influxdata/influxdb-client-csharp/pull/48): Packing library icon into a package

## 1.2.0 [2019-11-08]

### Features
1. [#43](https://github.com/influxdata/influxdb-client-csharp/issues/43) Added DeleteApi

### API
1. [#42](https://github.com/influxdata/influxdb-client-csharp/pull/42): Updated swagger to latest version

## 1.1.0 [2019-10-11]

### Breaking Changes
1. [#34](https://github.com/influxdata/influxdb-client-csharp/issues/34): Renamed Point class to PointData and Task class to TaskType (improving the usability of this library)
1. [#40](https://github.com/influxdata/influxdb-client-csharp/pull/40): Added `Async` suffix into asynchronous methods

### Features
1. [#59](https://github.com/influxdata/influxdb-client-csharp/pull/41): Added support for Monitoring & Alerting

### API
1. [#36](https://github.com/influxdata/influxdb-client-csharp/issues/36): Updated swagger to latest version

### Bugs
1. [#31](https://github.com/influxdata/influxdb-client-csharp/issues/31): Drop NaN and infinity values from fields when writing to InfluxDB
1. [#39](https://github.com/influxdata/influxdb-client-csharp/pull/39): FluxCSVParser uses a CultureInfo for parsing string to double

## 1.0.0 [2019-08-23]

### Features
1. [#29](https://github.com/influxdata/influxdb-client-csharp/issues/29): Added support for gzip compression of query response and write body 

### Bugs
1. [#27](https://github.com/influxdata/influxdb-client-csharp/issues/27): The org parameter takes either the ID or Name interchangeably

### API
1. [#25](https://github.com/influxdata/influxdb-client-csharp/issues/25): Updated swagger to latest version

## 1.0.0.M2 [2019-08-01]

### Features
1. [#18](https://github.com/influxdata/influxdb-client-csharp/issues/18): Auto-configure client from configuration file
1. [#20](https://github.com/influxdata/influxdb-client-csharp/issues/19): Possibility to specify default tags

### Bugs
1. [#24](https://github.com/influxdata/influxdb-client-csharp/issues/24): The data point without field should be ignored

## 1.0.0.M1

### Features
1. [Client](https://github.com/influxdata/influxdb-client-csharp/tree/master/Client#influxdbclient): The reference C# client that allows query, write and InfluxDB 2.0 management
1. [Client.Legacy](https://github.com/influxdata/influxdb-client-csharp/tree/master/Client.Legacy#influxdbclientflux): The reference C# client that allows you to perform Flux queries against InfluxDB 1.7+
