// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "For avoid xUnit1027.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure.TestServerCollectionFixture")]
[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "Public visibility is required by xUnit test discovery and fixture binding.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure.GenericInfrastructureTestServerFixture")]
[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "Public visibility is required by xUnit test discovery and fixture binding.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure.InfrastructureTestBase")]
[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "Public visibility is required for MVC controller discovery in TestServer.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Controllers.TestEchoController")]
[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "Public visibility is required for MVC model binding in TestServer endpoint action.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Controllers.EchoRequest")]
