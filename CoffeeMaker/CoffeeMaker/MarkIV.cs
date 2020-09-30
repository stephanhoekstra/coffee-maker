using CoffeeMakerApi;

namespace CoffeeMaker
{

    public class MarkIV
    {
        private readonly Boiler _boiler;

        public MarkIV(ICoffeeMakerApi api)
        {
            var valve = new Valve(api);
            _boiler = new Boiler(api);
            _boiler.BoilerChanged +=valve.OnBoilerChanged;
        }

        public void Start()
        {
            _boiler.Trigger();
        }
    }
}
