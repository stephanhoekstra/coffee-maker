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
        public void WhenThereIsaPotOnTheWarmer_AndThePotIsNotEmpty_ThenWarmThePot()
        {
            _api.Plate = (int) PlateStatus.NonEmptyPot;
            _target = new MarkIV(_api);
            Assert.True(_api.Warmer);
        }


        [Fact]
        public void WhenThereIsaPotOnTheWarmer_AndThePotIsEmpty_ThenDoNotWarmThePot()
        {
            _api.Plate = (int)PlateStatus.EmptyPot;
            _target = new MarkIV(_api);
            Assert.False(_api.Warmer);
        }

        [Fact]
        public void WhenThereIsNoPotOnTheWarmer_AndThePotIsEmpty_ThenDoNotWarmThePot()
        {
            _api.Plate = (int)PlateStatus.NoPot;
            _target = new MarkIV(_api);
            Assert.False(_api.Warmer);
        }

    }
}
