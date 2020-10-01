using CoffeeMakerApi;

namespace CoffeeMaker
{
    public class Light
    {
        private readonly ICoffeeMakerApi _api;

        public Light(ICoffeeMakerApi api)
        {
            _api = api;
        }

        public void OnPlateChanged(object sender, PlateEventArgs e)
        {
            switch (e.Status)
            {
                case PlateStatus.EmptyPot:
                    _api.SetLight(false);
                    break;
            }
        }

        public void OnDeactivated(object sender, BoilerEventArgs e)
        {
            _api.SetLight(true);
        }
    }
}