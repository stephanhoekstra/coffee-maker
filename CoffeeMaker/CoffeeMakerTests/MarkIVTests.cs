using CoffeeMaker;
using CoffeeMakerApi;
using Moq;
using Xunit;

namespace CoffeeMakerTests
{
    public class MarkIVTests
    {
        private readonly Boiler _boiler;
        private MarkIV _target;
        private CofeeMakerApiStub _api;
        private Plate _plate;

        public MarkIVTests()
        {
            _api = new CofeeMakerApiStub();
            _plate = new Plate(_api);
            _boiler = new Boiler(_api);
        }

        [Fact]
        public void WhenNotStarted_AndBoilerIsNotEmpty_ThenDoNotBoil()
        {
            _api.BoilerHasWater = true;
            _target = new MarkIV(_api,_boiler, _plate);

            Assert.False(_api.HeaterIsActive);
        }

        [Fact]
        public void WhenStarted_AndBoilerIsNotEmpty_ThenBoil()
        {
            _api.Button = true;
            _api.BoilerHasWater = true;
           
            _target = new MarkIV(_api, _boiler, _plate);

            Assert.True(_api.HeaterIsActive);
            Assert.False(_api.Valve);
        }

        [Fact]
        public void WhenThereIsaPotOnTheWarmer_AndThePotIsNotEmpty_ThenWarmThePot()
        {
            _api.Plate = (int) PlateStatus.NonEmptyPot;
            _target = new MarkIV(_api, _boiler, _plate);
            Assert.True(_api.Warmer);
        }


        [Fact]
        public void WhenThereIsaPotOnThePlate_AndThePotIsEmpty_ThenDoNotWarmThePot()
        {
            _api.Plate = (int)PlateStatus.EmptyPot;
            _target = new MarkIV(_api, _boiler, _plate);
            Assert.False(_api.Warmer);
        }

        [Fact]
        public void WhenThereIsNoPotOnThePlate_AndThePotIsEmpty_ThenDoNotWarmThePot()
        {
            _api.Plate = (int)PlateStatus.NoPot;
            _target = new MarkIV(_api, _boiler, _plate);
            Assert.False(_api.Warmer);
        }


        [Fact]
        public void WhenThereIsNoPotOnThePlate_Then_DisableCoffeeFlow()
        {
            _api.Plate = (int)PlateStatus.NoPot;
            _target = new MarkIV(_api, _boiler, _plate);
            Assert.True(_api.Valve);
        }

        /// <summary>
        /// there is no status to distinguish a pot with some coffee from a pot which is full,
        /// so keep the coffee flowing
        /// potential bug: if you put more water in the boiler than the pot can hold, you can overflow it.
        /// assuming this will never happen because you probably use the pot to fill the boiler.
        /// </summary>
        /// <param name="status"></param>
        [Theory]
        [InlineData(PlateStatus.NonEmptyPot)]  
        [InlineData(PlateStatus.EmptyPot)]          
        public void WhenThereIsAPotOnThePlate_Then_EnableCoffeeFlow(PlateStatus status)
        {
            _api.Plate = (int)status;
            _target = new MarkIV(_api, _boiler, _plate);
            Assert.False(_api.Valve);
        }

        [Fact]
        public void WhenThereIsNoPotOnThePlate_Then_OpenTheValveToReleasePressure()
        {
            _api.Plate = (int)PlateStatus.NoPot;
            _target = new MarkIV(_api, _boiler, _plate);
            Assert.True(_api.Valve);
        }

        [Fact]
        public void WhenTheBoilingStops_Then_TurnTheLightOn()
        {
            _boiler.Activate();
            _target = new MarkIV(_api, _boiler, _plate);
            
            _boiler.DeActivate();
            
            Assert.True(_api.Light);
        }


        [Fact]
        public void WhenAnEmptyPotIsPlaced_Then_TurnTheLightOff()
        {
            _api.Light = true;
            _target = new MarkIV(_api,_boiler,_plate);

            _plate.Change(PlateStatus.EmptyPot);


            Assert.False(_api.Light);
        }

    }
}
