using CoffeeMakerApi;

namespace CoffeeMaker
{
  

    public class Warmer
    {
        private readonly ICoffeeMakerApi _api;

        public Warmer(ICoffeeMakerApi api)
        {
            _api = api;
        }

        public void OnPlateChanged(object sender, PlateEventArgs e)
        {
            switch (e.Status)
            {
                case PlateStatus.NoPot:
                case PlateStatus.EmptyPot:
                    _api.SetWarmer(false);
                    break;
                case PlateStatus.NonEmptyPot:
                    _api.SetWarmer(true);
                    break;
            }
        }
    }
}