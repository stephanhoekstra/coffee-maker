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
        public void When_Started_WithFullBoiler_And_EmptyPot_Then_Boil()
        {
            _target.Start();

            Assert.True(_api.Boiler);
        }

        [Fact]
        public void When_Started_WithEmptyBoiler_And_EmptyPot_Then_StopBoiling()
        {
            _target.Start();

            Assert.False(_api.Boiler);
        }
    }
}
