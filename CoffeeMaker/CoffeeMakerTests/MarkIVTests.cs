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

        }
    }
}
