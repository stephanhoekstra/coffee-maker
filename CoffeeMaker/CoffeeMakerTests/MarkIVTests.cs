using CoffeeMaker;
using CoffeeMakerApi;
using Moq;
using Xunit;

namespace CoffeeMakerTests
{
    public class MarkIVTests
    {
        private readonly MarkIV _target;
        private CofeeMakerApiStub _api;

        public MarkIVTests()
        {
            _api = new CofeeMakerApiStub();
            _target = new MarkIV(_api);
        }

        [Fact]
        public void When_Started_WithFullBoiler_ThenBoil()
        {
            _api.BoilerHasWater = true;
            _target.Start();

            Assert.True(_api.HeaterIsActive);
            Assert.False(_api.Valve);
        }

        [Fact]
        public void When_Start_WithEmptyBoiler_Then_ContinueBoiling_ButAlso_ReleasePressure()
        {
            _target.Start();
            Assert.True(_api.HeaterIsActive);
            Assert.True(_api.Valve);
        }
    }
}
