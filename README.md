# WebApisInNetCore

This repository contains PoC projects on building Web APIs using .NET Core.

## Prerequisites

* Install .NET Core 2.2 SDK
* Install .NET Core 3.0 Preview 6 SDK for gRPC

## REST

The ClassicRestAPi project shows how to setup and use NSwag and API Versioning with ASP.NET Core 2.2.

## OData

The ODataAPi project shows how to setup and use OData, Swashbuckle and API Versioning with ASP.NET Core 2.2.

## GraphQL

The GraphQLAPi project shows how to setup and use GraphQL.NET and GraphiQL with ASP.NET Core 2.2.

## gRPC

The GrpcAPi and GrpcClient projects shows how to setup and use Grpc with ASP.NET Core 3 Preview 6.

## Shared

All the above projects share the same data model: a simplified Blog Service.  
The initial data is loaded with Entity Framework Core in-memory provider and can be access via a common SharedDbContext.
This NET Standard 2.0 project contains the entities as well as the BlogService used to query or add data.
