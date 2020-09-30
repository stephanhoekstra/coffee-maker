using CoffeeMakerApi;

namespace CoffeeMaker
{
    public class Valve
    {
        private readonly ICoffeeMakerApi _api;

        public Valve(ICoffeeMakerApi api)
        {
            _api = api;
        }

        public void OnBoilerChanged(object sender, BoilerEventArgs e)
        {
        }
    }
}