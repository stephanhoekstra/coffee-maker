using CoffeeMaker;
using CoffeeMakerApi;
using Moq;
using Xunit;

namespace CoffeeMakerTests
{
    public class MarkIVTests
    {
        private MarkIV _target;
        private CofeeMakerApiStub _api;

        public MarkIVTests()
        {
            _api = new CofeeMakerApiStub();
        }

       

        [Fact]
        public void WhenBoilerIsNotEmpty_ThenBoil()
        {
            _api.Button = true;
            _api.BoilerHasWater = true;
           
            _target = new MarkIV(_api);

            Assert.True(_api.HeaterIsActive);
            Assert.False(_api.Valve);
        }

        [Fact]
        public void WhenBoilerIsEmpty_Then_ContinueBoiling_ButAlso_ReleasePressure()
        {
            _api.BoilerHasWater = false;
            
            _target = new MarkIV(_api);

            Assert.True(_api.HeaterIsActive);
            Assert.True(_api.Valve);
        }
    }
}
