using CoffeeMaker;
using CoffeeMakerApi;
using Moq;
using Xunit;

namespace CoffeeMakerTests
{
    public class MarkIVTests
    {
        private readonly MarkIV _target;

        public MarkIVTests()
        {
            var api = new Mock<ICoffeeMakerApi>();
            _target = new MarkIV(api.Object);
        }

        [Fact]
        public void CanMakeCoffee()
        {
            _target.MakeCoffee();

            //assert that we have coffee

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
    }
}
