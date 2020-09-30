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

        public void OnPlateChanged(object sender, PlateEventArgs e)
        {
            switch (e.Status)
            {
                case PlateStatus.NoPot:
                    _api.SetValve(true);
                    break;
                case PlateStatus.NonEmptyPot:
                case PlateStatus.EmptyPot:
                    _api.SetValve(false);
                    break;
            }
        }

        public void OnBoilerChanged(object sender, BoilerEventArgs e)
        {
        }
    }
}