using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    [Collection(TestCollections.TestServer)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Maintainability", "CA1515", Justification = "Test class has to be public.")]
    public abstract class InfrastructureTestBase(GenericInfrastructureTestServerFixture fixture)
    {
        protected GenericInfrastructureTestServerFixture Fixture { get; } = fixture;
    }
}
