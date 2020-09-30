using CoffeeMakerApi;

namespace CoffeeMaker
{

    public class MarkIV
    {
        public MarkIV(ICoffeeMakerApi api)
        {
            var valve = new Valve(api);
            var boiler = new Boiler(api);
            boiler.BoilerChanged +=valve.OnBoilerChanged;
            boiler.Trigger();
        }
    }
}
